

using System;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using UnityEngine;
using UnityEngine.Networking;

public class GlobalLoadPanelMediator : TBaseUIMediator<GlobalLoadPanelSkin>
{
    public int totalSize = 0;
    private static bool isSuccessed = false;
    public GlobalLoadPanelMediator() : base(MediatorNames.GLOBAL_LOAD_PANEL,NotificationConst.SHOW_GLOBAL_LOAD_PANEL,NotificationConst.HIDE_GLOBAL_LOAD_PANEL)
    {
        RegisterNotificationHandler(NotificationConst.DOWNLOAD_SIZE_FAILED, OnDownloadSizeFailed, true);
        RegisterNotificationHandler(NotificationConst.DOWNLOADING_PERCENT, OnDownloadingPercent, true);
        RegisterNotificationHandler(NotificationConst.DOWNLOADING_TOTAL_SIZE, OnDownloadingTotalSize, true);
        RegisterNotificationHandler(NotificationConst.DOWNLOAD_FAILED, DownloadFailed, true);
        RegisterNotificationHandler(NotificationConst.DOWNLOAD_SUCCESS, DownloadSuccess, true);
        RegisterNotificationHandler(NotificationConst.DOWNLAOD_CACHEING_FAILED, DownlaodCacheingFailed, true);
        RegisterNotificationHandler(NotificationConst.DOWNLAOD_CACHEING_SUCCESS, DownlaodCacheingSuccess, true);
    }
    
    // 加载专用
    public void OnDownloadSizeFailed(object param)
    {
        // 下载失败
        //_view.Info.text = "获取下载文件大小失败";
    }

    public void OnDownloadingPercent(object param)
    {
        float percent = (float)param;
        _view.Bar.fillAmount = percent;
        _view.progress.text = $"{string.Format("%2F", percent * 100.0f)}%";
        //_view.Info.text = $"正在下载：{string.Format("%2F", totalSize * percent / 1024f)}KB/{string.Format("%2F", totalSize / 1024.0f)}KB";
    }

    public void OnDownloadingTotalSize(object param)
    {
        totalSize = (int)param;
    }

    public void DownloadFailed(object param)
    {
        //_view.Info.text = "下载失败";
    }

    public void DownloadSuccess(object param)
    {
        //_view.Info.text = "下载成功";
    }

    public void DownlaodCacheingFailed(object param)
    {
        //_view.Info.text = "缓存失败";
    }

    public void DownlaodCacheingSuccess(object param)
    {
        if (isSuccessed == true)
        {
            return;
        }

        isSuccessed = true;
        //_view.Info.text = "缓存完成，正在进入游戏";
        _view.Bar.fillAmount = 1.0f;
        _view.progress.text = "100%";
        // 更换状态机
        GameStateManager.instance.Input(GameStateConst.LOGIN, false);
    }
    
    

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

    }

    protected override void OnShowViewAndRefresh(object data)
    {

    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
        #if CUSTOM_DEBUG
        Debug.Log("关闭界面 GlobalLoadPanel!!");
        #endif
    }

    protected override void BeforeViewDispose()
    {
        base.BeforeViewDispose();
    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }
}
