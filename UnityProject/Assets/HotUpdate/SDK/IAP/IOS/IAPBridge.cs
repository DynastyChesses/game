using System.Runtime.InteropServices;
using UnityEngine;

namespace MobileSDK.IAP.IOS
{
    public class IAPBridge : MonoBehaviour
    {
#if UNITY_IOS && !UNITY_EDITOR
        [DllImport("__Internal")]
        private static extern void _requestProductsWithIdentifiers(string productIdentifiers);

        [DllImport("__Internal")]
        private static extern void _purchaseProductWithIdentifier(
            string productIdentifier,
            string appAccountToken
        );

        [DllImport("__Internal")]
        private static extern void _listenOnPurchased();

        [DllImport("__Internal")]
        private static extern void _finishTransaction(string json);
#else
        private static extern void _requestProductsWithIdentifiers(string productIdentifiers);

        private static extern void _purchaseProductWithIdentifier(
            string productIdentifier,
            string appAccountToken
        );

        private static extern void _listenOnPurchased();

        private static extern void _finishTransaction(string json);
#endif

        /// <summary>
        /// 请求获取商品信息
        /// </summary>
        /// <param name="productIdentifiers"></param>
        public void RequestProducts(string[] productIdentifiers)
        {
            // 将字符串数组转换为以逗号分隔的字符串
            string identifiers = string.Join(",", productIdentifiers);
            _requestProductsWithIdentifiers(identifiers);
        }

        /// <summary>
        /// 购买指定商品
        /// </summary>
        /// <param name="productIdentifier"></param>
        public void PurchaseProduct(string productIdentifier, string appAccountToken)
        {
            _purchaseProductWithIdentifier(productIdentifier, appAccountToken);
        }

        /// <summary>
        /// 完成已支付的订单
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        public void FinishTransaction(string transactionIdentifier)
        {
            _finishTransaction(transactionIdentifier);
        }

        /// <summary>
        /// 监听已付款的订单
        /// Native层在App启动时就开启了PaymentQueueObserver，在ListenOnPurchased之前的transaction都会被缓存，当ListenOnPurchased调用之后，缓存的订单也会触发OnPurchased事件
        /// </summary>
        public void ListenOnPurchased()
        {
            _listenOnPurchased();
        }
    }
}
