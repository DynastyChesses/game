using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MobileSDK.IAP.IOS
{
    /// <summary>
    /// Information about a registered product in App Store Connect.
    /// https://developer.apple.com/documentation/storekit/skproduct?language=objc
    /// </summary>
    [Serializable]
    public class Product : IProductDetails
    {
        /// <summary>
        /// The string that identifies the product to the Apple App Store.
        /// </summary>
        public string productIdentifier;

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string localizedTitle;

        /// <summary>
        /// A description of the product.
        /// </summary>
        public string localizedDescription;

        /// <summary>
        /// The cost of the product in the local currency.
        /// </summary>
        public string price;

        /// <summary>
        /// The locale used to format the price of the product.
        /// </summary>
        public string priceLocale;

        public string Name => localizedTitle;

        public string PriceLocale => price;

        public string identifier => productIdentifier;
    }

    /// <summary>
    /// An App Store response to a request for information about a list of products.
    /// https://developer.apple.com/documentation/storekit/skproductsresponse?language=objc
    /// </summary>
    [Serializable]
    public class SKProductsResponse
    {
        /// <summary>
        /// A list of products, one product for each valid product identifier provided in the original request.
        /// </summary>
        public List<Product> products = new List<Product>();

        /// <summary>
        /// An array of product identifier strings that the App Store doesn’t recognize.
        /// </summary>
        public List<string> invalidProductIdentifiers = new List<string>();
    }
}
