using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.IAP
{
    public interface IProductInfo
    {
        public string Name { get; }
        public string PriceLocale { get; }

        public string identifier { get; }
    }
}
