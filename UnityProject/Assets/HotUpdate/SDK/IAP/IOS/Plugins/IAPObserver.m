#import "IIAPObserver.h"

@interface IAPObserver () {
    // 声明一个私有成员变量
    SKProductsRequest *_productsRequest;
}

- (void)cacheTransaction:(SKPaymentTransaction *)transaction;
- (void)sendToUnity:(SKPaymentTransaction *)transaction;

@property (atomic, strong) NSMutableDictionary *cachedTransactions;
@property BOOL onListen;

@end

@implementation IAPObserver

+ (instancetype)instance {
    static IAPObserver *instance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        instance = [[self alloc] init];
    });
    return instance;
}

- (instancetype)init {
    NSLog(@"[IAPObserver] init");

    if(self = [super init]) {
        NSLog(@"[IAPObserver] addTransactionObserver");
        self.cachedTransactions = [NSMutableDictionary dictionary];
        self.onListen = false;
        [[SKPaymentQueue defaultQueue] addTransactionObserver:self];
    }

    return self;
}

- (void)listenOnPurchased{
    self.onListen = true;
    NSArray *allKeys = [self.cachedTransactions allKeys];
    for(NSString *key in allKeys){
        SKPaymentTransaction *transaction = [self.cachedTransactions valueForKey:key];
        [self sendToUnity:transaction];
    }
}

- (void)sendToUnity:(SKPaymentTransaction *)transaction {
    NSLog(@"[IAPObserver] sendToUnity TransactionIdentifier: %@", transaction.transactionIdentifier);
    // 加载收据数据
    NSDictionary *transactionData = @{
        @"transactionIdentifier": transaction.transactionIdentifier,
        @"productIdentifier": transaction.payment.productIdentifier,
    };
    NSError *error;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:transactionData options:0 error:&error];
    NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    UnitySendMessage("IOSProxy", "OnTransactionBePurchasedMessage", strdup([jsonString UTF8String]));
}

- (void)finishTransaction:(NSString *)transactionIdentifier {
    NSLog(@"[IAPObserver] finishTransaction:%@", transactionIdentifier);
    SKPaymentTransaction* transaction = [self.cachedTransactions objectForKey:transactionIdentifier];
    if(transaction == nil){
        NSLog(@"[IAPObserver] can't find transaction:%@", transactionIdentifier);
        return;
    }
    NSLog(@"[IAPObserver] transaction found:%@", transactionIdentifier);
    [[SKPaymentQueue defaultQueue] finishTransaction:transaction];
}

- (void)OnTransactionBePurchasedMessage {
    NSLog(@"[IAPObserver] listen on purchased");
    self.onListen = true;
    NSArray *allKeys = [self.cachedTransactions allKeys];
    for(NSString *key in allKeys){
        SKPaymentTransaction* transaction = [self.cachedTransactions objectForKey:key];
        [self sendToUnity:transaction];
    }
}

// https://developer.apple.com/documentation/storekit/skproductsrequest?language=objc
- (void) requestProductsWithIdentifiers:(NSSet *)productIdentifiers {
    _productsRequest = [[SKProductsRequest alloc] initWithProductIdentifiers:productIdentifiers];
    _productsRequest.delegate = self;
    [_productsRequest start];
}

// https://developer.apple.com/documentation/storekit/skproduct
- (void)purchaseProductWithIdentifier:(NSString *)productIdentifier appAccountToken:(NSString*)token{
    SKMutablePayment *payment = [SKMutablePayment paymentWithProductIdentifier:productIdentifier];
    payment.applicationUsername = token;
    [[SKPaymentQueue defaultQueue] addPayment:payment];
}

- (void)cacheTransaction:(SKPaymentTransaction *)transaction {
    
    NSLog(@"[IAPObserver] cacheTransaction:%@", transaction.transactionIdentifier);
    [self.cachedTransactions setValue:transaction forKey:transaction.transactionIdentifier];
}


#pragma mark - SKProductsRequestDelegate

- (void)productsRequest:(SKProductsRequest *)request didReceiveResponse:(SKProductsResponse *)response {
    NSLog(@"[IAPObserver] productsRequest:didReceiveResponse");
    NSMutableArray *productsArray = [NSMutableArray array];
    for (SKProduct *product in response.products) {

        NSLog(@"[IAPObserver] Product Identifier: %@", product.productIdentifier);
        NSLog(@"[IAPObserver] Product Title: %@", product.localizedTitle);
        NSLog(@"[IAPObserver] Product Description: %@", product.localizedDescription);
        NSLog(@"[IAPObserver] Product Price: %@", product.price);
        NSNumberFormatter *numberFormatter = [[NSNumberFormatter alloc] init];
        [numberFormatter setFormatterBehavior:NSNumberFormatterBehavior10_4];
        [numberFormatter setNumberStyle:NSNumberFormatterCurrencyStyle];
        [numberFormatter setLocale:product.priceLocale];
        
        NSString *formattedPrice = [numberFormatter stringFromNumber:product.price];

        NSDictionary *productDict = @{
            @"productIdentifier": product.productIdentifier,
            @"localizedTitle": product.localizedTitle,
            @"localizedDescription": product.localizedDescription,
            @"price": formattedPrice,
            @"priceLocale": [product.priceLocale objectForKey:NSLocaleCurrencyCode]
        };

        [productsArray addObject:productDict];

    };

    NSDictionary *responseDict = @{
        @"products": productsArray,
        @"invalidProductIdentifiers": response.invalidProductIdentifiers
    };

    NSLog(@"[IAPObserver] Invalid Product Identifiers:");
    for (NSString *invalidIdentifier in response.invalidProductIdentifiers) {
        NSLog(@"[IAPObserver] Invalid Identifier: %@", invalidIdentifier);
    }


    NSError *error;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:responseDict options:0 error:&error];
    
    if (!jsonData) {
        NSLog(@"[IAPObserver] Could not convert products response to JSON: %@", error.localizedDescription);
        UnitySendMessage("IOSProxy", "SKProductsResponseMessage", "{\"products\": [], \"invalidProductIdentifiers\": []}");
    } else {
        NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
        UnitySendMessage("IOSProxy", "SKProductsResponseMessage", strdup([jsonString UTF8String]));
    }
}

#pragma mark - SKPaymentTransactionObserver

- (void)paymentQueue:(SKPaymentQueue *)queue updatedTransactions:(NSArray<SKPaymentTransaction *> *)transactions {
    for (SKPaymentTransaction *transaction in transactions) {
        NSLog(@"[IAPObserver] transactionState: %ld, identifier:%@", transaction.transactionState, transaction.transactionIdentifier);
        switch (transaction.transactionState) {
            case SKPaymentTransactionStatePurchased:
                // 处理购买成功
                [self cacheTransaction:transaction];
                if(self.onListen){
                    [self sendToUnity: transaction];
                }
                break;
            case SKPaymentTransactionStateFailed:
                // 处理购买失败
                UnitySendMessage("IOSProxy", "OnTransactionBeFailedOrCanceledMessage", "");
                break;
            case SKPaymentTransactionStateRestored:
                // 处理恢复购买
                break;
            case SKPaymentTransactionStateDeferred:
                // nothing
                break;
            default:
                break;
        }
    }
}

@end

