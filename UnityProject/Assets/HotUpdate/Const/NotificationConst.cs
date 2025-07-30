using System;
using System.Collections.Generic;

public static partial class NotificationConst
{
    public const string SHOW_IMAGE = "ShowImage";
    public const string HIDE_IMAGE = "HideImage";
    public const string SHOW_GLOBAL_LISTENER = "ShowGlobalListener";
    public const string HIDE_GLOBAL_LISTENER = "HideGlobalListener";
    
    public const string SHOW_GROUND = "ShowGround";
    public const string HIDE_GROUND = "HideGround";

    public const string SHOW_GLOBAL_LOAD_PANEL = "ShowGlobalLoadPanel";
    public const string HIDE_GLOBAL_LOAD_PANEL = "HideGlobalLoadPanel";
    
    // 下载流程专用事件
    public const string DOWNLOAD_SIZE_FAILED = "DOWNLOAD_SIZE_FAILED";
    public const string DOWNLOADING_PERCENT = "DOWNLOADING_PERCENT";
    public const string DOWNLOADING_TOTAL_SIZE = "DOWNLOADING_TOTAL_SIZE";
    public const string DOWNLOAD_FAILED = "DOWNLOAD_FAILED";
    public const string DOWNLOAD_SUCCESS = "DOWNLOAD_SUCCESS";
    public const string DOWNLAOD_CACHEING_FAILED = "DOWNLAOD_CACHEING_FAILED";
    public const string DOWNLAOD_CACHEING_SUCCESS = "DOWNLAOD_CACHEING_SUCCESS";
    public const string RESOURCE_LOADED_SUCCESS = "RESOURCE_LOADED_SUCCESS";
    public const string RESOURCE_LOADED_ERROR = "RESOURCE_LOADED_ERROR";
    //
    public const string SHOW_NOTICE = "SHOW_NOTICE";
    public const string SHOW_MAIN_U_I = "ShowMainUI";
    public const string HIDE_MAIN_U_I = "HideMainUI";
    //
    public const string SHOW_MAINUI_INFO = "SHOW_MAINUI_INFO";
    public const string HIDE_MAINUI_INFO = "HIDE_MAINUI_INFO";
    
    // 网络状态相关
    public const string WARGAME_CONNECTED = "WARGAME_CONNECTED";
    public const string WARGAME_RECVMSG = "WARGAME_RECVMSG";
    
    
    // GamePlay核心 (核心种子)
    public const string CORE_SEED = "CORE_SEED";
    public const string SHOW_MATCHING_PANEL = "ShowMatchingPanel";
    public const string HIDE_MATCHING_PANEL = "HideMatchingPanel";
    // 用户操作信息
    public const string USER_LOGIN = "USER_LOGIN";
    public const string USER_LOGOUT = "USER_LOGOUT";
    public const string START_GAME = "START_GAME";
    // 构建地图
    public const string BUILD_MAP = "BUILD_MAP";
    
    // 接收消息
    public const string RECV_MSG = "RECV_MSG";
    public const string RECV_END = "RECV_END";
    
    public const string CHANGE_LANG = "CHANGE_LANG";


    
    // 常量检查器
    // 增加一个Unique检测
    private static List<int> check_list = new List<int>();
    public static void UniqueChecker()
    {
        // TODO
    }
    
    
    public const string SHOW_SETTING_MAIN_PANEL = "ShowSettingMainPanel";
    public const string HIDE_SETTING_MAIN_PANEL = "HideSettingMainPanel";
    public const string SHOW_COMMON_REWARD_PANEL_V2 = "ShowCommonRewardPanelV2";
    public const string HIDE_COMMON_REWARD_PANEL_V2 = "HideCommonRewardPanelV2";
    public const string SHOW_MAIN_PANEL = "ShowMainPanel";
    public const string HIDE_MAIN_PANEL = "HideMainPanel";
    public const string SHOW_GAME_PLAY = "ShowGamePlay";
    public const string HIDE_GAME_PLAY = "HideGamePlay";
    public const string SHOW_LEVEL_SELECTION_U_I = "ShowLevelSelectionUI";
    public const string HIDE_LEVEL_SELECTION_U_I = "HideLevelSelectionUI";
    public const string SHOW_LEVEL_WIN_U_I = "ShowLevelWinUI";
    public const string HIDE_LEVEL_WIN_U_I = "HideLevelWinUI";
    public const string SHOW_REVIVE_U_I = "ShowReviveUI";
    public const string HIDE_REVIVE_U_I = "HideReviveUI";
    public const string SHOW_NEW_FEATURE_POPUP = "ShowNewFeaturePopup";
    public const string HIDE_NEW_FEATURE_POPUP = "HideNewFeaturePopup";
    public const string SHOW_NEW_ITEM_POPUP = "ShowNewItemPopup";
    public const string HIDE_NEW_ITEM_POPUP = "HideNewItemPopup";
    public const string SHOW_SETTINGS_U_I = "ShowSettingsUI";
    public const string HIDE_SETTINGS_U_I = "HideSettingsUI";
    public const string SHOW_LEAVE_U_I = "ShowLeaveUI";
    public const string HIDE_LEAVE_U_I = "HideLeaveUI";
    public const string SHOW_BUY_ITEM_POPUP = "ShowBuyItemPopup";
    public const string HIDE_BUY_ITEM_POPUP = "HideBuyItemPopup";
    public const string SHOW_LEVEL_LOSE_U_I = "ShowLevelLoseUI";
    public const string HIDE_LEVEL_LOSE_U_I = "HideLevelLoseUI";
    public const string SHOW_BUY_STAMINA_POPUP = "ShowBuyStaminaPopup";
    public const string HIDE_BUY_STAMINA_POPUP = "HideBuyStaminaPopup";
    
    
    // 棋类游戏
    public const string LOAD_GAME_MAP = "LOAD_GAME_MAP";
}