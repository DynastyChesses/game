namespace MobileSDK.IAP.GoogleBilling
{
    /// <summary>
    /// https://developer.android.com/reference/com/android/billingclient/api/BillingClient.BillingResponseCode
    /// </summary>
    public enum BillingResultCode
    {
        Ok = 0,
        BILLING_UNAVAILABLE = 3,
        DEVELOPER_ERROR = 5,
        ERROR = 6,
        FEATURE_NOT_SUPPORTED = -2,
        ITEM_ALREADY_OWNED = 7,
        ITEM_NOT_OWNED = 8,
        ITEM_UNAVAILABLE = 4,
        NETWORK_ERROR = 12,
        SERVICE_DISCONNECTED = -1,
        SERVICE_TIMEOUT = -3,
        SERVICE_UNAVAILABLE = 2,
        USER_CANCELED = 1
    }
}
