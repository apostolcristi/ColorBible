using System;
using System.Collections;
using System.Collections.Generic;
using IndieStudio.DrawingAndColoring.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstantiateImages : MonoBehaviour
{
    public static InstantiateImages instance = null;
    public ImageHolder imageHolder;
    public GameObject imagesParent;
    public GameObject drawingParent;
    private static bool isQuitting = true;
    private static bool isActive = false;

    private string[,] firstColorImage = new string[100,100];
    public static bool first = true;
    public static int imageNumber=0;
    public static bool enable = true;
    public SaveManager SM;


public static GameObject[ , ] imageArray = new GameObject[100,100];

public static GameObject[,] drawArray = new GameObject[100, 100];


    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InstantiatePrefabImages();
     
         

        }
        else
        {
            //Set up the render camera of the Canvas
            Canvas canvas = instance.GetComponent<Canvas>();
            if (canvas.worldCamera == null)
            {
                canvas.worldCamera = Camera.main;
            }

            Destroy(gameObject);
        }
        

    }

    void Start()
    {
        DrawingInstantiate();

        for (int i = 0; i < imageHolder.title.Length; i++)
        {
            for (int j = 0; j < imageHolder.arrays[i].objects.Length;j++)
            {
                drawArray[i,j].SetActive(false);
            }
        }

  

    }

    // Update is called once per frame
    void Update()
    {
        
        imageArray[ImageOrder.imageSet,imageNumber].SetActive(enable);
        imageArray[ImageOrder.imageSet, imageNumber].GetComponent<Image>().raycastTarget = false;
        for (int i = 0; i < imageHolder.title.Length; i++)
        {
            for (int j = 0; j < imageHolder.arrays[i].objects.Length; j++)
            {
                if (i == ImageOrder.imageSet && j == imageNumber)
                {
                    drawArray[i,j].SetActive(enable);
                }
                else
                {
                    drawArray[i,j].SetActive(false);
                }
            }
        }

        
    
         }

    private void InstantiatePrefabImages()
    {
        for (int i = 0; i < imageHolder.title.Length; i++)
        {
            GameObject shape = new GameObject("Shape " + i);
            shape.transform.SetParent(imagesParent.transform);
            shape.transform.localScale = new Vector3(1, 1, 1);
            for (int j = 0; j < imageHolder.arrays[i].objects.Length;j++)
            {
                GameObject newImage = Instantiate(imageHolder.arrays[i].objects[j], imagesParent.transform.position,
                    Quaternion.identity) as GameObject;
                newImage.transform.SetParent(shape.transform);
                newImage.transform.localScale= new Vector3(6.1f,6.1f,1);
                newImage.transform.localPosition = newImage.transform.localPosition + new Vector3(40f, -9f, 0f);
                //newImage.AddComponent<SaveManager>();
                
                imageArray[i, j] = newImage;
                newImage.SetActive(false);
            }
            
        }
      
    }
   

 private void DrawingInstantiate()
 {
     for (int i = 0; i < imageHolder.title.Length; i++)
     {


         GameObject parentContent = new GameObject("Content " + i);
         parentContent.transform.SetParent(drawingParent.transform);
         parentContent.transform.localScale = Vector3.one;
         for (int j = 0; j < imageHolder.arrays[i].objects.Length; j++)
         {
             GameObject drawingContent = new GameObject(imageHolder.arrays[i].objects[j].name + " Parts");
             drawingContent.layer = LayerMask.NameToLayer("MiddleCamera");
             DrawingContents drawingContentsComponent =
                drawingContent.AddComponent(typeof(DrawingContents)) as DrawingContents;
             drawingContent.AddComponent(typeof(History));
             drawingContent.transform.SetParent(parentContent.transform);
             drawingContent.transform.position = Vector3.zero;
             drawingContent.AddComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
             drawingContent.transform.localScale = Vector3.one;
             //drawingContent.AddComponent<SaveManager>();
             drawingContent.SetActive(false);

             Transform shapeParts = parentContent.transform.Find("Parts");
             
                 if (shapeParts != null)
                 {
                     foreach(Transform part in shapeParts)
                     {
                         if(part.GetComponent<ShapePart>()!=null && part.GetComponent<SpriteRenderer>()!=null)
                         {
                             drawingContentsComponent.shapePartsColors.Add(part.name,part.GetComponent<SpriteRenderer>().color);
                             drawingContentsComponent.shapePartsSortingOrder.Add(part.name,part.GetComponent<SpriteRenderer>().sortingOrder);
                         }
                     }
                 }
                 Area.shapesDrawingContents.Add (drawingContentsComponent);
            
             drawArray[i, j] = drawingContent;
           
         }
     }
 }

    public void Album()
    {
       
        // imageArray[ImageOrder.imageSet,imageNumber].GetComponent<SaveManager>().SaveColor();
        // drawArray[ImageOrder.imageSet,imageNumber].GetComponent<SaveManager>().SaveLine();
        // drawArray[ImageOrder.imageSet,imageNumber].GetComponent<SaveManager>().SaveStamp();

        
       SM.SaveLine();
       SM.SaveStamp();
       Debug.Log("se intampla ceva");
     for (int i = 0; i < imageHolder.title.Length; i++)
     {
         for (int j = 0; j < imageHolder.arrays[i].objects.Length;j++)
         {
             imageArray[i,j].SetActive(false);
             drawArray[i,j].SetActive(false);
         }

         enable = false;
     }

     

        SceneManager.LoadScene("ImageSet1");
        
        
    }
void OnApplicationQuit(){
    SM.SaveLine();
    SM.SaveStamp();
}

//TODO:de verificat behaviourul la astea doua functii
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SM.SaveLine();
            SM.SaveStamp();
        }
        else
        {  
            SceneManager.LoadScene("MainGame");

        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SM.SaveStamp();
            SM.SaveLine();
        }
        else
        {   
            SceneManager.LoadScene("MainGame");
        }
    }
}
