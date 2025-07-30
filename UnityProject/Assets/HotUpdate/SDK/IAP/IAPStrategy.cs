using System;
using System.Collections.Generic;

namespace MobileSDK.IAP
{
    public interface IIAPStrategy
    {
        /// <summary>
        /// 当前服务接口是否有效
        /// 如可IsAvailable = false, 则表示该服务不可用
        /// </summary>
        public bool IsAvailable { get; }

        /// <summary>
        /// 是否支持查询商品信息
        /// </summary>
        public bool SupportQueryProductDetails { get; }

        /// <summary>
        /// 开始初始化逻辑，初始化如果成功，IsAvailable = true
        /// </summary>
        public void Start();

        /// <summary>
        /// 发起购买
        /// </summary>
        /// <param name="product"></param>
        /// <param name="associatedUUId">与此次购买相关联的uuid</param>
        public void Pay(ProductInfo product, string associatedUUId);

        /// <summary>
        /// 设置订单状态变更的回调
        /// 订单状态变化时需要触发回调函数
        /// </summary>
        /// <param name="callback"></param>
        public void SetTransactionUpdatedCallback(Action<IIAPTransaction> callback);

        /// <summary>
        /// 当用户取消付款时调用
        /// </summary>
        /// <param name="callback"></param>
        public void SetPayCanceledCallback(Action callback);

        /// <summary>
        /// 设置付款被中断时调用
        /// </summary>
        /// <param name="callback"></param>
        public void SetPayTerminatedCallback(Action callback);

        /// <summary>
        /// 请求获取商品信息
        /// </summary>
        /// <param name="products"></param>
        /// <param name="callback"></param>
        public void RequestProductsInfo(
            ProductInfo[] products,
            Action<List<IProductDetails>> callback
        );

        /// <summary>
        /// 将订单标为完成状态
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        public void FinishTransaction(string transactionIdentifier);

        /// <summary>
        /// 重新恢复订单的流程
        /// 主要处理那些用户已经付款，但是订单没有标识为完成状态的订单
        /// </summary>
        public void ResumeTransactions();
    }

    public enum PayResult
    {
        Ok,
        Cancel,
        Error
    }

    [Serializable]
    public class ProductInfo
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public string productId;

        /// <summary>
        /// 是否为订阅商品
        /// </summary>
        public bool isSub;
    }
}
