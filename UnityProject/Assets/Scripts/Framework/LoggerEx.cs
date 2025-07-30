using System.Collections.Generic;
using System.Diagnostics;

public static class LoggerEx
{
    [Conditional("DEBUG")]
    public static void RedInfo(string msg)
    {
        Logger.Debug($"<color='red'>{msg}</color>");
    }

    [Conditional("DEBUG")]
    public static void RedInfo(string tag, string msg)
    {
        Logger.Debug($"<color='red'>[{tag}]:{msg}</color>");
    }

    public static void RunTimeInfo(string msg)
    {
        Logger.Info(msg, null, LogTargetType.Network | LogTargetType.Runtime);
    }
    public static void RunTimeInfo(string tag,string msg)
    {
        Logger.Info($"[{tag}]:{msg}" ,null,LogTargetType.Network | LogTargetType.Runtime);
    }
    public static void RunTimeError(string msg)
    {
        Logger.Error(msg, null);
    }
    public static void RunTimeError(string tag,string msg)
    {
        Logger.Error($"[{tag}]:{msg}" ,null);
    }
}