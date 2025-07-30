using UnityEngine;

namespace MobileSDK.PlatformSocial
{
    public class GameCenterSocialStrategy : ISocialStrategy
    {
        private readonly ILogger _logger = LoggerFactory.Get("GameCenterSocialStrategy");

        public void ReportScore(int score, string leadreboardId)
        {
            UnityEngine.Social.ReportScore(
                score,
                leadreboardId,
                (r) =>
                {
                    if (!r)
                        _logger.Error(
                            $"Report Score Failed, leaderboardId:{leadreboardId}, score:{score}"
                        );
                }
            );
        }

        public void ShowLeaderboard()
        {
            UnityEngine.Social.ShowLeaderboardUI();
        }
    }
}
