using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.Utils
{
    public class Singleton<T>
        where T : class, new()
    {
        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance
        {
            get { return instance.Value; }
        }
    }
}
