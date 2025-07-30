using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.Ad
{
    /// <summary>
    /// 激励广告监听
    /// </summary>
    public interface IRewardedAdListener
    {
        /// <summary>
        /// 激励广告加载完成
        /// </summary>
        public void OnRewardedAdLoaded();

        /// <summary>
        /// 激励广告显示给玩家
        /// </summary>
        public void OnRewardedAdDisplayed();

        /// <summary>
        /// 激励广告被隐藏
        /// </summary>
        public void OnRewardedAdHidden();

        /// <summary>
        /// 激励广告奖励发放
        /// </summary>
        public void OnRewardedAdReceivedReward();
    }
}
