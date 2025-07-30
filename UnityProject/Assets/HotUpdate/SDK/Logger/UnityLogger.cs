using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UnityLogger : ILogger
{
    public void Debug(string message)
    {
        UnityEngine.Debug.Log(message);
    }

    public void Error(string message)
    {
        UnityEngine.Debug.LogError(message);
    }

    public void Info(string message)
    {
        UnityEngine.Debug.Log(message);
    }

    public void Warining(string message)
    {
        UnityEngine.Debug.LogWarning(message);
    }
}