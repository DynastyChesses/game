using System;
using System.Collections.Generic;
using MobileSDK.IAP;
using UnityEngine;

namespace MobileSDK.IAP.GoogleBilling
{
    /// <summary>
    /// 谷歌Billing支付接入
    /// </summary>
    public class GoogleBillingStrategy : IIAPStrategy
    {
        private GoogleBillingInterface _androidInterface;

        public bool IsAvailable => this._isAvailable;

        public bool SupportQueryProductDetails => true;

        private bool _isAvailable;

        private ILogger _logger;

        private Action<IIAPTransaction> _purchasedCallback;
        private Action _onPayCanceledCallback;
        private Action _onPayTerminatedCallback;

        public GoogleBillingStrategy()
        {
            this._logger = LoggerFactory.Get("GoogleBillingStrategy");
        }

        /// <summary>
        /// 将订单标为完成状态
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void FinishTransaction(string transactionIdentifier)
        {
            this._androidInterface.Consume(transactionIdentifier);
        }

        /// <summary>
        /// 请求购买指定商品
        /// </summary>
        /// <param name="productIdentifier"></param>
        /// <param name="callback"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Pay(ProductInfo product, string userToken)
        {
            this._androidInterface.LaunchPurchaseFlow(
                JsonUtility.ToJson(product),
                userToken,
                (result) =>
                {
                    // 启动购买流程成功
                    if (result.code == BillingResultCode.Ok)
                    {
                        this._logger.Debug(
                            $"launch purchase flow success, register callback for product {product.productId}"
                        );
                    }
                    else
                    {
                        this._logger.Error(
                            $"launch purchase flow failed: {result.debugMessage} {result.code}"
                        );
                        this._onPayTerminatedCallback?.Invoke();
                    }
                }
            );
        }

        /// <summary>
        /// 请求获取商品信息
        /// </summary>
        /// <param name="productIds"></param>
        /// <param name="callback"></param>
        public void RequestProductsInfo(
            ProductInfo[] productIds,
            Action<List<IProductDetails>> callback
        )
        {
            this._androidInterface.QueryProducts(
                productIds,
                (result) =>
                {
                    if (result.code == BillingResultCode.Ok)
                    {
                        List<IProductDetails> products = new List<IProductDetails>();
                        products.AddRange(result.products);
                        callback(products);
                        return;
                    }

                    callback(new List<IProductDetails>());
                }
            );
        }

        /// <summary>
        /// 尝试与GoogleBillingService建立链接
        /// </summary>
        public void Start()
        {
            this._androidInterface = new GoogleBillingInterface();
            this._androidInterface.OnPurchasesUpdated += this._onPurchasesUpdated;
            this._androidInterface.OnConsumeResult += this._onConsumeResult;
            this._androidInterface.Connect(
                (result) =>
                {
                    _isAvailable = result.code == BillingResultCode.Ok;
                    this._androidInterface.QueryPurchasesAsync();
                },
                this._onDisconnected
            );
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="result"></param>
        private void _onPurchasesUpdated(PurchaseUpdatedResult result)
        {
            this._logger.Debug(
                $"OnPurcasesUpdated code:{result.code} message:{result.debugMessage} purchasesCount:{result.purchases.Count}"
            );
            if (result.code == BillingResultCode.Ok)
                foreach (var purchase in result.purchases)
                {
                    this._logger.Debug(
                        $"purchase token:{purchase.purchaseToken} product id:{purchase.productId} orderId:{purchase.orderId} state:{purchase.state}"
                    );
                    if (purchase.state == PurchaseState.PURCHASED)
                    {
                        // find callback
                        this._logger.Debug($"callback for {purchase.productId}");
                        this._purchasedCallback?.Invoke(purchase);
                    }
                }
            else if (result.code == BillingResultCode.USER_CANCELED) // 用户取消了支付
                this._onPayCanceledCallback?.Invoke();
            else
                this._onPayTerminatedCallback?.Invoke();
        }

        private void _onConsumeResult(ConsumeResult result)
        {
            this._logger.Debug(
                $"OnConsumeResult code:{result.code} message:{result.debugMessage} purchaseToken:{result.purchaseToken}"
            );
        }

        private void _onDisconnected()
        {
            this._logger.Error($"Disconnected");
            this._isAvailable = false;
            // TODO: reconnect
        }

        public void SetTransactionUpdatedCallback(Action<IIAPTransaction> callback)
        {
            this._purchasedCallback = callback;
        }

        public void ResumeTransactions()
        {
            this._androidInterface.QueryPurchasesAsync();
        }

        public void SetPayCanceledCallback(Action callback)
        {
            this._onPayCanceledCallback = callback;
        }

        public void SetPayTerminatedCallback(Action callback)
        {
            this._onPayTerminatedCallback = callback;
        }
    }
}
