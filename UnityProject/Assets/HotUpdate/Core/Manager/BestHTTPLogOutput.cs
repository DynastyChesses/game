using System;
using BestHTTP.Logger;
public class BestHTTPLogOutput:ILogOutput
{
    public void Write(Loglevels level, string logEntry)
    {
        switch (level)
        {
            case Loglevels.All:
            case Loglevels.Information:
                Logger.Info(logEntry);
                break;

            case Loglevels.Warning:
                Logger.Warning(logEntry);
                break;

            case Loglevels.Error:
            case Loglevels.Exception:
                Logger.Error(logEntry);
                break;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}