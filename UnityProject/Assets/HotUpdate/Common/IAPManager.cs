using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour, IStoreListener  
{  
    private IStoreController storeController; // 存储控制器  
    private IExtensionProvider extensionProvider; // 扩展提供者  
    public string productID = "com.yourcompany.yourapp.product1"; // 产品ID  
  
    void Start()  
    {  
        InitializePurchasing(); // 初始化购买  
    }  
  
    public void InitializePurchasing()  
    {  
        if (IsInitialized()) return; // 如果已初始化，返回  
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());  
        builder.AddProduct(productID, ProductType.Consumable); // 添加可消费的产品  
        UnityPurchasing.Initialize(this, builder); // 初始化Unity IAP  
    }  
  
    private bool IsInitialized()  
    {  
        return storeController != null && extensionProvider != null; // 检查是否已初始化  
    }  
  
    public void BuyProduct()  
    {  
        BuyProductID(productID); // 调用购买产品  
    }  
  
    void BuyProductID(string productId)  
    {  
        if (IsInitialized())  
        {  
            Product product = storeController.products.WithID(productId); // 获取产品  
            if (product != null && product.availableToPurchase)  
            {  
                storeController.InitiatePurchase(product); // 发起购买  
            }  
            else  
            {  
                Debug.Log("Product not found or not available for purchase");  
            }  
        }  
        else  
        {  
            Debug.Log("Store not initialized");  
        }  
    }  
  
    // 其他IStoreListener接口方法的实现，如OnInitialized、OnInitializeFailed、OnPurchaseFailed、OnPurchaseSucceeded等。  
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        // throw new System.NotImplementedException();
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        // throw new System.NotImplementedException();
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        // throw new System.NotImplementedException();
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        // throw new System.NotImplementedException();
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        // throw new System.NotImplementedException();
    }
}