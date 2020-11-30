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

    public static bool firstTime=false;
    public static bool firstTime1=false;
    public static bool firstTime2=false;

    
    void Start()
    {

     
        if (ID == -1)
        {
            string[] token = gameObject.name.Split('-');
            ID = int.Parse(token[1]);
            ID -= 1;
        }

        if (ID == 0)
        {
           gameObject.GetComponent<Button>().onClick.AddListener(()=>Imageset());
           Locked.SetActive(false);
        }
        else if(ID==1)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(()=>RemoveLock.ClickPurchaseButton());
        }
        else if(ID==2)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(()=>RemoveLock1.ClickPurchaseButton());
        }
        else if(ID==3)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(()=>RemoveLock2.ClickPurchaseButton());
        }
        
    }

    void Update()
    {
        if (ID == 1 && IAPManager.isRemoved == true && firstTime==false)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(()=>Imageset());
            firstTime = true;
            Locked.SetActive(false);
        }
        if (ID == 2 && IAPManager.isRemoved1 == true && firstTime1==false)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(()=>Imageset());
            firstTime1 = true;
            Locked.SetActive(false);
        }
        if (ID == 3 && IAPManager.isRemoved2 == true && firstTime2==false)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(()=>Imageset());
            firstTime2 = true;
            Locked.SetActive(false);
        }
    }
    public void Imageset()
    {
        ImageOrder.imageSet = ID;
        SceneManager.LoadScene("ImageSet1");
    }
}
