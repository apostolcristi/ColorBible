using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType
    {
        removeLock
    };

    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {case PurchaseType.removeLock:
            IAPManager.instance.BuySet2();
            break;
            
        }
    }
}
