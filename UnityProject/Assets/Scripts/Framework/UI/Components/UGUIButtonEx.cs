using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum ButtonAnimMode
{
    Color = 1,
    SpriteSwap = 2,
    None = 999,
}

public class UGUIButtonEx : UnityEngine.UI.Button
{
    public float clickInterval = 0.1f;
    [HideInInspector]
    public bool messageDisabled = false;
    [HideInInspector]
    public bool mute = false;
    [HideInInspector]
    public string clickAudioName;

    [SerializeField]
    public Transform scaleTweemTarget;
    // 构造函数中不能使用load读配置，无法在代码层面做项目差异。项目可以设置preset创建一些模版
    public Vector3 pressScale = new Vector3(0.7f, 0.7f, 0.7f);
    public Vector3 normalScale = new Vector3(1, 1, 1);

    [SerializeField]
    public Graphic colorTweenTarget;
    [SerializeField]
    public Color pressColor = new Color(0.8f, 0.8f, 0.8f, 1);
    [SerializeField]
    public Color normalColor = new Color(1, 1, 1, 1);

    private Tweener _scaleTweener;
    private bool _press = false;

    public ButtonAnimMode animMode = ButtonAnimMode.Color;

    [SerializeField]
    public Sprite pressSprite;

    private double _lastClickTime = -1f;

    protected override void Awake()
    {
        base.Awake();
        // this.transition = Transition.None;
        if (colorTweenTarget == null)
        {
            colorTweenTarget = GetComponent<Graphic>();
        }
        if (scaleTweemTarget == null)
        {
            scaleTweemTarget = transform;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        RecoverNormalData();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        RecoverNormalData();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!IsActive() || !IsInteractable())
            return;
        if (messageDisabled || RealTimer.elapsedSeconds - _lastClickTime < clickInterval)
        {
            return;
        }
        if (onClick != null)
        {
            _lastClickTime = RealTimer.elapsedSeconds;
            onClick.Invoke();
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!_press)
        {
            _press = true;

            if (animMode == ButtonAnimMode.Color)
            {
                ResetColor();
                if (colorTweenTarget != null)
                {
                    colorTweenTarget.color = pressColor;
                }
            }
            else if (animMode == ButtonAnimMode.SpriteSwap)
            {
                var img = colorTweenTarget as Image;
                if (img != null)
                {
                    img.overrideSprite = pressSprite;
                }
            }

            if (scaleTweemTarget)
            {
                ResetScaleTweener();
                _scaleTweener = scaleTweemTarget.DOScale(pressScale, 0.1f);
                _scaleTweener.SetAutoKill(false);
            }
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _press = false;
        ResetScaleTweener();
        if (scaleTweemTarget)
        {
            scaleTweemTarget.localScale = pressScale;
            _scaleTweener = scaleTweemTarget.DOScale(normalScale, 0.1f);
        }
        _scaleTweener.SetAutoKill(false);

        if (animMode == ButtonAnimMode.Color)
        {
            ResetColor();
            if (colorTweenTarget != null)
            {
                colorTweenTarget.color = normalColor;
            }
        }
        else if (animMode == ButtonAnimMode.SpriteSwap)
        {
            var img = colorTweenTarget as Image;
            if (img != null)
            {
                img.overrideSprite = null;
            }
        }
    }

    private void ResetScaleTweener()
    {
        if (_scaleTweener != null && _scaleTweener.IsActive())
        {
            _scaleTweener.Kill();
            _scaleTweener = null;
        }
    }
    private void ResetColor()
    {
        if( colorTweenTarget == null ) return;
        colorTweenTarget.color = normalColor;
    }

    private void RecoverNormalData()
    {
        _press = false;
        if (animMode == ButtonAnimMode.Color)
        {
            if (colorTweenTarget != null)
            {
                colorTweenTarget.color = normalColor;
            }
        }
        else if (animMode == ButtonAnimMode.SpriteSwap)
        {
            var img = colorTweenTarget as Image;
            if (img != null)
            {
                img.overrideSprite = null;
            }
        }
        ResetScaleTweener();
        if (scaleTweemTarget)
        {
            scaleTweemTarget.localScale = normalScale;
        }
    }

    protected override void OnDestroy()
    {
        this.onClick.RemoveAllListeners();
        ResetScaleTweener();
        base.OnDestroy();
    }
}