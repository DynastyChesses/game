using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogger
{
    public void Debug(string message);
    public void Info(string message);
    public void Error(string message);
    public void Warining(string message);
}