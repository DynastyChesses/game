using TMPro;
using UnityEngine;

public class BaseGamePopupView :AbstractPopupView, IResourceUnit
{
    public string id
    {
        get
        {
            return gameObject.name;
        }
    }

    public GameObject returnBtn;
    public Animator viewAnim;

    public GameObject helpBtn;

    public BaseGamePopupView(GameObject viewObj, string returnBtnClickAudioId = null) : base(viewObj)
    {
        var rtnBtn = _viewSkin.GetSingleProperty( "returnBtn" );
        if( rtnBtn != null )
        {
            this.returnBtn = rtnBtn as GameObject;
            if( this.returnBtn == null )
                this.returnBtn = ( rtnBtn is UIButton btn ) ? btn.gameObject : null;
            if( this.returnBtn == null )
                this.returnBtn = ( rtnBtn is UGUIButtonEx btn ) ? btn.gameObject : null;
        }
        if (this.returnBtn != null)
        {
            // CommonButton btnComponent = CommonButton.CreateButton(this.returnBtn);
            // if (btnComponent != null)
            // {
            //     btnComponent.clickAudioName = returnBtnClickAudioId ?? AudioNameConst.COMMON_BUTTON_CLICK_CANCEL;
            // }
        }

        var help = _viewSkin.GetSingleProperty("helpBtn");
        if( help != null )
        {
            this.helpBtn = help as GameObject;
            if (this.helpBtn == null)
                this.helpBtn = (help is UIButton btn) ? btn.gameObject : null;
            if (this.helpBtn == null)
                this.helpBtn = (help is UGUIButtonEx btn) ? btn.gameObject : null;
        }

        var anim = _viewSkin.GetSingleProperty("viewAnim");
        if (anim != null)
        {
            this.viewAnim = anim as Animator;
        }
        
#if RG_WECHAT_MINIGAME
        UIMediator.BindingWxInputs(_viewSkin);  
#endif
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
        AudioFacade.instance.PlayClip(_audio, false);
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

    public bool isActive
    {
        get
        {
            return base.gameObject.activeInHierarchy;
        }
    }

    private BasePopupAnimation _popupAnimation;

    public override BasePopupAnimation popupAnimation
    {
        get
        {
            if (_popupAnimation == null)
                _popupAnimation = new ExpandPopupAnimation(this);
            return _popupAnimation;
        }
    }
}
