using System;
using System.Collections.Generic;
using UnityEngine;

public partial class LoadingInitSettingState
{
    public static void RegisterCommonItem()
    {
        Dictionary<Type, Type> itemMaps = new Dictionary<Type, Type>()
        {
            {typeof(HeaderVO), typeof(Header)},
            {typeof(CityItemRenderVO), typeof(CityItemRender)},
            // 新增
            {typeof(MapVO), typeof(Map)},
            {typeof(Ground_TiledVO), typeof(Ground_Tiled)}
        };

        foreach (var item in itemMaps)
        {
            CommonItemRenderer.RegisterItem(item.Key, item.Value);
        }
    }
    
    // 
    public static void RegisterUIPanelConfig()
    {
        UIConfig.instance.AddPanelConfig(MediatorNames.IMAGE, new UIPanelConfig()
        {
            panelPath = "BasePanel",
            popupMode = PopupMode.NONE,
        });
        UIConfig.instance.AddPanelConfig(MediatorNames.GROUND, new UIPanelConfig()
        {
            panelPath = "Games/Ground/Map",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        UIConfig.instance.AddPanelConfig(MediatorNames.GLOBAL_LISTENER, new UIPanelConfig()
        {
            panelPath = "Assets/Arts/Base/GlobalListener",
            popupMode = PopupMode.NONE,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.GLOBAL_LOAD_PANEL, new UIPanelConfig()
        {
            panelPath = "Assets/Arts/Base/GlobalLoadPanel",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.MAIN_PANEL, new UIPanelConfig()
        {
            panelPath = "Games/UI/MainPanel",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.MATCHING_PANEL, new UIPanelConfig()
        {
            panelPath = "Games/UI/MatchingPanel",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.SETTING_MAIN_PANEL, new UIPanelConfig()
        {
            panelPath = "Games/UI/SettingMainPanel",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.COMMON_REWARD_PANEL_V2, new UIPanelConfig()
        {
            panelPath = "Games/Common/CommonRewardPanelV2",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.GAME_PLAY, new UIPanelConfig()
        {
            panelPath = "Games/osP1/GamePlay",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.LEVEL_SELECTION_U_I, new UIPanelConfig()
        {
            panelPath = "Games/osP1/LevelSelectionUI",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.LEVEL_WIN_U_I, new UIPanelConfig()
        {
            panelPath = "Games/osP1/LevelWinUI",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.REVIVE_U_I, new UIPanelConfig()
        {
            panelPath = "Games/osP1/ReviveUI",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.NEW_FEATURE_POPUP, new UIPanelConfig()
        {
            panelPath = "Games/osP1/NewFeaturePopup",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.NEW_ITEM_POPUP, new UIPanelConfig()
        {
            panelPath = "Games/osP1/NewItemPopup",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.SETTINGS_U_I, new UIPanelConfig()
        {
            panelPath = "Games/osP1/SettingsUI"
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.LEAVE_U_I, new UIPanelConfig()
        {
            panelPath = "Games/osP1/LeaveUI",
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.BUY_ITEM_POPUP, new UIPanelConfig()
        {
            panelPath = "Games/osP1/BuyItemPopup",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.LEVEL_LOSE_U_I, new UIPanelConfig()
        {
            panelPath = "Games/osP1/LevelLoseUI",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
        UIConfig.instance.AddPanelConfig(MediatorNames.BUY_STAMINA_POPUP, new UIPanelConfig()
        {
            panelPath = "Games/osP1/BuyStaminaPopup",
            popupMode = PopupMode.ADD_BLUR_MASK,
        });
        
    }

    public static void InitPopup()
    {
        PopupFacade.SetPopupImplement(new DefaultPopupFacadeImpl(
        new (Transform, int)[]{
            (UIManager.instance.popLayer, UIManager.POPUP_LAYER_ORDER),
            (UIManager.instance.topLayer, UIManager.TOP_LAYER_ORDER),
            (UIManager.instance.uiRoot, UIManager.MAX_LAYER_ORDER),
        },
        0,
        new CommonUIWidget[]
        {
            new AddMaskPopupAction(PopupMode.ADD_MASK, PopupPathConst.MASK_PATH),
            new AddHideMainUIMaskPopupAction(PopupMode.ADD_BLACK_MASK, PopupPathConst.MASK_PATH),
            new AddHideMainUIMaskPopupAction(PopupMode.ADD_BUILDING_MASK, PopupPathConst.GRADiIENT_MASK_PATH),
            new AddHideMainUIMaskPopupAction(PopupMode.HIDE_MAINUI_MASK, PopupPathConst.MASK_PATH),
        },
        new PopupQueueAction[]
        {
        },
        new BasePopupAction[]
        {
            new AutoHidePopupAction(PopupMode.AUTO_HIDE),
            new HideCameraPopupAction(),
            new AddBlurMaskPopupAction(PopupMode.ADD_BLUR_MASK, PopupPathConst.MASK_BLUR_PATH),
        }, 
        PopupMode.ANIMATED));
        UIManager.instance.AcquireBlurBack();//预加载一下
    }
}