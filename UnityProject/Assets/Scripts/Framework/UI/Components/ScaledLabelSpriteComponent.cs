using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class ScaledLabelSpriteComponent :LabelSpriteComponent
{
	public bool withoutTweenScale = false;
	public string clickAudioId = null;

    [System.NonSerialized]
    public bool mute = false;

	private const string CLICK_EFFECT = "ClickEffect";
//
//
//     private static Dictionary<string, Queue<GameObject>> highlightCach = new Dictionary<string, Queue<GameObject>>
// 	{
//         {HighlightType.WhiteMask.ToString(), new Queue<GameObject>()},
//         {HighlightType.Bright.ToString(), new Queue<GameObject>()},
//         {HighlightType.TweenColor.ToString(), new Queue<GameObject>()},
//         {CLICK_EFFECT, new Queue<GameObject>()}
//     };
//
// 	public static void ClearAllCacheObject()
// 	{
// 		Dictionary<string, Queue<GameObject>>.Enumerator iter = highlightCach.GetEnumerator();
// 		while(iter.MoveNext())
// 		{
// 			Queue<GameObject> queue = iter.Current.Value;
// 			while(queue.Count > 0)
// 			{
// 				GameObject cache = queue.Dequeue();
// 				if (cache != null)
// 				{
// 					GameObject.Destroy(cache);
// 				}
// 			}
// 		}
// 	}
//
//     private static void RecycleHightlightGO(string type, GameObject go)
//     {
// 		Queue<GameObject> goQueue = highlightCach[type];
//         go.transform.parent = UIContainer.effectLayer.transform;
// //        go.transform.parent = null;
// 		NGUITools.MarkParentAsChanged(go);
//         go.SetActive(false);
//         goQueue.Enqueue(go);
//     }
//     private static GameObject GetCachedHighlightGO(string type, int layer)
//     {
// 		Queue<GameObject> goQueue = highlightCach[type];
//
//         GameObject cachedGO = goQueue.Count > 0 ? goQueue.Dequeue() : null;
//
//         if(cachedGO != null)
//         {
//             cachedGO.SetActive(true);
//         }
//         else
//         {
//             if(type == HighlightType.WhiteMask.ToString())
//             {
//                 cachedGO = new GameObject("HighlightSprite_WhiteMask");
//                 cachedGO.layer = layer;
//                 UITexture texture = cachedGO.AddComponent<UITexture>();
//                 texture.mainTexture = Texture2D.whiteTexture;
//                 texture.alpha = 0.3f;
//             }
//             else if(type == HighlightType.Bright.ToString() || type == HighlightType.TweenColor.ToString())
//             {
//                 cachedGO = new GameObject("HighlightSprite_Bright");
//                 cachedGO.layer = layer;
//                 UISprite sprite = cachedGO.AddComponent<UISprite>();
//                 sprite.effect = UISprite.Effect_Highlight;
//             }
//             else if(type == CLICK_EFFECT)
//             {
//                 cachedGO = new GameObject("ButtonClickEffect");
//                 cachedGO.layer = layer;
//                 UISprite sprite = cachedGO.AddComponent<UISprite>();
//                 sprite.effect = UISprite.Effect_Highlight;
//                 TweenScale tweenScale = cachedGO.AddComponent<TweenScale>();
// //                tweenScale.from = Vector3.one;
// //                tweenScale.to = Vector3.one * 2;
//                 tweenScale.duration = 0.3f;
//                 tweenScale.style = UITweener.Style.Once;
//                 tweenScale.method = UITweener.Method.EaseOut;
//                 TweenAlpha tweenAlpah = cachedGO.AddComponent<TweenAlpha>();
//                 tweenAlpah.from = 1f;
//                 tweenAlpah.to = 0.01f;
//                 tweenAlpah.duration = 0.3f;
//                 tweenAlpah.style = UITweener.Style.Once;
//                 tweenAlpah.method = UITweener.Method.EaseOut;
//             }
//         }
//         return cachedGO;
//     }
//
//     public enum HighlightType
//     {
// 		None = -1,
//         WhiteMask = 0,
//         Bright = 1,
//         TweenColor = 2
//     }
//
//     /// <summary>
//     /// 理论上，子物体的pivot就应该永远和父物体保持一致，NGUI好像也是按照这个原则来设计的?
//     /// 因为tweenTarget是要以中心为基准来缩放，当tweenTarget的pivot不是中心时，缩放前要先把tweenTarget的pivot设置为中心，而 此时，子物体的pivot和父物体不同，相对位置就会改变。
//     /// </summary>
//     [Tooltip("tweenTarget有子物体时，请保持子物体的pivot和父物体一致")]
//     public Transform tweenTarget;
//     public HighlightType highlightType = HighlightType.Bright;
//
// 	private bool _clickEffect = true;
//
// 	public bool clickEffect
// 	{
// 		get { return _clickEffect; }
// 		set { _clickEffect = value; }
// 	}
// //    Color normalColor = new Color(200f / 255f, 200f / 255f, 200f / 255f, 1f);
// //    Color pressedColor = Color.white;
//
//     public Vector3 pressed
//     {
//         get { return _pressed; }
//         set { _pressed = value; }
//     }
//     private Vector3 _pressed = new Vector3(1.08f, 1.08f, 1.08f);
//     float duration = 0.2f;
//     
//     Vector3 mScale;
//     bool mStarted = false;
//     bool mIsPressing = false;
//     Transform highlightSpriteTransform;
//
//     UIWidget.Pivot originPivot;
// 	private int _oriWidth;
// 	private int _oriHeight;
//     BoxCollider bgSpriteBoxCollider;
//     Vector3 originColliderOffsetToSpriteCenter;
//     Vector3 originColliderCenter;
//     Vector3 originColliderSize;
//
//     private string _disableTips;
//     public string disableTips
//     {
//         get { return _disableTips; }
//         set { _disableTips = value; }
//     }
//
//     public void UpdateScale()
//     {
//         if (tweenTarget != null)
//         {
//             mScale = tweenTarget.localScale;
//         }
//     }
//
//     [ContextMenu("Init")]
//     void Init()
//     {
//         if(this.bgSprite == null)
//             this.bgSprite = GetComponent<UISprite>();
//         if(this.bgSprite == null)
//             this.bgSprite = GetComponentInChildren<UISprite>();
//         if(this.bgSprite == null)
//             this.bgSprite = gameObject.AddComponent<UISprite>();
//
// //        int childCount = this.bgSprite.transform.childCount;
// //        Transform[] children = new Transform[childCount];
// //        for(int i = 0; i < childCount; ++i)
// //        {
// //            children[i] = this.bgSprite.transform.GetChild(i);
// //        }
// //        for(int i = 0; i < childCount; ++i)
// //        {
// //            children[i].parent = this.bgSprite.transform.parent;
// //        }
// //        this.bgSprite.pivot = UIWidget.Pivot.Center;
// //        for(int i = 0; i < childCount; ++i)
// //        {
// //            children[i].parent = this.bgSprite.transform;
// //        }
//
//         if(this.tweenTarget == null && !withoutTweenScale)
//             this.tweenTarget = transform;
//     }
//
//     void Start ()
//     {
//         if(Application.isEditor && !Application.isPlaying)
//         {
//             Init();
//             return;
//         }
//         if (!mStarted)
//         {
//             mStarted = true;
//             if (tweenTarget == null && !withoutTweenScale) 
//             {
//                 tweenTarget = transform;
//             }
//             UpdateScale();
// //            if(0.9f < bgSprite.aspectRatio && bgSprite.aspectRatio < 1.15f)
// 			//            else
// 			//                clickEffect = false;
// 			if (bgSprite != null)
// 			{
// 				originPivot = this.bgSprite.pivot;
// 				bgSpriteBoxCollider = this.bgSprite.GetComponent<Collider>() as BoxCollider;
// 				if (bgSpriteBoxCollider != null)
// 				{
// 					originColliderOffsetToSpriteCenter = bgSpriteBoxCollider.center - bgSprite.localCenter;
// 					originColliderCenter = bgSpriteBoxCollider.center;
// 					originColliderSize = bgSpriteBoxCollider.size;
// 				}
// 			}
// 			else
// 			{
// 				Debug.LogError(this.gameObject + " bgSprite is null");
// 			}
// //            mWidget = tweenTarget.GetComponent<UIWidget>();
// //            if(mWidget != null)
// //                mWidget.color = normalColor;
// //            else
// //                Debug.LogError("mWidget is null");
//         }
//     }
//     
// 	void OnClick()
// 	{
//         if (!mute)
//         {
//             AudioFacade.PlayOnce(string.IsNullOrEmpty(clickAudioId) ? GlobalConfig.scaleButtonDefaultClickAudio : clickAudioId);
//         }
// 	}
//     
//     void OnDisable ()
//     {
//         if (mStarted && tweenTarget != null)
//         {
//             TweenScale ts = tweenTarget.GetComponent<TweenScale>();
// //            TweenColor tc = tweenTarget.GetComponent<TweenColor>();
//             
//             if (ts != null)
//             {
//                 ts.value = mScale;
//                 ts.enabled = false;
//
// //                tc.value = normalColor;
// //                tc.enabled = false;
//             }
//         }
//
//         if (highlightSpriteTransform != null)
//         {
//             Destroy(highlightSpriteTransform.gameObject);
//             highlightSpriteTransform = null;
//         }
//
//         if (null != _lastClickEffectTweenScale)
//         {
// 	        _lastClickEffectTweenScale.Sample(1, true);
// 	        _lastClickEffectTweenScale.enabled = false;
//             EventDelegate.Execute(_lastClickEffectTweenScale.onFinished);
//         }
//
//         //if (_lastClickEffectTweenScale != null)
//         //{
//         //    _lastClickEffectTweenScale.onFinished.Clear();
//         //    if (_lastClickEffectTweenScale.gameObject != null)
//         //    {
//         //        Destroy(_lastClickEffectTweenScale.gameObject);
//         //    }
//         //    _lastClickEffectTweenScale = null;
//         //}
//     }
//
//     private TweenScale _lastClickEffectTweenScale;
//     void OnPress (bool isPressed)
//     {
//         if (enabled)
//         {
//             if (!mStarted) Start();
// //            EnsureHighlightGameObject();
//             if(disableBg)
//             {
//                 return;
//             }
// 	        if (tweenTarget != null)
// 	        {
// 		        TweenScale.Begin(tweenTarget.gameObject, duration, isPressed ? Vector3.Scale(mScale, pressed) : mScale).method
// 			        = UITweener.Method.EaseInOut;
// 	        }
// 	        if(isPressed)
//             {
//                 if(mIsPressing)
//                     return;
//                 mIsPressing = true;
//                 if(_lastClickEffectTweenScale != null)
//                 {
//                     _lastClickEffectTweenScale.onFinished.Clear();
//                     if(_lastClickEffectTweenScale.gameObject != null)
//                     {
//                         RecycleHightlightGO(CLICK_EFFECT, _lastClickEffectTweenScale.gameObject);
//                     }
//                     _lastClickEffectTweenScale = null;
//                 }
//                 
//                 if (null != bgSprite && bgSprite.gameObject.activeSelf && bgSprite.enabled)
//                 {
//                     UIUtil.SetPivot(bgSprite, UIWidget.Pivot.Center);
//                     //                this.bgSprite.pivot = UIWidget.Pivot.Center;
//                     this.bgSprite.ResizeCollider();
//                     if (this.bgSpriteBoxCollider != null)
//                     {
//                         this.bgSpriteBoxCollider.center = originColliderOffsetToSpriteCenter;
//                         this.bgSpriteBoxCollider.size = originColliderSize;
//                     }
//
//                     if (highlightType != HighlightType.None)
//                     {
//                         GameObject highlightGO = GetCachedHighlightGO(highlightType.ToString(), this.gameObject.layer);
//                         highlightSpriteTransform = highlightGO.transform;
//                         highlightGO.SetActive(true);
//                         if (highlightType == HighlightType.WhiteMask)
//                         {
//                             UITexture texture = highlightGO.GetComponent<UITexture>();
//                             texture.pivot = this.bgSprite.pivot;
//                             texture.width = this.bgSprite.width;
//                             texture.height = this.bgSprite.height;
//                             texture.depth = this.bgSprite.depth + 1;
//                         }
//                         else if (highlightType == HighlightType.Bright || highlightType == HighlightType.TweenColor)
//                         {
//                             UISprite sprite = highlightGO.GetComponent<UISprite>();
//                             sprite.atlas = this.bgSprite.atlas;
//                             sprite.spriteName = this.bgSprite.spriteName;
//                             sprite.color = this.bgSprite.color;
//                             sprite.type = this.bgSprite.type;
//                             sprite.pivot = this.bgSprite.pivot;
//                             sprite.width = this.bgSprite.width;
//                             sprite.height = this.bgSprite.height;
//                             sprite.fillAmount = bgSprite.fillAmount;
//                             sprite.centerType = bgSprite.centerType;
//                             sprite.fillDirection = bgSprite.fillDirection;
//                             sprite.flip = bgSprite.flip;
//                             sprite.depth = this.bgSprite.depth + 1;
//                         }
//                         highlightGO.layer = tweenTarget != null ? tweenTarget.gameObject.layer : bgSprite.gameObject.layer;
//                         highlightGO.transform.parent = tweenTarget != null ? tweenTarget : bgSprite.transform;
//                         highlightGO.transform.localPosition = Vector3.zero;
//                         highlightGO.transform.localEulerAngles = Vector3.zero;
//                         highlightGO.transform.localScale = Vector3.one;
//                         NGUITools.MarkParentAsChanged(highlightGO);
//                     }
// 	            }
//             }
//             else
//             {
//                 mIsPressing = false;
//                 if(highlightSpriteTransform != null)
//                 {
//                     RecycleHightlightGO(highlightType.ToString(), highlightSpriteTransform.gameObject);
// 	                highlightSpriteTransform = null;
//                 }
//
//                 if (null != bgSprite && bgSprite.gameObject.activeSelf && bgSprite.enabled && clickEffect)
//                 {
//                     GameObject clickEffectGO = GetCachedHighlightGO(CLICK_EFFECT, this.gameObject.layer);
//                     UISprite sprite = clickEffectGO.GetComponent<UISprite>();
//                     sprite.atlas = this.bgSprite.atlas;
//                     sprite.spriteName = this.bgSprite.spriteName;
//                     sprite.color = this.bgSprite.color;
//                     sprite.type = this.bgSprite.type;
//                     sprite.width = this.bgSprite.width;
//                     sprite.height = this.bgSprite.height;
//                     sprite.fillAmount = bgSprite.fillAmount;
//                     sprite.centerType = bgSprite.centerType;
//                     sprite.fillDirection = bgSprite.fillDirection;
//                     sprite.flip = bgSprite.flip;
//                     sprite.depth = this.bgSprite.depth + 1;
//
//                     sprite.pivot = UIWidget.Pivot.Center;
//
// 	                _oriWidth = sprite.width;
// 	                _oriHeight = sprite.height;
//                     clickEffectGO.layer = tweenTarget != null?  tweenTarget.gameObject.layer : bgSprite.gameObject.layer;
//                     clickEffectGO.transform.position = tweenTarget != null ? tweenTarget.position : bgSprite.transform.position;
//                     clickEffectGO.transform.localEulerAngles = tweenTarget != null ? tweenTarget.localEulerAngles : bgSprite.transform.localEulerAngles;
//                     clickEffectGO.transform.localScale = Vector3.one;
//                     clickEffectGO.transform.parent = UIContainer.effectLayer.transform;
//                     NGUITools.MarkParentAsChanged(clickEffectGO);
//
//                     _lastClickEffectTweenScale = clickEffectGO.GetComponent(typeof(TweenScale)) as TweenScale;
//                     _lastClickEffectTweenScale.from = pressed;
//                     float targetScaleX = (float)(sprite.width + 150) / sprite.width;
//                     float targetScaleY = (float)(sprite.height + 150) / sprite.height;
//                     _lastClickEffectTweenScale.to = new Vector3(targetScaleX, targetScaleY, 1f);
//                     _lastClickEffectTweenScale.ResetToBeginning();
//                     _lastClickEffectTweenScale.PlayForward();
//                     TweenAlpha tweenAlpha = clickEffectGO.GetComponent(typeof(TweenAlpha)) as TweenAlpha;
//                     tweenAlpha.ResetToBeginning();
//                     tweenAlpha.PlayForward();
//                     EventDelegate.Add(_lastClickEffectTweenScale.onFinished, () =>
//                     {
//                         _lastClickEffectTweenScale = null;
// 	                    int newWidth = this.bgSprite.width;
// 	                    int newHeight = this.bgSprite.height;
// 	                    this.bgSprite.width = _oriWidth;
// 	                    this.bgSprite.height = _oriHeight;
//                         UIUtil.SetPivot(bgSprite, originPivot);
// //                        this.bgSprite.pivot = originPivot;
// 	                    this.bgSprite.width = newWidth;
// 	                    this.bgSprite.height = newHeight;
//                         if(bgSpriteBoxCollider != null)
//                         {
//                             this.bgSpriteBoxCollider.center = originColliderCenter;
//                             this.bgSpriteBoxCollider.size = originColliderSize;
//                         }
//                         if(clickEffectGO != null)
//                         {
//                             RecycleHightlightGO(CLICK_EFFECT, clickEffectGO);
//                             clickEffectGO = null;
//                         }
//                         else
//                         {
//                             Debug.LogError("clickEffectGO == null，说明onFinished调用了两次");
//                         }
//                     }, true);
//                 }
//             }
// //            TweenColor.Begin(tweenTarget.gameObject, duration, isPressed ? pressedColor : normalColor).method = UITweener.Method.EaseInOut;
//         }
//     }

//    void EnsureHighlightGameObject()
//    {
//        if(highlightSpriteTransform == null)
//        {
//            if(highlightType == HighlightType.WhiteMask)
//            {
//                GameObject textureGO = new GameObject("HighlightSprite_WhiteMask");
//                UITexture texture = textureGO.AddComponent<UITexture>();
//                texture.mainTexture = Texture2D.whiteTexture;
//                texture.width = this.bgSprite.width;
//                texture.height = this.bgSprite.height;
//                texture.depth = this.bgSprite.depth + 1;
//                texture.alpha = 0.3f;
//
//                highlightSpriteTransform = textureGO.transform;
//            }
//            else if(highlightType == HighlightType.Bright)
//            {
//                highlightSpriteTransform = new GameObject("HighlightSprite_Bright").transform;
//                UISprite sprite = highlightSpriteTransform.gameObject.AddComponent<UISprite>();
//                sprite.atlas = this.bgSprite.atlas;
//                sprite.spriteName = this.bgSprite.spriteName;
//                sprite.pivot = this.bgSprite.pivot;
//                sprite.width = this.bgSprite.width;
//                sprite.height = this.bgSprite.height;
//                sprite.depth = this.bgSprite.depth + 1;
//                sprite.effect = UISprite.Effect_Highlight;
//            }
//            else if(highlightType == HighlightType.TweenColor)
//            {
//                
//            }
//            highlightSpriteTransform.gameObject.layer = tweenTarget.gameObject.layer;
//            highlightSpriteTransform.parent = tweenTarget;
//            highlightSpriteTransform.localPosition = Vector3.zero;
//            highlightSpriteTransform.localScale = Vector3.one;
//            highlightSpriteTransform.gameObject.SetActive(false);
//        }
//    }
}
