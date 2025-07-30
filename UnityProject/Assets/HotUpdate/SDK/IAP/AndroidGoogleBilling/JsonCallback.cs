using System;
using System.Threading;
using UnityEngine;

namespace MobileSDK.IAP.GoogleBilling
{
    public class JsonCallbackWithUnitySynchronizationContext<T> : AndroidJavaProxy
    {
        private Action<T> _callback;
        private SynchronizationContext _unitySynchronizationContext;

        private ILogger _logger;

        public JsonCallbackWithUnitySynchronizationContext(Action<T> callback)
            : base("com.ethan.googlelibrary.StringCallbackInterface")
        {
            this._callback = callback;
            this._unitySynchronizationContext = SynchronizationContext.Current;
            this._logger = LoggerFactory.Get("StringCallbackWithUnitySynchronizationContext");
        }

        public void onCallback(string message)
        {
            this._logger.Debug("Received message from Java: " + message);
            this._unitySynchronizationContext.Post(
                (_state) =>
                {
                    this._callback(JsonUtility.FromJson<T>(message));
                },
                null
            );
        }
    }
}
