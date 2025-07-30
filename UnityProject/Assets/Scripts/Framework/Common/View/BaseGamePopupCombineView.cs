using System.Collections.Generic;
using UnityEngine;

public class BaseGamePopupCombineView : AbstractPopupView, IResourceUnit
{
    public string id
    {
        get
        {
            return gameObject.name;
        }
    }

    public GameObject returnBtn;

    public BaseGamePopupCombineView(GameObject viewObj, string returnBtnClickAudioId = null) : base(viewObj)
    {
        this.returnBtn = _viewSkin.GetSingleProperty("returnBtn") as GameObject;
    }

    private GameObject _closeBtn;
    private string _audio;
    public void SetCloseBtn(GameObject go,string audio = null)
    {
        if (_closeBtn == null)
        {
            _closeBtn = go;
            UIEventListener.OnClick(_closeBtn).AddListener(OnCloseBtnClick);
            _audio = string.IsNullOrEmpty(audio) ? "button_return_01" : audio;
        }
    }

    private void OnCloseBtnClick(GameObject go)
    {
        // TODO
    }

    public override void Dispose()
    {
        if (_closeBtn != null)
        {
            UIEventListener.OnClick(_closeBtn).RemoveListener(OnCloseBtnClick);
            _closeBtn = null;
        }
        base.Dispose();
    }
    
    private BasePopupAnimation _popupAnimation; 
    public override BasePopupAnimation popupAnimation
    {
        get => _popupAnimation;
        
    }
    
    protected static UIPanelConfig _uiConfig = null;
    protected static Dictionary<uint, object> GetParamDic()
    {
        Dictionary<uint, object> paramDic = new Dictionary<uint, object>();
        if ((_uiConfig.popupMode & PopupMode.ADD_TOP_RESOURCE_VIEW) != 0)
        {
            paramDic.Add(PopupMode.ADD_TOP_RESOURCE_VIEW, _uiConfig.topInfoMode);
        }

        if ((_uiConfig.popupMode & PopupMode.ANIMATED) != 0)
        {
            var type = _uiConfig.popupAnimationType;
            paramDic.Add(PopupMode.ANIMATED, _uiConfig.popupAnimationDuration);
        }
        
        return paramDic;
    }

    protected static void GetUIConfig(string key)
    {
        _uiConfig = UIConfig.instance.GetPanelConfig(key);
        if (_uiConfig == null)
        {
            Logger.Error($"Not Find UIConfig Of {key}");
        }
    }
    
    public void Hide()
    {
        if(PopupFacade.instance.HasPopup(this))
            PopupFacade.instance.RemovePopup(this);
    }
    
}
