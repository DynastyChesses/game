using System;

namespace MobileSDK.IAP.GoogleBilling
{
    [Serializable]
    public class BillingResult
    {
        /// <summary>
        /// 0 表示成功
        /// https://developer.android.com/reference/com/android/billingclient/api/BillingClient.BillingResponseCode?_gl=1*1gub67d*_up*MQ..*_ga*NjYxNjYxMjk2LjE3MTUzNDQ2Nzk.*_ga_6HH9YJMN9M*MTcxNTM0NDY3OS4xLjAuMTcxNTM0NDY3OS4wLjAuMA..#OK
        /// </summary>
        public BillingResultCode code;

        public string debugMessage;
    }
}
