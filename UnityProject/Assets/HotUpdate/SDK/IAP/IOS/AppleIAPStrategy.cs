using System;
using System.Collections.Generic;
using System.Linq;
using MobileSDK.IAP;

namespace MobileSDK.IAP.IOS
{
    /// <summary>
    /// 苹果支付实现
    /// </summary>
    public class AppleIAPStrategy : IIAPStrategy
    {
        ILogger _logger;

        private Action<IIAPTransaction> _onTransactionUpdatedCallback;
        private Action _onPayCanceledCallback;
        private Action _onPayTerminatedCallback;
        private Action<List<IProductDetails>> _productsInfoCallback;
        private bool _enabled = false;

        public AppleIAPStrategy()
        {
            this._logger = LoggerFactory.Get("AppleIAPStrategy");
        }

        public IOSProxy IOSProxy
        {
            get { return IOSProxy.Instance; }
        }

        public bool IsAvailable => this._enabled;

        public bool SupportQueryProductDetails => true;

        public void FinishTransaction(string transactionIdentifier)
        {
            IOSProxy.Bridge.FinishTransaction(transactionIdentifier);
        }

        public void SetTransactionUpdatedCallback(Action<IIAPTransaction> callback)
        {
            this._onTransactionUpdatedCallback = callback;
        }

        public void Pay(ProductInfo product, string userId)
        {
            IOSProxy.Bridge.PurchaseProduct(product.productId, userId);
        }

        public void RequestProductsInfo(
            ProductInfo[] products,
            Action<List<IProductDetails>> callback
        )
        {
            IOSProxy.Bridge.RequestProducts(
                products.Select(product => product.productId).ToArray()
            );
            this._productsInfoCallback = callback;
        }

        public void Start()
        {
            IOSProxy.OnPurchaseCanceled += () =>
            {
                this._onPayCanceledCallback?.Invoke();
            };

            IOSProxy.OnTransactionBePurchased += (trans) =>
            {
                trans.Status = PayStatus.Paid;
                this._onTransactionUpdatedCallback?.Invoke(trans);
            };

            IOSProxy.OnSKProductsResponse += (resp) =>
            {
                List<IProductDetails> products = new List<IProductDetails>();
                products.AddRange(resp.products);
                this._productsInfoCallback?.Invoke(products);
                this._productsInfoCallback = null;
            };
            IOSProxy.Bridge.ListenOnPurchased();
            this._enabled = true;
        }

        public void ResumeTransactions()
        {
            // TODO: 苹果似乎没有主动拉取未完成的订单功能
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
