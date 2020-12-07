﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;


public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;


    public static bool isRemoved = false;
    public static bool isRemoved1 = false;
    public static bool isRemoved2 = false;

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    //Step 1 create your products
    
    private string removeLock = "remove_lock";
    private string removeLock1 = "remove_lock_1";
    private string removeLock2 = "remove_lock_2";
   


    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(removeLock, ProductType.NonConsumable);
        builder.AddProduct(removeLock1, ProductType.NonConsumable);
        builder.AddProduct(removeLock2, ProductType.NonConsumable);
        

        UnityPurchasing.Initialize(this, builder);
    }


    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }


    //Step 3 Create methods
    public void BuySet2()
    {
        BuyProductID(removeLock);
       
    }

    public void BuySet3()
    {
        BuyProductID(removeLock1);
    }
    public void BuySet4()
    {
        BuyProductID(removeLock2);
    }



    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, removeLock, StringComparison.Ordinal))
        {
            isRemoved = true;
            Debug.Log("Cumparat set2");
            PlayerPrefs.SetInt("Removed", isRemoved ? 1 : 0);

        }else if (String.Equals(args.purchasedProduct.definition.id, removeLock1, StringComparison.Ordinal))
        {
           isRemoved1 = true;
           Debug.Log("Cumparat set3");
           PlayerPrefs.SetInt("Removed1", isRemoved1 ? 1 : 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, removeLock2, StringComparison.Ordinal))
        {
            isRemoved2 = true;
            Debug.Log("Cumparat set4");
            PlayerPrefs.SetInt("Removed2", isRemoved2 ? 1 : 0);
        }
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }










    //**************************** Dont worry about these methods ***********************************
    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        isRemoved = PlayerPrefs.GetInt("Removed") == 1 ? true : false;
        isRemoved1 = PlayerPrefs.GetInt("Removed1") == 1 ? true : false;
        isRemoved2 = PlayerPrefs.GetInt("Removed2") == 1 ? true : false;
      
        if (m_StoreController == null) { InitializePurchasing(); }
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}