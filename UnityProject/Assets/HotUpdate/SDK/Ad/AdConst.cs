using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 广告常量
/// </summary>
public class AdConst
{
    #region 广告对接类型
    /// <summary>
    /// 商店0.99档领取次数
    /// </summary>
    public const int adShop0_99 = 1;
    /// <summary>
    /// 普通抽卡单抽
    /// </summary>
    public const int adRecruit1 = 2;
    /// <summary>
    /// 战斗复活
    /// </summary>
    public const int adReborn = 3;
    /// <summary>
    /// 体力购买
    /// </summary>
    public const int adBuyPP = 4;
    /// <summary>
    /// 好友度购买
    /// </summary>
    public const int adBuyFP = 5;
    /// <summary>
    /// 金币购买
    /// </summary>
    public const int adBuyGold = 6;
    /// <summary>
    /// 战斗类
    /// </summary>
    public const int adFight = 7;
    #endregion

    /// <summary>
    /// 广告点券事件ID（注意：请勿与广告对接类型相同）
    /// </summary>
    public const int adCoupon = 99999;

    /// <summary>
    /// 广告选项类型（操作类型）
    /// </summary>
    public const int adOptionWatch = 1; // 观看
    public const int adOptionCoupon = 2; // 点券
    public const int adOptionCancel = 3; // 取消

    /// <summary>
    /// 刷新广告次数和点券（唯一即可）
    /// </summary>
    private static Dictionary<int, Action<int>> _refreshAdTimes = new Dictionary<int, Action<int>>();

    public static void AddObserver(int type, Action<int> method)
    {
        _refreshAdTimes[type] = method;
    }

    public static void RemoveObserver(int type)
    {
        _refreshAdTimes[type] = null;
    }

    public static void NotifyObserver(int type, int times)
    {
        if (_refreshAdTimes.TryGetValue(type, out var method))
        {
            method?.Invoke(times);
        }
    }
}