using System;

namespace BestHTTP.Logger
{
    public sealed class UnityOutput : ILogOutput
    {
        public void Write(Loglevels level, string logEntry)
        {
            switch (level)
            {
                case Loglevels.All:
                case Loglevels.Information:
                    System.Console.WriteLine(logEntry);
                    break;

                case Loglevels.Warning:
                    System.Console.WriteLine(logEntry);
                    break;

                case Loglevels.Error:
                case Loglevels.Exception:
                    System.Console.WriteLine(logEntry);
                    break;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
