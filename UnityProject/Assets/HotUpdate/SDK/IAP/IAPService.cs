using System;
using System.Collections.Generic;
using MobileSDK.Utils;

namespace MobileSDK.IAP
{
    public class IAPService : Singleton<IAPService>
    {
        ILogger _logger;
        private IIAPStrategy _strategy;

        /// <summary>
        /// 内购功能是否可用
        /// </summary>
        public bool IsAvailable => this._strategy != null && this._strategy.IsAvailable;

        public IAPService()
        {
            this._logger = LoggerFactory.Get("IAPService");
        }

        /// <summary>
        /// 设置支付策略
        /// </summary>
        public void SetStrategy(IIAPStrategy strategy)
        {
            this._logger.Info($"SetStrategy {strategy.GetType()}");
            this._strategy = strategy;
        }

        public void Start()
        {
            this._logger.Info("Start");
            _checkStrategy();
            this._strategy.Start();
        }

        /// <summary>
        /// 请求购买指定商品
        /// </summary>
        /// <param name="product"></param>
        /// <param name="associatedUUId">与此次购买相关联的uuid</param>
        public void Pay(ProductInfo product, string associatedUUId)
        {
            _checkStrategy();
            this._logger.Info(
                $"Pay:{product.productId}, isSub:{product.isSub} associatedUUId:{associatedUUId}"
            );
            this._strategy.Pay(product, associatedUUId);
        }

        /// <summary>
        /// 设置支付完成回调
        /// 一个订单会多次触发此回调，即使订单状态已经为完成状态
        /// 应该保证此回调函数是可重入的
        /// </summary>
        /// <param name="callback"></param>
        public void SetTransactionUpdateCallback(Action<IIAPTransaction> callback)
        {
            this._logger.Info($"SetTransactionUpdateCallback");
            _checkStrategy();
            this._strategy.SetTransactionUpdatedCallback(callback);
        }

        /// <summary>
        /// 设置用户取消付款回调
        /// </summary>
        /// <param name="callback"></param>
        public void SetPayCanceledCallback(Action callback)
        {
            this._logger.Info($"SetPayCanceledCallback");
            _checkStrategy();
            this._strategy.SetPayCanceledCallback(callback);
        }

        /// <summary>
        /// 设置支付流程中断回调
        /// 例如支付流程调用API发生异常
        /// </summary>
        /// <param name="callback"></param>
        public void SetPayTerminatedCallback(Action callback)
        {
            this._logger.Info($"SetPayTerminatedCallback");
            _checkStrategy();
            this._strategy.SetPayTerminatedCallback(callback);
        }

        /// <summary>
        /// 将订单设为已完成
        /// </summary>
        /// <param name="param"></param>
        public void FinishTransaction(string param)
        {
            this._logger.Info($"FinishTransaction: {param}");
            _checkStrategy();
            this._strategy.FinishTransaction(param);
        }

        /// <summary>
        /// 请求获取商品信息
        /// </summary>
        /// <param name="callback"></param>
        public void RequestProductsInfo(
            ProductInfo[] products,
            Action<List<IProductDetails>> callback
        )
        {
            _checkStrategy();
            this._logger.Info($"RequestProductsInfo lenth:{products.Length}");
            this._strategy.RequestProductsInfo(products, callback);
        }

        /// <summary>
        /// 尝试恢复还未完成的交易
        /// 建议在已经调用完SetPurchasedCallback后调用
        /// </summary>
        public void ResumeTransactions()
        {
            _checkStrategy();
            this._logger.Info("ResumeTransactions");
            this._strategy.ResumeTransactions();
        }

        private void _checkStrategy()
        {
            if (this._strategy != null)
                return;

            throw new Exception("IAPStrategy is null, please set it first");
        }

        public override void Dispose()
        {
            // TODO
        }
    }
}
