using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.IAP
{
    public interface IIAPTransaction
    {
        /// <summary>
        /// 订单唯一标识
        /// </summary>
        public string TransactionIdentifier { get; }

        /// <summary>
        /// 订单所购商品得标识
        /// </summary>
        public string ProductIdentifier { get; }

        /// <summary>
        /// 用于在平台完成交易的参数
        /// </summary>
        public string ParamsForFinisheTheTransaction { get; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public PayStatus Status { get; }
    }

    public enum PayStatus
    {
        // 未付款
        None,

        // 已付款
        Paid
    }
}
