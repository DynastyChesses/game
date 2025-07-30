#import "IIAPObserver.h"



#ifdef __cplusplus
extern "C" {
#endif
    // 请求获取商品信息
    void _requestProductsWithIdentifiers(const char *productIdentifiers){
        NSString *identifiersStr = [NSString stringWithUTF8String:productIdentifiers];
        NSArray *identifiersArray = [identifiersStr componentsSeparatedByString:@","];
        NSSet *identifiersSet = [NSSet setWithArray:identifiersArray];
        [[IAPObserver instance] requestProductsWithIdentifiers:identifiersSet];
    }

    // 请求购买商品
    void _purchaseProductWithIdentifier(const char *productIdentifier, const char* appAccountToken) {
        [[IAPObserver instance] purchaseProductWithIdentifier: [NSString stringWithUTF8String:productIdentifier] appAccountToken: [NSString stringWithUTF8String:appAccountToken]];
    }
    
    // 监听订单付款完成事件
    void _listenOnPurchased() {
        [[IAPObserver instance] listenOnPurchased];
    }
    
    // 完成指定的订单
    void _finishTransaction(const char *transactionIdentifier) {
        [[IAPObserver instance] finishTransaction: [NSString stringWithUTF8String:transactionIdentifier]];
    }
            



#ifdef __cplusplus
}
#endif
