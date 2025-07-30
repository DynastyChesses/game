using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Language
{
	private static readonly Dictionary<string, string> _langShotNames = new Dictionary<string, string>()
	{
		{"Afrikaans", "af"},
		{"Arabic", "ar"},
		{"Belarusian", "be"},
		{"Bulgarian", "bg"},
		{"Basque", "es" },
		{"Catalan", "ca"},
		{"Czech", "cs"},
		{"Danish", "da"},
		{"Dutch", "nl"},
		{"English", "en"},
		{"Estonian", "et"},
		{"Faroese", "fo"},
		{"Finnish", "fi"},
		{"French", "fr"},
		{"German", "de"},
		{"Greek", "el"},
		{"Hebrew", "he"},
		{"Hungarian", "hu"},
		{"Icelandic", "is"},
		{"Indonesian", "id"},
		{"Italian", "it"},
		{"Japanese", "ja"},
		{"Korean", "ko"},
		{"Lithuanian", "lt"},
		{"Latvian", "lv"},
		{"Norwegian", "nb"},
		{"Polish", "pl"},
		{"Portuguese", "pt"},
		{"Romanian", "ro"},
		{"Russian", "ru"},
		{"Serbo-Croatian", "sh"},
		{"Slovak", "sk"},
		{"Slovenian", "sl"},
		{"Spanish", "es"},
		{"Swedish", "sv"},
		{"Thai", "th"},
		{"Turkish", "tr"},
		{"Ukrainian", "uk"},
		{"Vietnamese", "vi"},
		{"ChineseSimplified", "zh_cn"},
		{"ChineseTraditional", "zh_tw"},
		{"Unknown", "en"},
	};

	private static Dictionary<string, string> _needProcessKeyCacheDic = new Dictionary<string, string>();

    private static Dictionary<string, string> _currentLangDic = null;

	private static string _currentLanguage = "";

	private static string _currentLangVersion = null;

	public static string currentLangVersion => _currentLangVersion;

	// 缩写
	public static string currentLanguage
	{
		get { return _currentLanguage; }
	}

	public static bool isShowKey;

	public static bool isArabic = false;
	public static bool arabicMirrorFlag = false;
	public static bool isSupportReusedListArabicFix = false;

	public static bool CheckLangNameRight(string langShotName)
	{
		return _langShotNames.ContainsValue(langShotName);
	}

	public static string GetSystemLanguageISO639Code(string language)
	{
		string shortName;
        if (_langShotNames.TryGetValue(language, out shortName))
		{
			return shortName;
		}
		return "en";
	}
	
	public static string GetSystemLanguageFullName(string language)
	{
		foreach (var item in _langShotNames)
		{
			if (item.Value == language)
			{
				return item.Key;
			}
		}
		return "English";
	}

	private static Regex _keyPatternReg = new Regex(@"^@.*@$");
    public static bool IsKeyPattern(string str)
    {
        return _keyPatternReg.IsMatch(str);
    }

	private static Regex _languageString = new Regex(@"^langStr_");
    public static bool IsLanguageString(string str)
    {
        if (str == null)
            return false;

        return _languageString.IsMatch(str);
    }

    public static string GetProcessedText(string str, bool withoutCheck = false)
    {
	    string result = null;
	    if (!string.IsNullOrEmpty(str) && !_needProcessKeyCacheDic.TryGetValue(str, out result))
	    {
			if (withoutCheck || IsKeyPattern(str))
			{
				string realStr = str.Substring(1, str.Length - 2);
				//可以配成"@key1,key2,key3...@"
				if (realStr.Contains(","))
				{
					string[] strs = realStr.Split(',');
					for (int i = 0; i < strs.Length; i++)
					{
						if (!string.IsNullOrEmpty(result))
						{
							result += ",";
						}
						result += Language.GetContent(strs[i]);
					}
				}
				else
				{
					result = Language.GetContent(realStr);
				}
			}
			else
			{
				result = str;
			}
		    _needProcessKeyCacheDic.Add(str, result);
	    }
	    return result;
    }

    public static string GetContentWithDefaultVal(string key, string defaultVal)
    {
	    if( isShowKey ) return key;
	    return DoGetContent(key, defaultVal);
    }

	public static string GetContent (string key)
	{
		if( isShowKey ) return key;
		return DoGetContent(key);
	}
	
	static string DoGetContent(string key, string defaultVal = null)
	{
		//return Localize.loaded ? Localize.Get( key ) : defaultVal;
		if (key == null)
		{
			return defaultVal;
		}
		string content = null;
		if (_currentLangDic != null && _currentLangDic.TryGetValue(key, out content))
		{
			return content;
		}
		return defaultVal ?? key;
	}

	public static bool HasContent(string key)
	{
		if (key == null)
		{
			return false;
		}
		if (_currentLangDic != null && _currentLangDic.ContainsKey(key))
		{
			return true;
		}
		return false;
	}
	
	
	public static string GetContentWithAppend (string key, string arg0)
	{
		if( isShowKey ) return key;
		if (isArabic)
		{
			string oriTxt = GetContent(key);
			if (oriTxt.EndsWith(":"))
			{
				oriTxt = oriTxt.Split(':')[0];
			}
			return $"{oriTxt}{arg0}:";
		}
		return $"{GetContent(key)}{arg0}";
	}


	public static string GetContent(string key, string arg0)
	{
		if( isShowKey ) return key;
		return string.Format(GetContent(key), arg0);
	}

	public static string GetContent(string key, string arg0, string arg1)
	{
		if( isShowKey ) return key;
		return string.Format(GetContent(key), arg0, arg1);
	}

	public static string GetContent(string key, string arg0, string arg1, string arg2)
	{
		if( isShowKey ) return key;
		return string.Format(GetContent(key), arg0, arg1, arg2);
	}

	public static string GetContent(string key, params string[] args)
	{
		if( isShowKey ) return key;
		return string.Format(GetContent(key), args);
	}

	public static void SetLanguageInfo(string language, string version, Dictionary<string, string> languageDictionary)
	{
		_currentLanguage = language;
		_currentLangVersion = version;
		_currentLangDic = languageDictionary;
		MemoryEnvironment.SetValue("CUR_LANGUAGE", language);
		MemoryEnvironment.SetValue("AUTO_MIRROR_OPEN", "true");
		PlayerPrefs.SetString("CUR_LANGUAGE", language);
		isArabic = language == "ar";
	}

	public static void SetCurrLanguage( string language )
	{
		_currentLanguage = language;
	}
	
	public static bool IsArabicAutoMirrorOpen()
	{
		return isArabic && arabicMirrorFlag;
	}
	
	public static int GetLanguageScaleRatio()
	{
		if (!IsArabicAutoMirrorOpen())
		{
			return 1;
		}
		if (!isArabic)
		{
			return 1;
		}
		return -1;
	}
	public static float GetLanguageRotationRatio()
	{
		if (!IsArabicAutoMirrorOpen())
		{
			return 0;
		}
		return 180f;
	}
}


