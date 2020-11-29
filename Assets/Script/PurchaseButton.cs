using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType
    {
        removeLock,
        removeLock1,
        removeLock2
    };

    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {case PurchaseType.removeLock:
            IAPManager.instance.BuySet2();
            break;
        case PurchaseType.removeLock1:
            IAPManager.instance.BuySet3();
            break;
        case PurchaseType.removeLock2:
            IAPManager.instance.BuySet4();
            break;
        }
    }
}
