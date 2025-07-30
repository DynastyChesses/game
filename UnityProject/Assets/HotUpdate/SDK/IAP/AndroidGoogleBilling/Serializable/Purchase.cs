using System;

namespace MobileSDK.IAP.GoogleBilling
{
    [Serializable]
    public class Purchase : IIAPTransaction
    {
        public string orderId;
        public string purchaseToken;
        public string productId;
        public PurchaseState state;

        public string TransactionIdentifier => orderId;

        public string ProductIdentifier => productId;

        public string ParamsForFinisheTheTransaction => purchaseToken;

        public PayStatus Status
        {
            get
            {
                if (state == PurchaseState.PURCHASED)
                    return PayStatus.Paid;

                return PayStatus.None;
            }
        }
    }

    public enum PurchaseState
    {
        PENDING = 2,
        PURCHASED = 1,
        UNSPECIFIED_STATE = 0
    }
}
