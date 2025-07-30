using System;

namespace MobileSDK.IAP.GoogleBilling
{
    [Serializable]
    public class Product : IProductDetails
    {
        public string productId;
        public string productName;
        public string formattedPrice = "";
        public long priceAmountMicros = 0;
        public string currencyCode = "";

        public string Name => productName;

        public string PriceLocale => formattedPrice;

        public string identifier => productId;
    }
}
