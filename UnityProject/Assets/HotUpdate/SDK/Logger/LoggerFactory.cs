using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LoggerFactory
{
    private static ILogger _defaultLogger;
    private static Dictionary<string, ILogger> _dict = new Dictionary<string, ILogger>();

    public static ILogger Get(string name)
    {
        if (!_dict.ContainsKey(name))
        {
            _ensureDefaultLogger();
            _dict.Add(name, new LoggerWithTag(name, _defaultLogger));
        }

        return _dict[name];
    }

    private static void _ensureDefaultLogger()
    {
        if (_defaultLogger != null)
            return;

        _defaultLogger = new UnityLogger();
    }
}
