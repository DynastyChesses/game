using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using BestHTTP;
using BestHTTP.Timings;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using Debug = UnityEngine.Debug;

public static class GameUtil
{
	public static List<string> GetValueByRegex(string regexTxt, string text)
	{
		List<string> list = new List<string>();
		var regex = new Regex(@$"({regexTxt})");
		var match = regex.Matches(text);
		foreach (Match item in match)
		{
			list.Add(item.Value);
		}
		return list;
	}
    
	public static string ExecuteBashCommand(string command, bool UseShellExecute = false, bool RedirectStandardOutput = true, bool RedirectStandardError = true, bool CreateNoWindow = true, string WorkingDirectory = "")
	{
		Process process = new Process();
		process.StartInfo.FileName = "/bin/bash";
		process.StartInfo.Arguments = $"-c \"{command}\"";
		if (!string.IsNullOrEmpty(WorkingDirectory))
		{
			process.StartInfo.WorkingDirectory = WorkingDirectory;
		}
		process.StartInfo.CreateNoWindow = CreateNoWindow;
		process.StartInfo.UseShellExecute = UseShellExecute;
		process.StartInfo.RedirectStandardOutput = RedirectStandardOutput;
		process.StartInfo.RedirectStandardError = RedirectStandardError;
		process.Start();
        
		// Run Cmd
		// Debug.LogError($"{process.StartInfo.FileName} {process.StartInfo.Arguments}");
 
		// 可选：读取输出
		string stdout = "";
		if (process.StartInfo.RedirectStandardOutput)
		{
			stdout = process.StandardOutput.ReadToEnd();
		}
		string stderr = "";
		if (process.StartInfo.RedirectStandardError)
		{
			stderr = process.StandardError.ReadToEnd();
		}
 
		process.WaitForExit();
 
		// 可选：处理输出
		if (string.IsNullOrEmpty(stderr))
		{
			return stdout;
		}
		else
		{
			Debug.LogError($"{stderr}");
		}
		return "err";
	}
	
	public static void RemoveAllPopupPanels(bool resetInput = false, uint removeMode = PopupRemoveMode.DEFAULT, bool clearScene = false)
	{
		if (resetInput)
		{
			EasyTouch.SetTemporaryDisabled(true);
			EasyTouch.ResetTouch();
		}
		ApplicationFacade.instance.SendNotification(BaseUIMediator.REMOVE_ALL_OPEN_VIEW, false);
		PopupFacade.instance.RemoveAllPopup(removeMode,clearScene);
		ApplicationFacade.instance.SendNotification(BaseUIMediator.MARK_ALL_HIDDEN_VIEW_RECYCLABLE);
	}

	private static HashSet<string> _rtlPrefabs = null;

	public static void DisposeAllRTLCache()
	{
		_rtlPrefabs?.Clear();
	}

	public static void ResetGame(bool restartVM, bool resetMemorySessionId = true)
	{
		
	}
	public static void ReSubscribeNotification(GameObject go, PointerEventData data)
	{
#if RG_WECHAT_MINIGAME
		PlatformFacade.instance.ReSubscribeNotification();
#endif
	}
	
	public static void AddSubscribeNotificationListener(GameObject touchObj) 
	{
#if RG_WECHAT_MINIGAME
		UIEventListener.OnPointerDown(touchObj).AddListener(ReSubscribeNotification);
#endif
	}
	
	public static void RemoveSubscribeNotificationListener(GameObject touchObj) 
	{
#if RG_WECHAT_MINIGAME
		UIEventListener.OnPointerDown(touchObj).RemoveListener(ReSubscribeNotification);
#endif
	}

	public static double GetSystemZeroTimeByTime(double time) 
	{
		if (time <= 0) {
			return 0;
		}
		return time - (time - 57600) % 86400;
	}
	

	public static int VersionCompare(string a, string b)
	{
		if (string.IsNullOrEmpty(a))
		{
			if (string.IsNullOrEmpty(b))
			{
				return 0;
			}

			return -1;
		}
		if (string.IsNullOrEmpty(b))
		{
			return 1;
		}

		var aVer = a.Split('.');
		var bVer = b.Split('.');

		var aVerLen = aVer.Length;
		var bVerLen = bVer.Length;
		var len = Math.Max(aVerLen, bVerLen);

		for (var i = 0; i < len; ++i)
		{
			var aSzVer = i < aVerLen ? aVer[i] : null;
			var bSzVer = i < bVerLen ? bVer[i] : null;

			int aNum = 0;
			int bNum = 0;
			if (!string.IsNullOrEmpty(aSzVer)) aNum = int.Parse(aSzVer);
			if (!string.IsNullOrEmpty(bSzVer)) bNum = int.Parse(bSzVer);

			if (aNum > bNum) return 1;
			else if (aNum < bNum) return -1;
		}

		return 0;
	}

	public static bool TryParseStrJson<T>(string str, out T parseObj)
	{
		parseObj = default;
		if ((str.StartsWith("{") && str.EndsWith("}")) ||	//For object
		    (str.StartsWith("[") && str.EndsWith("]")))		//For Array
		{
			try
			{
				parseObj = JsonConvert.DeserializeObject<T>(str);
				return true;
			}
			catch (JsonReaderException jex)
			{
				throw jex;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		return false;
	}

	public static (int, string) GetLastVersion(string version)
	{
		int lastIndexOfDot = version.LastIndexOf(".");
		if (lastIndexOfDot == version.Length - 1 || lastIndexOfDot == -1 || lastIndexOfDot == 0)
		{
			return (-1, null);
		}
		string prefix = version.Substring(0, lastIndexOfDot + 1);
		int mainVersion = int.Parse(version.Substring(lastIndexOfDot + 1));
		return (mainVersion, prefix);
	}
	
	private static Dictionary<string, string> _cacheParams = new Dictionary<string, string>();
	
	public static void ReportHTTPResponsed(string desc, HTTPRequest request, HTTPResponse response, bool sendNow = false)
	{
		_cacheParams.Clear();
		_cacheParams["uri"] = request.Uri.ToString();
		_cacheParams["status"] = response != null ? response.StatusCode.ToString() : "-1";
		_cacheParams["message"] =
			response != null ? (response.IsSuccess ? response.DataAsText : response.Message) : (request.Exception != null ? request.Exception.Message :  "Unknown");
		TimingEvent connectEvent = request.Timing.FindFirst(TimingEventNames.TCP_Connection);
		if (connectEvent != TimingEvent.Empty)
		{
			_cacheParams["connectTime"] = ((long)connectEvent.Duration.TotalMilliseconds).ToString();
		}

		TimingEvent dnsLookupEvent = request.Timing.FindFirst(TimingEventNames.DNS_Lookup);
		if (dnsLookupEvent != TimingEvent.Empty)
		{
			_cacheParams["dnsTime"] = ((long) dnsLookupEvent.Duration.TotalMilliseconds).ToString();
		}

		if (response != null && response.IsSuccess)
		{
			TimingEvent totalEvent = request.Timing.FindFirst(TimingEventNames.Finished);
			if (totalEvent != TimingEvent.Empty)
			{
				_cacheParams["time"] = ((long) totalEvent.Duration.TotalMilliseconds).ToString();
			}
		}

		Logger.Info(desc, _cacheParams, LogTargetType.Network, sendNow ? LogImportance.High : LogImportance.Normal);
	}
	
	public static void ShowTips(string key, string arg0)
	{
		ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_NOTICE,Language.GetContent(key,arg0));
	}
	
	public static void ShowTips(string key)
	{
		ApplicationFacade.instance.SendNotification(NotificationConst.SHOW_NOTICE,Language.GetContent(key));
	}

	public static void ComingSoon()
	{
		ShowTips("101141");
	}
	
	public static void ReportHTTPResponsed(string desc, UnityWebRequest request, bool sendNow = false)
	{
		_cacheParams.Clear();
		_cacheParams["uri"] = request.uri.ToString();
		_cacheParams["status"] = request.responseCode.ToString();
		
		bool isError = request.isHttpError || request.isNetworkError;
		if (!isError && request.isDone)
		{
			_cacheParams["message"] = request.downloadHandler.text;
		}
		else
		{
			_cacheParams["message"] = request.error;
		}

		Logger.Info(desc, _cacheParams, LogTargetType.Network, sendNow ? LogImportance.High : LogImportance.Normal);
	}


    private static float _timer;

    private static Transform _avaterRoot;

    public static Transform GetAvaterRoot()
    {
	    if (_avaterRoot == null)
		    _avaterRoot = ResourceFacade.NewGameObject("AvaterRoot").transform;

	    return _avaterRoot;
    }

    
    
    private static Transform _avaterBRoot;
    public static Transform GetBuildRoot()
    {
	    if( _avaterBRoot == null )
		    _avaterBRoot = ResourceFacade.NewGameObject( "BuildRoot" ).transform;
	    
	    return _avaterBRoot;
    }
    
    private static Transform _animalRoot;
    public static Transform GetAnimalRoot()
    {
	    if( _animalRoot == null )
		    _animalRoot = ResourceFacade.NewGameObject( "AnimalRoot" ).transform;
	    
	    return _animalRoot;
    }

    private static Transform _effRoot;
    public static Transform GetEffRoot()
    {
	    if (_effRoot == null)
	    {
		    _effRoot = ResourceFacade.NewGameObject("EffectRoot").transform;
	    }

	    return _effRoot;
    }
    
    public static T GetOrAddComponent<T>( this GameObject go ) where T : Component
    {
	    var comp = go.GetComponent<T>();
	    if( comp == null )
		    comp = go.AddComponent<T>();
	    return comp;
    }


	/// <summary>
	/// 获取屏幕宽高比<br />
	/// 居中显示时按照像机的rect来计算
	/// </summary>
	/// <returns></returns>
	public static float GetScreenAspectRatio()
    {
		var cam = UIManager.instance.mainCamera;

		// 居中显示处理
		if (cam.rect.width < 1f || cam.rect.height < 1f)
		{
			return (float)cam.rect.width / cam.rect.height;
		}
		else
		{
			return (float)Screen.width / Screen.height;
		}
    }
}