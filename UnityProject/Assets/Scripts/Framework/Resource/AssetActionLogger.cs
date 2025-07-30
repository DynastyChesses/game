using UnityEngine.Profiling;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
// [FM_Mono.IgnoreGen]
internal enum AssetBundleActionType
{
    // 请求，一个资源会有多个请求
    RequestAsset,
    RequestAssetAsync,
    ReleaseAsset, // 资源没用了，要被卸载
    
    // new AssetBundleLoadItem
    BundItemInc,
    BundItemDec,

    // 实际的加载
    LoadAsset,
    LoadAssetAsync,
    UnloadAsset,
    
    BundleLoad,
    BundleLoadAsync,
    UnloadBundle_True,
    UnloadBundle_False,
}

/// <summary>
/// 记录asset和bundle的加载卸载详细信息
/// 先缓存到内存，需要时写入文件
/// </summary>
// [FM_Mono.IgnoreGen]
internal static class AssetActionLogger
{
    // 一次action开始时的监测数据
    public class ActionStartData
    {
        // 发生的顺序，单向递增，log是在异步结束时记录的，需要标记发生时的顺序
        public int order;
        public int frame;
        public float time;
        public long memory;
    }

    static string s_LogFilename;
    static bool s_Inited = false;
    static int s_Order = 0;

    static StreamWriter s_StreamWriter;
    private static HashSet<string> s_SyncLoadAsset;

    public static void Init()
    {
        // 临时打开测试，一般手机上不用开, 还不支持微信小游戏写文件
        if (s_Inited || !Application.isEditor) return;
        s_Inited = true;

        s_Order = 0;
        s_LogFilename = $"{StorageManager.persistentDataPath}/AssetLog.csv";
        StorageManager.CreateDirectoryIfNotExist(s_LogFilename);
        s_SyncLoadAsset = new HashSet<string>();

        // 在unity test里连续执行多次用例，这个log会append，不知道为什么
        s_StreamWriter = new StreamWriter(s_LogFilename, false);
        // 设置autoFlash才会在unity test里面输出到文件
        s_StreamWriter.AutoFlush = true;
        s_StreamWriter.WriteLine("AssetActionLoggerInit");
        s_StreamWriter.WriteLine(
            "order, action             , frame , fRange, timeS     , tRangeMS , dataTime    , GCAloc , path, userData");
    }


    public static void Dispose()
    {
        if (s_Inited)
        {
            s_StreamWriter?.WriteLine("AssetActionLoggerDispose\n");
            s_StreamWriter?.Close();
            s_StreamWriter = null;
            
            if (s_SyncLoadAsset.Count > 0)
            {
                var path = $"{StorageManager.persistentDataPath}/SyncLoadAssets.txt";
                using (var stream = new StreamWriter(path, false))
                {
                    foreach (var v in s_SyncLoadAsset)
                    {
                        stream.WriteLine(v);
                    }
                }
            }

        }

        s_Inited = false;
    }

    public static ActionStartData GetActionStartData()
    {
        if (s_Inited && !Application.isEditor)
        {
            // 暂停GC，进行精准内存统计，注意成对调用
            GarbageCollector.GCMode = GarbageCollector.Mode.Disabled;
        }

        Profiler.BeginSample("GetActionStartData");
        ActionStartData rt = null;
        if (s_Inited)
        {
            rt = new ActionStartData()
            {
                order = ++s_Order,
                frame = Time.frameCount,
                time = Time.realtimeSinceStartup,
                memory = GC.GetTotalMemory(false),
            };
        }

        Profiler.EndSample();
        return rt;
    }

    /// <summary>
    // 先获取order等开始信息，结束后再记录，用于解决异步顺序问题，
    // log按照完成顺序记录，通过order能知道发起顺序。
    // 同步也用同样的接口
    /// </summary>
    /// <param name="startData"></param>
    /// <param name="path">被转为id后的路径，其后缀是经过改名的，不一定是assetDB里文件的原始后缀</param>
    /// <param name="action"></param>
    /// <param name="userData"></param>
    public static void RecordAction(ActionStartData startData, string path, AssetBundleActionType action,
        string userData = "")
    {
        if (!s_Inited) return;
        if (startData == null)
            startData = GetActionStartData();
        
        if (action == AssetBundleActionType.RequestAsset ||
            action == AssetBundleActionType.LoadAssetAsync || 
            action == AssetBundleActionType.RequestAssetAsync)
        {
            // 空行分隔一下，好读点
            s_StreamWriter.WriteLine();
        }

        Profiler.BeginSample("RecordAction");
        if (action == AssetBundleActionType.LoadAsset)
            s_SyncLoadAsset.Add(path);
        
        if (path == null) path = "";
        long gcAlloc = GC.GetTotalMemory(false) - startData.memory;
        gcAlloc = Math.Max(gcAlloc, 0);
        string gcAllocStr = gcAlloc.ToString();
        // 异步统计是跨帧的，包含了其他因素，不具参考性
        if (action == AssetBundleActionType.LoadAssetAsync || action == AssetBundleActionType.BundleLoadAsync)
            gcAllocStr = "n/a";

        var s = string.Format(
            "{0,-5}, {2,-19}, {3,-6}, {4,-6}, {5,-10:#0.0000}, {6,-9:#0.000}, {9} , {7,-7}, {1}, {8}",
            startData.order, path,
            action.ToString(), startData.frame, Time.frameCount - startData.frame,
            startData.time, (Time.realtimeSinceStartup - startData.time) * 1000f, gcAllocStr, userData,
            System.DateTime.Now.ToString("HH:mm:ss.ff"));
        s_StreamWriter.WriteLine(s);
        Profiler.EndSample();

        if (!Application.isEditor)
        {
            // 继续GC，进行精准内存统计，注意成对调用
            GarbageCollector.GCMode = GarbageCollector.Mode.Enabled;
            //GC.Collect();
        }
    }
}