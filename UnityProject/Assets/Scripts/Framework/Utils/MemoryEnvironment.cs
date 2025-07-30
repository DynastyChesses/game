using System.Collections.Generic;
using System.Linq;
public class MemoryEnvironment
{
    private static Dictionary<string, string> _memoryCache = new Dictionary<string, string>();

    public static string GetValue(string key)
    {
        _memoryCache.TryGetValue(key, out var value);
        return value;
    }

    public static void SetValue(string key, string value)
    {
        _memoryCache[key] = value;
    }

    public static bool DeleteValue(string key)
    {
        return _memoryCache.Remove(key);
    }

    public static bool HasValue(string key)
    {
        return _memoryCache.ContainsKey(key);
    }

    public static string[] GetKeys()
    {
        return _memoryCache.Keys.ToArray();
    }
        
    public static string GetMemoryValue(string key)
    {
        return MemoryEnvironment.GetValue(key);
    }
}