using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.IAP.IOS
{
    public class IOSProxy : MonoSingleton<IOSProxy>
    {
        private IAPBridge _bridge;
        private ILogger _logger;

        public IOSProxy()
        {
            this._logger = LoggerFactory.Get("IOSProxy");
        }

        public Action<SKProductsResponse> OnSKProductsResponse;

        /// <summary>
        /// 购买取消
        /// </summary>
        public Action OnPurchaseCanceled;

        private Action<PaymentTransaction> _onTransactionBePurchased;

        /// <summary>
        /// 订单变为已付款状态
        /// </summary>
        public event Action<PaymentTransaction> OnTransactionBePurchased
        {
            add
            {
                this._onTransactionBePurchased += value;
                this._bridge.ListenOnPurchased();
            }
            remove { this._onTransactionBePurchased -= value; }
        }

        public IAPBridge Bridge
        {
            get { return _bridge; }
        }

        protected void Awake()
        {
            this._logger.Debug("InitBridge");
            this._bridge = new IAPBridge();
        }

        /// <summary>
        /// 请求购买指定商品
        /// </summary>
        /// <param name="productIdentifier"></param>
        public void PurchaseProduct(string productIdentifier, string appAccountToken)
        {
            this._bridge.PurchaseProduct(productIdentifier, appAccountToken);
        }

        /// <summary>
        /// 请求获取商品信息
        /// </summary>
        /// <param name="produtIdentifiers"></param>
        public void SKProductsRequest(string[] produtIdentifiers)
        {
            this._logger.Debug("RequestProducts");
            this._bridge.RequestProducts(produtIdentifiers);
        }

        /// <summary>
        /// 收到商品信息
        /// </summary>
        /// <param name="json"></param>
        public void SKProductsResponseMessage(string json)
        {
            this._logger.Debug($"OnProducts:{json}");
            var rsp = JsonUtility.FromJson<SKProductsResponse>(json);
            this.OnSKProductsResponse?.Invoke(rsp);
        }

        /// <summary>
        /// 付款成功之后
        /// </summary>
        /// <param name="json"></param>
        public void OnTransactionBePurchasedMessage(string json)
        {
            this._logger.Debug($"OnPurchased: {json}");
            this._onTransactionBePurchased?.Invoke(JsonUtility.FromJson<PaymentTransaction>(json));
        }

        /// <summary>
        /// 购买被取消或购买失败
        /// </summary>
        public void OnTransactionBeFailedOrCanceledMessage()
        {
            this._logger.Debug($"OnPurchaseCanceledMessage");
            this.OnPurchaseCanceled?.Invoke();
        }
    }
}
