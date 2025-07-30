//https://developer.apple.com/documentation/storekit/in-app_purchase/original_api_for_in-app_purchase/offering_completing_and_restoring_in-app_purchases?language=objc
#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>


@interface IAPObserver: NSObject <SKProductsRequestDelegate, SKPaymentTransactionObserver>

+ (instancetype)instance;
// 
- (void)requestProductsWithIdentifiers:(NSSet *) productIdentifiers;
- (void)purchaseProductWithIdentifier:(NSString *) productIdentifier appAccountToken:(NSString *)token;
- (void)listenOnPurchased;
- (void)finishTransaction:(NSString *) transactionIdentifier;

@end
