#if PRODUCT_GLOBAL
using KR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KR.SDK;
using UnityEngine;
using MobileSDK.Ad;

namespace ILRuntimeDLL.SDK
{
    internal static partial class AdManager
    {
        public static UserAcceptStatus UserAccepted
        {
            get
            {
                var s = AdService.Instance.GetUserConsentSharePrivacyAboutGDPR();
                switch (s)
                {
                    case GDPRUserAcceptStatus.Unknow:
                        return UserAcceptStatus.UAS_UNKNOWN;
                    case GDPRUserAcceptStatus.Accepted:
                        return UserAcceptStatus.UAS_ACCEPTED;
                    case GDPRUserAcceptStatus.Decline:
                        return UserAcceptStatus.UAS_DECLINE;
                    default:
                        return UserAcceptStatus.USA_ERROR;
                }
            }
            set
            {
                bool share;
                switch (value)
                {
                    case UserAcceptStatus.UAS_UNKNOWN:
                        return;
                    case UserAcceptStatus.UAS_ACCEPTED:
                        share = true;
                        break;
                    case UserAcceptStatus.UAS_DECLINE:
                        share = false;
                        break;
                    default:
                        share = false;
                        break;
                }
                AdService.Instance.SetUserConsentSharePrivacyAboutGDPR(share);
                // FORADS.setUserConsentSharePrivacyAboutCCPA(share);
                // FORADS.setUserConsentSharePrivacyAboutGDPR(share);
            }
        }

        private static string[] GetAdSpaceIds()
        {
            var raid = GetRewardAdSpaceId();
            return string.IsNullOrEmpty(raid) ? new string[] { } : new[] { raid };
        }

        private static string GetRewardAdSpaceId()
        {
            return RunVariants.CurrentSetting.CurrentGiaSetting.AppID switch
            {
                "100163" => "1302", //Android
                "100164" => "1303", //iOS
                "100137" => "1306", //Android
                "100138" => "1305", //iOS
                _ => ""
            };
        }

        private static string GetECPM(string raid)
        {
            // return FORADS.getInstance().fetchAdEcpm(raid);
            return "";
        }

        private static void RecordRewardWatchTimes()
        {
            //记录观看次数
        }

        // private static void TrackRewardAD(RewardVideoStep step, string entryId, ForAd ad)
        // {
        //     GIABISDKManager.TrackAd(((int)step).ToString(), "rewardvideo",
        //         entryId, ad?.platformId??"", ad?.platformDesc??"", ad?.positionId??"",
        //         "", "", "", 0, 0, 0, null);
        //     //todo param
        // }
    }
}

#endif
