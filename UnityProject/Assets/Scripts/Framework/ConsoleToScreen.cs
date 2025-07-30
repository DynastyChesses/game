using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleToScreen : MonoBehaviour
{
    const int maxLines = 50;
    const int maxLineLength = 120;
    private string _logStr = "";

    private readonly List<string> _lines = new List<string>();

    public int fontSize = 15;

    void OnEnable()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.OSXEditor)
        {
            Application.logMessageReceived += Log;
        }
    }

    void OnDisable()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.OSXEditor)
        {
            Application.logMessageReceived -= Log;
        }
    }

    public void Log(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Error)
        {
            foreach (var line in logString.Split('\n'))
            {
                if (line.Length <= maxLineLength)
                {
                    _lines.Add(line);
                    continue;
                }
                var lineCount = line.Length / maxLineLength + 1;
                for (int i = 0; i < lineCount; i++)
                {
                    if ((i + 1) * maxLineLength <= line.Length)
                    {
                        _lines.Add(line.Substring(i * maxLineLength, maxLineLength));
                    }
                    else
                    {
                        _lines.Add(line.Substring(i * maxLineLength, line.Length - i * maxLineLength));
                    }
                }
            }
            if (_lines.Count > maxLines)
            {
                _lines.RemoveRange(0, _lines.Count - maxLines);
            }
            _logStr = string.Join("\n", _lines);
            // if (GameLaunch.Instance.text != null)
            // {
            //     GameLaunch.Instance.text.GetComponent<UIText>().text = _logStr;
            // }
            //
        }
    }
}