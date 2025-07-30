using System;
using System.Collections.Generic;

namespace MobileSDK
{
    public class DynamicEventDispatcher<Events>
        where Events : struct, Enum
    {
        public Dictionary<Events, List<Action<EventArgs>>> _listeners =
            new Dictionary<Events, List<Action<EventArgs>>>();

        public List<Action<Events, EventArgs>> _globalListeners =
            new List<Action<Events, EventArgs>>();

        public DynamicEventDispatcher() { }

        /// <summary>
        /// Listen on an event
        /// </summary>
        /// <param name="e"></param>
        /// <param name="callback"></param>
        public void Listen(Events e, Action<EventArgs> callback)
        {
            if (!this._listeners.ContainsKey(e))
                this._listeners.Add(e, new List<Action<EventArgs>>());

            this._listeners[e].Add(callback);
        }

        /// <summary>
        /// 监听全部的事件
        /// </summary>
        /// <param name="callback"></param>
        public void ListenAll(Action<Events, EventArgs> callback)
        {
            this._globalListeners.Add(callback);
        }

        /// <summary>
        /// Trigger an event
        /// </summary>
        /// <param name="e"></param>
        /// <param name="args"></param>
        public void Trigger(Events e, EventArgs args)
        {
            if (!this._listeners.ContainsKey(e))
                return;

            this._listeners[e].ForEach(c => c(args));
        }

        /// <summary>
        /// Unlisten
        /// </summary>
        /// <param name="e"></param>
        /// <param name="callback"></param>
        public void Unlisten(Events e, Action<EventArgs> callback)
        {
            if (!this._listeners.ContainsKey(e))
                return;

            this._listeners[e].Remove(callback);
        }

        /// <summary>
        /// 解除全局监听
        /// </summary>
        /// <param name="callback"></param>
        public void UnlistenAtAll(Action<Events, EventArgs> callback)
        {
            this._globalListeners.Remove(callback);
        }
    }
}
