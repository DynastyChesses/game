using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.IAP.IOS
{
    /// <summary>
    /// https://developer.apple.com/documentation/storekit/skpaymenttransaction?language=objc
    /// A payment transaction is created whenever a payment is added to the payment queue. The system delivers transactions to your app when the App Store finishes processing the payment. Completed transactions provide a receipt and transaction identifier that your app can use to save a permanent record of the processed payment.
    /// </summary>
    [Serializable]
    public class PaymentTransaction : IIAPTransaction
    {
        /// <summary>
        /// A string that uniquely identifies a successful payment transaction.
        /// </summary>
        public string transactionIdentifier;

        /// <summary>
        /// 商品唯一标识
        /// </summary>
        public string productIdentifier;

        public string TransactionIdentifier => transactionIdentifier;

        public string ProductIdentifier => productIdentifier;

        public string ParamsForFinisheTheTransaction => transactionIdentifier;

        public PayStatus Status { get; set; }
    }
}
