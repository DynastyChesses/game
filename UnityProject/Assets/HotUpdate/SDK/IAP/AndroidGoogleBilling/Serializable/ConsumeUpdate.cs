using System;

namespace MobileSDK.IAP.GoogleBilling
{
    [Serializable]
    public class ConsumeResult : BillingResult
    {
        public string purchaseToken;
    }
}
