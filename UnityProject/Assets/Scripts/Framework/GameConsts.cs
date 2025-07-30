using UnityEngine;
using System.Collections;
using UnityEditor;

public static partial class GameConsts {
	//
	public static string platform
	{
		#if UNITY_EDITOR
		get
		{
			if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android)
			{
				return "Android";
			}
			else
			{
				return "iOS";
			}
			return "";
		}
		#else
		get
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				return "Android";
			}
			else
			{
				return "iOS";
			}
			return "";
		}
		#endif
	}
	// 入口
	public static string Main = "GameMain";
	public static string MainFunction = "Run";
	public static string CleanUp = "CleanUp";
	public static string DllName = "HotUpdate";
	public static string OssUrl = $"http://miaokids-test.oss-cn-beijing.aliyuncs.com/{Application.identifier}/";
	public static string OssPath = $"game/{platform}/{DllName}.dll.bytes";
	public static string configVersion = "1.0.0";
	// 不需要单独指定了
	// public static string DllExt = ".dll.bytes";
	public static string HashPath = $"game/{platform}/hash.txt";
	public static string LangHashPath = "game/lang_hash.txt";
	public static string LangResPath = "game/iOS/lang.csv";
	// Destroy
	public static string Destroy = "DESTROY";
}
