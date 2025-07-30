using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PreDownloadChecker
{
    private int _waitPreDownloadTaskId;
    private List<string> _downloadFileList;
    private Action _finishedCallback;
    private float _checkLogTime = 0;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="downloadFileList">要判断是否下载完成的文件列表</param>
    /// <param name="finishedCallback">下载完成回调</param>
    public PreDownloadChecker(List<string> downloadFileList, Action finishedCallback)
    {
        _downloadFileList = downloadFileList;
        _finishedCallback = finishedCallback;
    }

    public void StartCheck()
    {
        _checkLogTime = Time.realtimeSinceStartup;
        _waitPreDownloadTaskId = EquineScheduler.AddTimeLimitUpdator(1, CheckRestFileList);
    }

    /// <summary>
    /// 等待预下载列表完成
    /// </summary>
    public void CheckRestFileList(int a, object o, UpdateTimeInfo timeInfo)
    {
        // 预下载文件列表
        var downloadFileList = _downloadFileList;
        for (var i = downloadFileList.Count - 1; i >= 0; i--)
        {
            var currFilePath = downloadFileList[i];
            var checkPath = Path.Combine(StorageManager.persistentDataPath,
                ResourcePathConst.REMOTE_ASSET_DIRECTORY, 
                ResourceHelper.GetRuntimeSavePath(currFilePath, "")); 
            var fileExist = StorageManager.Exists(checkPath, true);
            if (fileExist)
            {
                Debug.Log($"检查到下载文件完成: {currFilePath}");
                downloadFileList.RemoveAt(i);
            }
        }

        // 固定时间间隔输出为下载完的文件
        if (Time.realtimeSinceStartup - _checkLogTime > 1 && downloadFileList.Count > 0)
        {
            _checkLogTime = Time.realtimeSinceStartup;
            var str = "";
            foreach (var v in downloadFileList)
            {
                str += $"{v}\n";
            }
            Debug.LogWarning($"为完成的preload:{str}");
        }

        if (downloadFileList.Count == 0)
        {
            Debug.Log("预下载文件全部完成，准备启动游戏");
            EquineScheduler.RemoveLimitUpdator(ref _waitPreDownloadTaskId);
            if (_waitPreDownloadTaskId != 0)
            {
                Debug.LogError($"预下载文件检查task移除失败, id: {_waitPreDownloadTaskId}");
            }

            var tempCallback = _finishedCallback;
            _finishedCallback = null;
            tempCallback?.Invoke();
        }
        else
        {
            Debug.Log($"剩余 {downloadFileList.Count}未完成下载");
        }
    }
}