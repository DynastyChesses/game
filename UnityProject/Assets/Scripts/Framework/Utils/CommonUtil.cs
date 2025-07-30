using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Profiling;
using Object = UnityEngine.Object;
public static class CommonUtil
{
    private const string GAME_PROCESS_ID = "GameProcessID";
    
    private static char[] _separator = { '*' };

    public static char commaSeparator = ',';
    public static char lineSeparator = '|';
    public static char semicolonSeparator = ';';
    public static char spaceSeparator = ' ';
    public static char underScoreSeparator = '_';
    public static char midcourtSeparator = '-';
    public const int ONE_DAY_SECONDS = 86400;
    public const int ONE_HOUR_SECONDS = 3600;
    public const int ONE_MINUTE_SENONDS = 60;

    public static int mainThreadId;

    private static string[] _intStringCacheArr = new string[65536];

    public static string GetUnsignedShortIntString(ushort intVal)
    {
        string result = _intStringCacheArr[intVal];
        if (result == null)
        {
            result = _intStringCacheArr[intVal] = intVal.ToString();
        }
        return result;
    }
    
    public static bool StartsWith(string str, string compareStr)
    {
        if (str != null && compareStr != null && str.Length >= compareStr.Length)
        {
            var len = compareStr.Length;
            for (int i = 0; i < len; ++i)
            {
                if (str[i] != compareStr[i])
                {
                    return false;
                }
            }

            return true;
        }

        return false;
    }
        
    public static bool IsNull(this Object com)
    {
        return com == null;
    }
    public static bool IsNotNull(this Object com)
    {
        return com != null;
    }
    
    /// <summary>
    ///  判断字符串是否只包含字母和数字
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static bool IsAlphaNumeric(string input)
    {
        Regex rgx = new Regex(@"^[a-zA-Z0-9]+$");
        return rgx.IsMatch(input);
    }
    
    
}

