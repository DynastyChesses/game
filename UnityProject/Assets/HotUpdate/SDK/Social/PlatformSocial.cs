namespace MobileSDK.PlatformSocial
{
    public class PlatformSocial : Singleton<PlatformSocial>
    {
        private static readonly ILogger _logger = LoggerFactory.Get("PlatformSocial");

        private ISocialStrategy _strategy;

        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        public bool IsAvailable()
        {
            return this._strategy != null;
        }

        /// <summary>
        /// 展示平台下的排行榜
        /// </summary>
        public void ShowLeaderboard()
        {
            _checkStrategy();
            this._strategy.ShowLeaderboard();
        }

        /// <summary>
        /// 上报排行榜分数
        /// </summary>
        public void ReportScore(int score, string leadreboardId)
        {
            _checkStrategy();
            _logger.Debug($"Report Score: {score} leadreboardId: {leadreboardId}");
            this._strategy.ReportScore(score, leadreboardId);
        }

        public void SetStrategy(ISocialStrategy strategy)
        {
            _logger.Debug($"SetStrategy: {strategy.GetType()}");
            this._strategy = strategy;
        }

        private void _checkStrategy()
        {
            if (this._strategy == null)
                throw new System.Exception("strategy is null");
        }

        public override void Dispose()
        {
            // TODO
        }
    }
}
