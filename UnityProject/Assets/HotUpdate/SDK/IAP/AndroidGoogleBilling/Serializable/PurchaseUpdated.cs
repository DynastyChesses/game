using System;
using System.Collections.Generic;

namespace MobileSDK.IAP.GoogleBilling
{
    [Serializable]
    public class PurchaseUpdatedResult : BillingResult
    {
        public List<Purchase> purchases;
    }
}
