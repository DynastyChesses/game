using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.Ad
{
    public interface IRewardedAdProvider
    {
        /// <summary>
        /// 激励广告加载完成事件
        /// </summary>
        public Action OnRewardedAdLoaded { get; set; }

        /// <summary>
        /// 激励广告展示给玩家
        /// </summary>
        public Action OnRewardedAdDisplayed { get; set; }

        /// <summary>
        /// 激励广告被关闭
        /// </summary>
        public Action OnRewardedAdHidden { get; set; }

        /// <summary>
        /// 当给予玩家奖励
        /// </summary>
        public Action OnRewardedAdReceivedReward { get; set; }

        /// <summary>
        /// 激励广告是否已经准备好
        /// </summary>
        /// <param name="adIdentifier"></param>
        /// <returns></returns>
        public bool IsRewardedAdReady();

        /// <summary>
        /// 展示激励广告
        /// </summary>
        /// <param name="adIdentifier"></param>
        public void ShowRewardedAd();

        /// <summary>
        /// 加载激励广告
        /// </summary>
        /// <param name="adIdentifier"></param>
        public void LoadRewardedAd();

        /// <summary>
        /// GDPR是General Data Protection Regulation（通用数据保护条例）的缩写，
        /// 它是欧盟（EU）在2018年5月25日开始实施的一项数据保护和隐私的法律。
        /// GDPR的目的是为了保护所有欧盟公民的数据隐私和个人信息，并且重新规定了组织在全球范围内如何管理和处理欧盟公民的个人数据。
        /// </summary>
        /// <param name="share"></param>
        public void SetUserConsentSharePrivacyAboutGDPR(bool accepted);

        public GDPRUserAcceptStatus GetUserConsentSharePrivacyAboutGDPR();

        /// <summary>
        /// 设置用户id
        /// </summary>
        /// <param name="userId"></param>
        public void SetUserId(string userId);
    }

    /// <summary>
    ///
    /// </summary>
    public enum GDPRUserAcceptStatus
    {
        Unknow,
        Accepted,

        Decline
    }
}
