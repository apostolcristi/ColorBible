using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetID : MonoBehaviour
{

    public static SetID setID;
    public int ID = -1;
    public GameObject Locked;
    public PurchaseButton RemoveLock;
    public PurchaseButton RemoveLock1;
    public PurchaseButton RemoveLock2;
    
    private GameObject NextButton,PreviousButton;
    private GameObject NoButton;
    private GameObject YesButton;
    private GameObject MainScreen;
    
    

    
    void Start()
    {
        NextButton = GameObject.FindGameObjectWithTag("ChangeButtons");
        PreviousButton = GameObject.FindGameObjectWithTag("ChangeButtons");
        
        MainScreen = GameObject.FindGameObjectWithTag("MainScreen");
        if (ID == -1)
        {
            string[] token = gameObject.name.Split('-');
            ID = int.Parse(token[1]);
            ID -= 1;
        }

        if (ID == 0)
        {
            gameObject.GetComponent<Button>().onClick.AddListener((() => Imageset()));
        }

        if (ID >= 1)
        {
       
        NoButton =  gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject;
        YesButton =  gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).gameObject;
        
        NoButton.GetComponent<Button>().onClick.AddListener((() => No()));
        if (ID == 1 && IAPManager.isRemoved==true)
        {
            gameObject.GetComponent<Button>().onClick.AddListener((() => Imageset()));
        }
        else if(ID==1 && IAPManager.isRemoved==false)
        {
            gameObject.GetComponent<Button>().onClick.AddListener((() => AreYouSure()));
            YesButton.GetComponent<Button>().onClick.AddListener((() => RemoveLock.ClickPurchaseButton()));
        }
        if (ID == 2 && IAPManager.isRemoved1==true)
        {
            gameObject.GetComponent<Button>().onClick.AddListener((() => Imageset()));
        }
        else if(ID==2 && IAPManager.isRemoved1==false)
        {
            gameObject.GetComponent<Button>().onClick.AddListener((() => AreYouSure()));
            YesButton.GetComponent<Button>().onClick.AddListener((() => RemoveLock1.ClickPurchaseButton()));
        }
        if (ID == 3 && IAPManager.isRemoved1==true)
        {
            gameObject.GetComponent<Button>().onClick.AddListener((() => Imageset()));
        }
        else if(ID==3 && IAPManager.isRemoved2==false)
        {
            gameObject.GetComponent<Button>().onClick.AddListener((() => AreYouSure()));
            YesButton.GetComponent<Button>().onClick.AddListener((() => RemoveLock2.ClickPurchaseButton()));
        }
    
        }
        
    }

    private void Update()
    {
        if (ID == 1 && IAPManager.isRemoved == true)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            
        }
        if (ID == 2 && IAPManager.isRemoved1 == true)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            
        }

        if (ID == 3 && IAPManager.isRemoved2 == true)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (gameObject.transform.GetChild(1).gameObject.activeInHierarchy == true)
        {
            MainScreen.SetActive(false);
            NextButton.GetComponent<Image>().raycastTarget = false;
            PreviousButton.GetComponent<Image>().raycastTarget = false;
        }
        else
        {
            MainScreen.SetActive(true);
            NextButton.GetComponent<Image>().raycastTarget = true;
            PreviousButton.GetComponent<Image>().raycastTarget = true;
        }
    }

    public void AreYouSure()
    {
        
        NextButton = GameObject.FindGameObjectWithTag("ChangeButtons");
        PreviousButton = GameObject.FindGameObjectWithTag("ChangeButtons");

  
      
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void No()
    {
        NextButton = GameObject.FindGameObjectWithTag("ChangeButtons");
        PreviousButton = GameObject.FindGameObjectWithTag("ChangeButtons");

     
        
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
    
    public void Imageset()
    {
        ImageOrder.imageSet = ID;
        SceneManager.LoadScene("ImageSet1");
    }
}
