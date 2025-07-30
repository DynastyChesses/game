using System;
using System.Collections.Generic;

namespace MobileSDK.IAP.GoogleBilling
{
    [Serializable]
    public class QueryProductsResult : BillingResult
    {
        public QueryProductsResult()
            : base() { }

        public List<Product> products = new List<Product>();
    }
}
