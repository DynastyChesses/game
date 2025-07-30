using System;
using System.Collections.Generic;
using System.Diagnostics;

public enum LogTargetType
{
  None = 0,
  Runtime = 1,
  Network = 2,
}
public enum LogImportance
{
  Normal,
  High,
}

public interface ILoggerTarget
{
  LogTargetType targetType { get; }

  void Debug(string message, object context, LogImportance importance);

  void Info(string message, object context, LogImportance importance);

  void Warning(string message, object context, LogImportance importance);

  void Error(string message, string stackTrace, object context, LogImportance importance);
}

public class Logger
{
  public static void Debug(string msg, object o, LogTargetType network)
  {
    UnityEngine.Debug.Log($"{msg}");
  }
  
  public static void Info(string msg, object o, LogTargetType network)
  {
    UnityEngine.Debug.Log($"{msg}");
  }
  
  public static void Warning(string msg, object o, LogTargetType network)
  {
    UnityEngine.Debug.LogWarning($"{msg}");
  }
  
  public static void Error(string msg, object o, LogTargetType network)
  {
    UnityEngine.Debug.LogError($"{msg}");
  }
  
  public static void Warning(string msg, object o)
  {
    UnityEngine.Debug.LogWarning($"{msg}");
  }
  
  public static void Error(string msg, object o)
  {
    UnityEngine.Debug.LogError($"{msg}");
  }
  
  public static void Debug(string msg, object o)
  {
    UnityEngine.Debug.Log($"{msg}");
  }
  
  public static void Info(string msg, object o)
  {
    UnityEngine.Debug.Log($"{msg}");
  }
  
  ////////
  ///
  public static void Warning(string msg)
  {
    UnityEngine.Debug.LogWarning($"{msg}");
  }
  
  public static void Error(string msg)
  {
    UnityEngine.Debug.LogError($"{msg}");
  }
  
  public static void Debug(string msg)
  {
    UnityEngine.Debug.Log($"{msg}");
  }
  
  public static void Info(string msg)
  {
    UnityEngine.Debug.Log($"{msg}");
  }

  public static void Info(string desc, Dictionary<string, string> cacheParams, LogTargetType network, LogImportance normal)
  {
    UnityEngine.Debug.Log($"{desc}");
  }
  
  public static void Error(string desc, Dictionary<string, string> cacheParams, LogTargetType network, LogImportance normal)
  {
    UnityEngine.Debug.Log($"{desc}");
  }
  
  public static void Warning(string desc, Dictionary<string, string> cacheParams, LogTargetType network, LogImportance normal)
  {
    UnityEngine.Debug.Log($"{desc}");
  }
  
  public static void Debug(string desc, Dictionary<string, string> cacheParams, LogTargetType network, LogImportance normal)
  {
    UnityEngine.Debug.Log($"{desc}");
  }

  public static void Error(Exception desc)
  {
    UnityEngine.Debug.LogError($"{desc.Message}");
  }
}