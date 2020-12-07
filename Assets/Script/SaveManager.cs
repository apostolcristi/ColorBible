using System;
using System.Collections;
using System.Collections.Generic;
using IndieStudio.DrawingAndColoring.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
public string colorPart;
public ArrayList colorPartArray = new ArrayList();
    public void Start()
    {
      
    }

    public void ApplyFirstColor()
    {
        GameObject partsParent = gameObject.transform.GetChild(0).gameObject;

        for (int i = 0;i < partsParent.transform.childCount; i++)
        {
            Color currentChild = partsParent.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
          
        } 

    }
    public void SaveColor()
    {

     
        GameObject partsParent = gameObject.transform.GetChild(0).gameObject;

        for (int i = 0; i < partsParent.transform.childCount; i++)
        {
            Color currentChild = partsParent.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color;
            ColorUtility.ToHtmlStringRGB(currentChild);

            colorPart = ImageOrder.imageSet + "-" + InstantiateImages.imageNumber + "-" + i + "-" +
                        ColorUtility.ToHtmlStringRGB(currentChild);
        

        

           colorPartArray.Add(colorPart);
        }

        SaveSystem.SavePart(this,ImageOrder.imageSet,InstantiateImages.imageNumber);
       
    }

    public void LoadColor()
    {
        
        GameObject partsParent = gameObject.transform.GetChild(0).gameObject;

        string[] colorPartHex;
        for (int i = 0;i < partsParent.transform.childCount; i++)
        {
            SpriteRenderer currentChild= partsParent.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
     
            Color newColor;
            
         GameData data = SaveSystem.LoadPart(ImageOrder.imageSet,InstantiateImages.imageNumber);
         colorPart = data.hex[i].ToString();
         Debug.Log(colorPart);
         colorPartHex = colorPart.Split('-');
         colorPart = colorPartHex[3];
         ColorUtility.TryParseHtmlString("#" + colorPart,out newColor);
         currentChild.GetComponent<ShapePart>().SetColor(newColor);
        // Debug.Log(colorPart);
         
        }
    }
}
