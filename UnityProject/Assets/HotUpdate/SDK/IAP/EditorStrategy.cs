using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.IAP
{
    public class EditorStrategy : IIAPStrategy
    {
        public bool IsAvailable => true;

        /// <summary>
        /// 此strategy不支持查询商品信息
        /// </summary>
        public bool SupportQueryProductDetails => false;

        private Action<IIAPTransaction> _purchasedCallback;

        public void FinishTransaction(string transactionIdentifier)
        {
            // nothing
        }

        /// <summary>
        ///  TODO:  usertoken
        /// </summary>
        /// <param name="productIdentifier"></param>
        /// <param name="userToken"></param>
        public void Pay(ProductInfo product, string userToken)
        {
            // 直接调用callback
            var fakeTransaction = new FakeTransaction()
            {
                TransactionIdentifier = Guid.NewGuid().ToString(),
                ProductIdentifier = product.productId,
                ParamsForFinisheTheTransaction = "",
            };
            _purchasedCallback?.Invoke(fakeTransaction);
        }

        public void RequestProductsInfo(
            ProductInfo[] productIds,
            Action<List<IProductDetails>> callback
        )
        {
            throw new System.Exception("not support");
        }

        public void ResumeTransactions()
        {
            // nothing
        }

        public void SetTransactionUpdatedCallback(Action<IIAPTransaction> callback)
        {
            this._purchasedCallback = callback;
        }

        public void Start()
        {
            // nothing
        }

        public void SetPayCanceledCallback(Action callback)
        {
            throw new NotImplementedException();
        }

        public void SetPayTerminatedCallback(Action callback)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeTransaction : IIAPTransaction
    {
        public string TransactionIdentifier { get; set; }

        public string ProductIdentifier { get; set; }

        public string ParamsForFinisheTheTransaction { get; set; }

        public PayStatus Status { get; set; }
    }
}
