using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
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

    private AudioSource audioSource;
    private GameObject NoButton;
    private GameObject YesButton;
    private GameObject MainScreen;
    
    

    
    void Start()
    {
       audioSource = gameObject.GetComponent<AudioSource>();
        
        MainScreen = GameObject.FindGameObjectWithTag("MainScreen");
        if (ID == -1)
        {
            string[] token = gameObject.name.Split('-');
            ID = int.Parse(token[1]);
            ID -= 1;
        }

        if (ID == 0)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => Imageset());
           // gameObject.GetComponent<Button>().onClick.AddListener(() => AudioPlay());
            Locked.SetActive(false);
    
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
    
        }
        else
        {
            MainScreen.SetActive(true);

    
        }
    }

    public void AreYouSure()
    {
 
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void No()
    {

        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }
    
    public void Imageset()
    {
        ImageOrder.imageSet = ID;
        SceneManager.LoadScene("ImageSet1");
    }

    public void AudioPlay()
    {
        audioSource.Play();
        Debug.Log("ok");
    }
}
