using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class SceneScheduler
{
	public static bool inScene = false;

	public static string currentSceneName;

	public static bool inEnterGameGuide = false;
	
	private static Dictionary<string, object> _globalContext = new Dictionary<string, object>();

	private static string _loadingSceneName;

	private static Dictionary<string, ISceneManager> _controllerMap = new Dictionary<string, ISceneManager>();

	private static List<IDisposable> _autoDisposableList = new List<IDisposable>();

	private static RenderTexture _transitionTex;
	
	private static int _switchSceneLimitUpdator = 0;
	public static bool switching => EquineScheduler.IsValid(_switchSceneLimitUpdator);

	public static bool _loadingPanelShowFinish = false;
	
	// 判断服务器时间差值
	public static long last_time = -1;
	public const long GC_TIME = 3600;

	public static bool TryGetGlobalContext(string key, out object value)
	{
		return _globalContext.TryGetValue(key, out value);
	}

	public static void SetGlobalContext(string key, object value)
	{
		_globalContext[key] = value;
	}

	public static void ClearGlobalContext(string key)
	{
		_globalContext.Remove(key);
	}

	public static bool HashSceneController(string sceneName)
	{
		return _controllerMap.ContainsKey(sceneName);
	}

	public static void RegisterSceneController(ISceneManager manager)
	{
		if (!_controllerMap.ContainsKey(manager.sceneName))
		{
            manager.OnRegister();
			_controllerMap.Add(manager.sceneName, manager);
		}
	}

	public static void UnRegisterSceneController(ISceneManager manager)
	{
		if (_controllerMap.ContainsKey(manager.sceneName))
		{
            manager.OnRemove();
			_controllerMap.Remove(manager.sceneName);
		}
	}
	
	private static void UnRegisterAllSceneController()
	{
		foreach (var manager in _controllerMap)
		{
			manager.Value.OnRemove();
		}
		_controllerMap.Clear();
	}

	public static void AddAutoDisposeObject(IDisposable disposable)
	{
		if (disposable != null)
		{
			_autoDisposableList.Add(disposable);
		}
	}

	public static void RemoveAutoDisposeObject(IDisposable dispoable)
	{
		if (dispoable != null && _autoDisposableList.Contains (dispoable))
		{
			_autoDisposableList.Remove (dispoable);
		}
	}

	public static ISceneManager loadingSceneManager
	{
		get
		{
			_controllerMap.TryGetValue(_loadingSceneName, out ISceneManager manager);
			return manager;
		}
	}
	
	public static ISceneManager currentSceneManager
	{
		get
		{
			_controllerMap.TryGetValue(currentSceneName, out ISceneManager manager);
			return manager;
		}
	}
	
	private static double _transitionStartTime = 0;
	public static float SwitchFixedDuration = 0.3f;

    public static void LoadSceneByName(string sceneName, object switchContext = null, bool needAni = false)
	{
		// TODO
		if (EquineScheduler.IsValid(_switchSceneLimitUpdator))
			return;
		
		if (needAni)
		{
			// 防止多次
			if (false)
			{
				return;
			}

			var dur = SwitchFixedDuration;
			float radix = 1.414f;
			Vector3 curCameraPos = UIManager.instance.mainCamera.gameObject.transform.localPosition;
			float oriCameraOffset = 20f;
			curCameraPos.y += oriCameraOffset;
			curCameraPos.z -= oriCameraOffset * radix / 2;
			curCameraPos.x -= oriCameraOffset * radix / 2;
			Sequence seqAct = DOTween.Sequence();
			seqAct.Append(UIManager.instance.mainCamera.gameObject.transform.DOMove(curCameraPos, dur));
			seqAct.AppendCallback(() =>
			{
				_switchSceneLimitUpdator = EquineScheduler.RunYieldProcedure(DoSwitchScene(sceneName, switchContext));
			});
		}
		else
		{
			_switchSceneLimitUpdator = EquineScheduler.RunYieldProcedure(DoSwitchScene(sceneName, switchContext));
		}
	}

    public static void ForceLeaveCurrentSceneAndClearAll()
    {
	    EquineScheduler.RemoveLimitUpdator(ref _switchSceneLimitUpdator);
	    DoClearScene(null, true, true);
	    _loadingSceneName = null;
	    inScene = false;
	    currentSceneName = null;
	    _globalContext.Clear();
	    UnRegisterAllSceneController();
    }

    private static void DoClearScene(string nextSceneName, bool clearPool, bool clearAllRes)
    {
	    try
	    {
		    ApplicationFacade.instance.SendNotification(CommonNotification.LEAVE_SCENE);
	    }
	    catch (Exception e)
	    {
		    Logger.Error(e);
	    }
	    
	    GameUtil.RemoveAllPopupPanels(true, PopupRemoveMode.DEFAULT,true);

	    ResourceReleaseFacade.instance.Reset();

	    try
	    {
		    if (currentSceneName != null)
		    {
			    _controllerMap.TryGetValue(currentSceneName, out ISceneManager manager);
			    if (manager != null)
			    {
				    manager.OnLeaveScene(currentSceneName, nextSceneName);
			    }
		    }
	    }
	    catch (Exception e)
	    {
		    Logger.Error(e);
	    }

	    int count = _autoDisposableList.Count;

	    for (int i = 0; i < count; ++i)
	    {
		    IDisposable autoDisposable = _autoDisposableList[i];
		    if (autoDisposable != null)
		    {
			    autoDisposable.Dispose();
			    _autoDisposableList[i] = null;
		    }
	    }

	    _autoDisposableList.Clear();
	    
	    if (clearPool)
	    {
		    GameObjectPool.instance.Clear();
	    }

	    if (clearAllRes)
	    {
		    vp_Timer.CancelAll();
		    RefCacheFacade.instance.Dispose();
	    }
    }

    private static IEnumerator DoSwitchScene(string sceneName,
	    object switchContext = null,
	    bool clearAllRes = false,
	    bool clearSceneManager = false,
	    bool clearPrewarmRes = true)
	{
		while (!inScene && currentSceneName != null)
		{
			yield return null;
		}
		if (inScene || currentSceneName == null)
		{
			inScene = false;
#if UNITY_EDITOR
			Logger.Debug("Start Switch Scene");
#endif
			DoClearScene(sceneName, false, clearAllRes);
			
			// 满足条件进行GC
			if (EquineConfig.serverTime - last_time > GC_TIME)
			{
				ResourceFacade.GC(clearPrewarmRes);
			}

			if (_loadingSceneName == null)
			{
				_loadingSceneName = sceneName;

                ISceneManager manager = null;

                if (clearSceneManager)
                {
                    Dictionary<string, ISceneManager>.Enumerator iter = _controllerMap.GetEnumerator();
                    while (true)
                    {
	                    ScriptProfiler.BeginSample(iter.ToString());
	                    bool b = iter.MoveNext();
	                    ScriptProfiler.EndSample();
	                    if (b)
						    iter.Current.Value.OnRemove();
	                    else
		                    break;
                    }
                    _controllerMap.Clear();
                }
                else
                {
                    _controllerMap.TryGetValue(_loadingSceneName, out manager);
                }
				
				string prevScene = currentSceneName;
				currentSceneName = _loadingSceneName;
				_loadingSceneName = null;

				if (manager != null)
				{
					// any scene first enter
					if (string.IsNullOrEmpty(prevScene))
					{
						ApplicationFacade.instance.SendNotification(CommonNotification.ENTER_SCENE_FIRST_TIME);
					}
					
                    IEnumerator<int> iter = manager.OnEnterScene(prevScene, currentSceneName, switchContext);
                    while (true)
                    {
	                    ScriptProfiler.BeginSample(iter.ToString());
	                    bool b = iter.MoveNext();
	                    ScriptProfiler.EndSample();
	                    if (b)
		                    yield return null;
	                    else
		                    break;
                    }
#if UNITY_EDITOR
					Logger.Debug("Enter Scene Complete");
#endif
					
					ApplicationFacade.instance.SendNotification(CommonNotification.ENTER_SCENE);
				}
				inScene = true;
			}
		}
		_switchSceneLimitUpdator = 0;
	}

	public static string loadingSceneName => _loadingSceneName;
}
