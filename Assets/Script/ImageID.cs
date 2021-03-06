using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageID : MonoBehaviour
{
    public int ID = -1;

    
    
    
    void Start()
    {
        if (ID == -1)
        {
            string[] token = gameObject.name.Split('-');
            
            if (token.Length > 1) 
                ID = int.Parse(token[1]);
       
        } 
    }

    public void ImageActive()
    {
        InstantiateImages.enable = true;
        InstantiateImages.first = true;
       
        InstantiateImages.imageNumber = ID;

        StartCoroutine(Load());

    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(.1f);


        
        SceneManager.LoadScene("MainGame");
    }

}
