using System;
using System.Collections.Generic;

namespace MobileSDK.IAP.GoogleBilling
{
    [Serializable]
    public class QueryProductDetailsParamJson : BillingResult
    {
        public List<ProductInfo> products;
    }
}
