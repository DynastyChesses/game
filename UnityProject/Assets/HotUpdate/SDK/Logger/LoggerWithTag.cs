using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerWithTag : ILogger
{
    private ILogger _logger;
    private string _tag;

    public LoggerWithTag(string tag, ILogger logger)
    {
        this._tag = tag;
        this._logger = logger;
    }

    public void Debug(string message)
    {
        this._logger.Debug($"[{this._tag}] {message}");
    }

    public void Error(string message)
    {
        this._logger.Error($"[{this._tag}] {message}");
    }

    public void Info(string message)
    {
        this._logger.Info($"[{this._tag}]: {message}");
    }

    public void Warining(string message)
    {
        this._logger.Warining($"[{this._tag}]: {message}");
    }
}
