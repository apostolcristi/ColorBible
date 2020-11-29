using System;
using System.Collections;
using System.Collections.Generic;
using IndieStudio.DrawingAndColoring.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiateImages : MonoBehaviour
{
    public static InstantiateImages instance = null;
    public ImageHolder imageHolder;
    public GameObject imagesParent;
    public GameObject drawingParent;

    public static int imageNumber=0;
    public static bool enable = true;

private GameObject[ , ] imageArray = new GameObject[100,100];
[HideInInspector]
public GameObject[,] drawArray = new GameObject[100, 100];


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
                newImage.transform.localScale= new Vector3(4,4,1);
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
     
        SceneManager.LoadScene("AlbumTestr");
        
    }
}
