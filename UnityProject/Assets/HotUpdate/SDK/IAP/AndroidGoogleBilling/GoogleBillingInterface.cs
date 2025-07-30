using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

namespace MobileSDK.IAP.GoogleBilling
{
    public class GoogleBillingInterface
    {
        private AndroidJavaObject _billingClient;
        private ILogger _logger;

        public GoogleBillingInterface()
        {
            this._logger = LoggerFactory.Get("GoogleBillingInterface");
        }

        public Action<PurchaseUpdatedResult> OnPurchasesUpdated;
        public Action<ConsumeResult> OnConsumeResult;

        /// <summary>
        /// 尝试连接到谷歌服务
        /// </summary>
        public void Connect(Action<BillingResult> callback, Action disconnectedCallback)
        {
            this._logger.Debug($"Connect");
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>(
                    "currentActivity"
                );
                this._billingClient = new AndroidJavaObject(
                    "com.ethan.googlelibrary.BillingManager"
                );

                // 尝试连接到谷歌服务
                var setupFinishedCallback =
                    new JsonCallbackWithUnitySynchronizationContext<BillingResult>(
                        (result) =>
                        {
                            this._logger.Debug($"OnBillingSetupFinished: {result}");
                            callback(result);
                        }
                    );

                /// 当与谷歌billing服务断开链接
                var onBillingServiceDisconnected =
                    new JsonCallbackWithUnitySynchronizationContext<string>(
                        (msg) =>
                        {
                            this._logger.Warining($"OnBillingServiceDisconnected: {msg}");
                            disconnectedCallback();
                        }
                    );

                // 当订单发生状态变更
                var onPurchasesUpdated =
                    new JsonCallbackWithUnitySynchronizationContext<PurchaseUpdatedResult>(
                        (result) => OnPurchasesUpdated?.Invoke(result)
                    );

                // consume有结果
                var onConsumeResult =
                    new JsonCallbackWithUnitySynchronizationContext<ConsumeResult>(
                        (result) => OnConsumeResult?.Invoke(result)
                    );

                this._billingClient.Call(
                    "connect",
                    currentActivity,
                    setupFinishedCallback,
                    onBillingServiceDisconnected,
                    onPurchasesUpdated,
                    onConsumeResult
                );
            }
        }

        /// <summary>
        /// 查询商品信息
        /// </summary>
        /// <param name="callback"></param>
        public void QueryProducts(ProductInfo[] products, Action<QueryProductsResult> callback)
        {
            this._billingClient.Call(
                "queryProducts",
                JsonUtility.ToJson(
                    new QueryProductDetailsParamJson()
                    {
                        products = new List<ProductInfo>(products)
                    }
                ),
                new JsonCallbackWithUnitySynchronizationContext<QueryProductsResult>(
                    (result) =>
                    {
                        callback(result);
                    }
                )
            );
        }

        /// <summary>
        /// 开始请求购买流
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="callback"></param>
        public void LaunchPurchaseFlow(
            string productId,
            string obfuscatedProfileId,
            Action<LanuchPurchaseFlowResult> callback
        )
        {
            this._billingClient.Call(
                "startPurchaseFlow",
                productId,
                obfuscatedProfileId,
                new JsonCallbackWithUnitySynchronizationContext<LanuchPurchaseFlowResult>(callback)
            );
        }

        /// <summary>
        /// 将消费记录标记为已消费
        /// </summary>
        /// <param name="purchaseToken"></param>
        public void Consume(string purchaseToken)
        {
            this._billingClient.Call("consumeProduct", purchaseToken);
        }

        /// <summary>
        /// 异步查询所有订单
        /// </summary>
        public void QueryPurchasesAsync()
        {
            this._billingClient.Call("queryPurchases");
        }
    }
}
