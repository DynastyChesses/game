
// 广告
// public partial class AdLogic4Global
// {
//     private SocketManager socketMgr => SocketManager.Instance;
//     private MessageCenter _msgCenter => MessageCenter.Instance;
//     private NetManager _netMgr => NetManager.Instance;
//
//     private void AddListener()
//     {
//         // 
//         _msgCenter.AddObserver((int)MessageTypeConst.GcResRef, ResRefResponse);
//         _msgCenter.AddObserver((int)MessageTypeConst.GcAdList, AdListResponse);
//         _msgCenter.AddObserver((int)MessageTypeConst.GcAdReward, AdRewardResponse);
//     }
//
//     private void RemoveListener()
//     {
//         //
//         _msgCenter.RemoveObserver((int)MessageTypeConst.GcResRef, ResRefResponse);
//         _msgCenter.RemoveObserver((int)MessageTypeConst.GcAdList, AdListResponse);
//         _msgCenter.RemoveObserver((int)MessageTypeConst.GcAdReward, AdRewardResponse);
//     }
//
//     private void ResRefResponse(byte[] data)
//     {
//         GC_RES_REF msg = GC_RES_REF.Parser.ParseFrom(data);
//
//         Log.Debug($"AdLogic4Global.ResRefResponse() count={msg.res.Count}");
//
//         for (int i = 0; i < msg.res.Count; i++)
//         {
//             var res = msg.res[i];
//
//             // 货币-观影券 1_9
//             if (res.resType == ResCategory.Currency)
//             {
//                 if (res.resId == ResType.AdCoupon)
//                 {
//                     _module.Set((int)res.count);
//
//                     Log.Debug($"AdLogic4Global.ResRefResponse() type={res.resType}, id={res.resId}, count={res.count}");
//
//                     break;
//                 }
//             }
//         }
//     }
//
//     /// <summary>
//     /// 广告请求
//     /// </summary>
//     private void AdListRequest()
//     {
//         var playerMgr = ManagerCenter.Get<PlayerManager>();
//         if (playerMgr == null)
//         {
//             return;
//         }
//
//         
//         Log.Debug($"AdLogic4Global.AdListRequest() coupon={playerMgr.GetPlayerData().adTicket}");
//
//         _module.Set(playerMgr.GetPlayerData().adTicket);
//
//         CG_AD_LIST msg = new CG_AD_LIST();
//
//         socketMgr.Send((int)MessageTypeConst.CgAdList, msg);
//     }
//
//     private void AdListResponse(byte[] data)
//     {
//         GC_AD_LIST msg = GC_AD_LIST.Parser.ParseFrom(data);
//
//         Log.Debug($"AdLogic4Global.AdListResponse() errorCode={msg.errorCode}");
//
//         if (msg.errorCode == NetCode.MASSAGE_SUCCESS)
//         {
//             _module.Reset();
//
//             for (int i = 0; i < msg.adInfo.Count; i++)
//             {
//                 _module.Set(msg.adInfo[i].adId, msg.adInfo[i].count);
//
//                 Log.Debug($"AdLogic4Global.AdListResponse() adId={msg.adInfo[i].adId}, count={msg.adInfo[i].count}");
//             }
//
//             return;
//         }
//
//         Log.Error($"AdLogic4Global.AdListResponse() errorCode={msg.errorCode}");
//     }
//
//     /// <summary>
//     /// 观看广告请求
//     /// </summary>
//     /// <param name="adId">广告对接类型（参见：AdConst.cs）</param>
//     /// <param name="option">广告操作选项（参见：AdConst.cs）</param>
//     /// <param name="args">广告对接参数</param>
//     public void AdRewardRequest(int adId, int option, string args)
//     {
//         Log.Debug($"AdLogic4Global.AdRewardRequest() adId={adId}, option={option}, args={args}");
//
//         CG_AD_REWARD msg = new CG_AD_REWARD();
//
//         msg.adId = adId;
//         msg.opt = option;
//         if (null != args)
//             msg.args = args;
//
//         socketMgr.Send((int)MessageTypeConst.CgAdReward, msg);
//     }
//
//     /// <summary>
//     /// 观看广告响应
//     /// </summary>
//     /// <param name="data"></param>
//     private void AdRewardResponse(byte[] data)
//     {
//         GC_AD_REWARD msg = GC_AD_REWARD.Parser.ParseFrom(data);
//
//         if (msg.errorCode == NetCode.MASSAGE_SUCCESS)
//         {
//             Log.Debug($"AdLogic4Global.AdRewardResponse() errorCode={msg.errorCode}");
//             Log.Debug($"AdLogic4Global.AdRewardResponse() adId={msg.adId}, option={msg.opt}, args={msg.args}");
//             Log.Debug($"AdLogic4Global.AdRewardResponse() adId={msg.adInfo.adId}, count={msg.adInfo.count}");
//         }
//         else
//         {
//             Log.Error($"AdLogic4Global.AdRewardResponse() errorCode={msg.errorCode}");
//             Log.Error($"AdLogic4Global.AdRewardResponse() adId={msg.adId}, option={msg.opt}, args={msg.args}");
//             Log.Error($"AdLogic4Global.AdRewardResponse() adId={msg.adInfo.adId}, count={msg.adInfo.count}");
//         }
//
//         _module.Set(msg.adInfo.adId, msg.adInfo.count);
//
//         AdReward(msg);
//     }
// }