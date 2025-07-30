namespace MobileSDK.PlatformSocial
{
    public interface ISocialStrategy
    {
        /// <summary>
        /// 展示平台排行榜
        /// </summary>
        public void ShowLeaderboard();

        /// <summary>
        /// 上报玩家分数
        /// </summary>
        /// <param name="score"></param>
        /// <param name="leadreboardId"></param>
        public void ReportScore(int score, string leadreboardId);
    }
}
