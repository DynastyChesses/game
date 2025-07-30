using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
/// <summary>
/// 广告数据
/// </summary>
public class AdModule
{
    private class AdData
    {
        public int id;
        public int type;
        public int times;
        public int value;
    }

    /// <summary>
    /// 广告数据表
    /// Dictionary<id, times>
    /// </summary>
    private Dictionary<int, AdData> _table;

    /// <summary>
    /// 广告数据（服务器）
    /// Dictionary<id, times>
    /// </summary>
    private Dictionary<int, int> _infos;

    /// <summary>
    /// 广告点券（数量）
    /// </summary>
    public int Coupon => _coupon;
    private int _coupon;

    public void Init(DataTable table)
    {
        if (_table == null)
        {
            _table = new Dictionary<int, AdData>(32);
        }

        if (_infos == null)
        {
            _infos = new Dictionary<int, int>(32);
        }

        _table.Clear();

        for (int i = 0; i < table.Rows.Count; i++)
        {
            var dict = table.Rows[i];

            //Log.Debug($"AdModule.Init() {dict["id"]}, {dict["type"]}, {dict["note"]}, {dict["times"]}, {dict["value"]}");

            AdData data = new AdData()
            {
                id = (int)dict["id"],
                type = (int)dict["type"],
                times = (int)dict["times"],
                value = string.IsNullOrEmpty(dict["value"].ToString()) ? 0: (int)dict["value"],
            };

            if (_table.ContainsKey(data.id))
            {
                Debug.LogError($"AdModule.Init(DataTable) Rows[{i}]={data.id}");

                continue;
            }

            _table.Add(data.id, data);
        }
    }

    public void Reset()
    {
        _infos.Clear();

        //_coupon = 0;
    }

    /// <summary>
    /// 设置广告次数（来自服务器）
    /// </summary>
    /// <param name="adId">广告对接类型</param>
    /// <param name="times">服务器默认0次</param>
    public void Set(int adId, int times)
    {
        Debug.LogError($"AdModule.Set(int, int) adId={adId}, times={times}");

        if (_table.ContainsKey(adId))
        {
            if (_infos.ContainsKey(adId))
            {
                _infos[adId] = times;
            }
            else
            {
                _infos.Add(adId, times);
            }

            AdConst.NotifyObserver(adId, _table[adId].times - times);

            return;
        }

        Debug.LogError($"AdModule.Set(int, int) adId={adId}, times={times}");
    }

    /// <summary>
    /// 设置广告点券（来自服务器）
    /// </summary>
    /// <param name="coupon"></param>
    public void Set(int coupon)
    {
        _coupon = coupon;

        AdConst.NotifyObserver(AdConst.adCoupon, coupon);
    }

    /// <summary>
    /// 观看广告次数+1
    /// </summary>
    /// <param name="adId">广告对接类型（参见：AdConst.cs）</param>
    public void Add(int adId)
    {
        Debug.LogError($"AdModule.Add(int) adId={adId}");

        if (Check(adId))
        {
            if (_infos[adId] < _table[adId].times)
            {
                _infos[adId] += 1;

                AdConst.NotifyObserver(adId, _table[adId].times - _infos[adId]);

                return;
            }

            Debug.LogError($"AdModule.Add(int) adId={adId}, {_infos[adId]} >= {_table[adId].times}");

            return;
        }

        //_infos.Add(adId, 1);

        Debug.LogError($"AdModule.Add(int) adId={adId}");
    }

    /// <summary>
    /// 获取广告次数，返回（当前次数，最大次数）
    /// </summary>
    /// <param name="adId">广告对接类型（参见：AdConst.cs）</param>
    /// <returns></returns>
    public (int, int) GetTimes(int adId)
    {
        // <TestCode> 测试代码
        //return (0, 2);

        if (Check(adId))
        {
            Debug.LogError($"AdModule.GetTimes(int) index={_infos[adId]}, count={_table[adId]}");

            return (_infos[adId], _table[adId].times);
        }

        Debug.LogError($"AdModule.GetTimes(int) adId={adId}");

        return (0, 0);
    }

    /// <summary>
    /// 获取广告ID
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public int GetId(int type, int value)
    {
        using (var iter = _table.GetEnumerator())
        {
            while (iter.MoveNext())
            {
                if (iter.Current.Value.type == type &&
                    iter.Current.Value.value == value)
                {
                    return iter.Current.Value.id;
                }
            }
        }

        //Log.Error($"AdModule.GetId() type={type}, value={value}");

        return 0;
    }

    /// <summary>
    /// 观看广告受限（不可观看）
    /// </summary>
    /// <param name="adId">广告对接类型（参见：AdConst.cs）</param>
    public bool IsLimited(int adId)
    {
        // <TestCode> 测试代码
        //return false;

        if (Check(adId))
        {
            if (_infos[adId] < _table[adId].times)
            {
                return false;
            }

            return true;
        }

        Debug.LogError($"AdModule.IsLimited(int) adId={adId}");

        return true;
    }

    private bool Check(int adId)
    {
        if (!_table.ContainsKey(adId))
        {
            //Log.Error($"AdModule.Check(1) adId={adId}");

            return false;
        }

        if (!_infos.ContainsKey(adId))
        {
            //Log.Error($"AdModule.Check(2) adId={adId}");

            return false;
        }

        return true;
    }
}