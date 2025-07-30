using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.IAP
{
    public interface IProductDetails
    {
        public string Name { get; }
        public string PriceLocale { get; }

        public string identifier { get; }
    }
}
