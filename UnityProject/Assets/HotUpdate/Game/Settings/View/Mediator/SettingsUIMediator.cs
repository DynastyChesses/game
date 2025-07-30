

using System;
using System.Collections.Generic;
using HotUpdate.osP1;
using HotUpdate.osP1.Save;
using UnityEngine;
using UnityEngine.UI;

public enum SettingsState
{
    InLevelSelection,
    InGame,
}

public class SettingsUIMediator : TBaseUIMediator<SettingsUISkin>
{
    private Image _musicOn;
    private Image _musicOff;
    private Image _soundOn;
    private Image _soundOff;
    private SettingsState _state;
    
    
    public SettingsUIMediator() : base(MediatorNames.SETTINGS_U_I,NotificationConst.SHOW_SETTINGS_U_I,NotificationConst.HIDE_SETTINGS_U_I)
    {
        
    }

    protected override void OnCreateView(object data)
    {
        base.OnCreateView(data);

        _musicOn = _view.btnMusic.transform.GetChild(0).GetComponent<Image>();
        _musicOff = _view.btnMusic.transform.GetChild(1).GetComponent<Image>();
        
        _soundOn = _view.btnSound.transform.GetChild(0).GetComponent<Image>();
        _soundOff = _view.btnSound.transform.GetChild(1).GetComponent<Image>();
        
        

        var isMusicOn = PlayerSave.instance.PlayerSettings.BoolList[PlayerSettings.IsMusicOn];
        if (isMusicOn)
        {
            _musicOn.enabled = true;
            _musicOff.enabled = false;
        }
        else
        {
            _musicOn.enabled = false;
            _musicOff.enabled = true;
        }
        
        var isSoundOn = PlayerSave.instance.PlayerSettings.BoolList[PlayerSettings.IsSoundOn];
        if (isSoundOn)
        {
            _soundOn.enabled = true;
            _soundOff.enabled = false;
        }
        else
        {
            _soundOn.enabled = false;
            _soundOff.enabled = true;
        }
        
        UIEventListener.OnClick(_view.btnMusic).AddListener(OnBtnMusicClick);
        UIEventListener.OnClick(_view.btnSound).AddListener(OnBtnSoundClick);
        UIEventListener.OnClick(_view.btnHome).AddListener(OnBtnHomeClick);
        UIEventListener.OnClick(_view.btnPrivacyPolicy).AddListener(OnBtnPrivacyPolicyClick);
        UIEventListener.OnClick(_view.btnClose).AddListener(OnBtnCloseClick);

    }

    protected override void OnShowViewAndRefresh(object data)
    {
        _state = (SettingsState)data;
        if (_state == SettingsState.InLevelSelection)
        {
            _view.btnHome.SetActive(false);
        }
        else
        {
            _view.btnHome.SetActive(true);
        }
    }


    protected override void BeforeHideView()
    {
        base.BeforeHideView();
    }

    protected override void BeforeViewDispose()
    {
        base.BeforeViewDispose();
        
        UIEventListener.OnClick(_view.btnMusic).RemoveListener(OnBtnMusicClick);
        UIEventListener.OnClick(_view.btnSound).RemoveListener(OnBtnSoundClick);
        UIEventListener.OnClick(_view.btnHome).RemoveListener(OnBtnHomeClick);
        UIEventListener.OnClick(_view.btnPrivacyPolicy).RemoveListener(OnBtnPrivacyPolicyClick);
        UIEventListener.OnClick(_view.btnClose).RemoveListener(OnBtnCloseClick);

    }

    protected override void DoOnReturnMaskClick()
    {
        HideView();
        base.DoOnReturnMaskClick();
    }

    private void OnBtnMusicClick(GameObject go)
    {
        var result = PlayerSave.instance.PlayerSettings.ReverseMusic();
        if (result)
        {
            _musicOn.enabled = true;
            _musicOff.enabled = false;
        }
        else
        {
            _musicOn.enabled = false;
            _musicOff.enabled = true;
        }
    }

    private void OnBtnSoundClick(GameObject go)
    {
        var result = PlayerSave.instance.PlayerSettings.ReverseSound();
        if (result)
        {
            _soundOn.enabled = true;
            _soundOff.enabled = false;
        }
        else
        {
            _soundOn.enabled = false;
            _soundOff.enabled = true;
        }
    }

    private void OnBtnHomeClick(GameObject go)
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_LEAVE_U_I);
    }

    private void OnBtnPrivacyPolicyClick(GameObject go)
    {
        
    }

    private void OnBtnCloseClick(GameObject go)
    {
        ApplicationFacade.instance.SendNotification(NotificationConst.HIDE_SETTINGS_U_I);
    }
}
