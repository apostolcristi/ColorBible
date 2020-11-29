using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShapesManagerCarousel : MonoBehaviour
{
    
    public GameObject Shapes;
    public ImageHolder imageHolder;
    public GameObject groupImages;
    public TextMeshProUGUI nameTitle;
    public GameObject nextButton, previousButton;
    
    private int imageCounter=0;
    private GameObject[] groupArray = new GameObject[100];
    private GameObject[] ShapespArray = new GameObject[100];

    private float roundedGroups;
    private int titleCounter=0;
    private int currentPlace = 0;
   
    
    
    void Start()
    {
       InstantiateShapes();

       for (int i = 0; i < groupArray.Length; i++)
       {
           if (i == 0)
           {
               groupArray[i].SetActive(true);
           }
           else
           { 
               groupArray[i].SetActive(false);
           }
       }
    }
    
    void Update()
    {
        if (currentPlace == 0)
        {
            previousButton.SetActive(false);
        }
        else
        { 
            previousButton.SetActive(true);
        }
         if (currentPlace == roundedGroups - 1)
        {
            nextButton.SetActive(false);
        }
         else
         {
             nextButton.SetActive(true);
         }
     
        
    }

    private void InstantiateShapes()
    {
         roundedGroups = Mathf.Ceil(imageHolder.title.Length / 2f);
  
        for (int i = 0; i < roundedGroups; i++)
        {
            GameObject newGroup = Instantiate(groupImages, gameObject.transform.position, Quaternion.identity);
            newGroup.transform.parent = gameObject.transform;
            
            newGroup.transform.localScale = new Vector3(1,1,1);
            

            for (int j = 0; j < 2; j++)
            {
                GameObject newShapes = Instantiate(Shapes, gameObject.transform.position, Quaternion.identity);
                newShapes.transform.parent = newGroup.transform;
                
                newShapes.transform.localScale = new Vector3(1,1,1);
                
               
                
                TextMeshProUGUI copyTitle = Instantiate(nameTitle, newShapes.transform.position, Quaternion.identity);
                copyTitle.transform.parent = newShapes.transform;

                copyTitle.transform.localScale =new Vector3(1, 1, 1);
                copyTitle.transform.localPosition =new Vector3(0, -150, 0);
                
                if (j % 2 == 0)
                {
                    newShapes.transform.localPosition= new Vector3(-250,0,0);
                    newShapes.name = "Shape-" + (titleCounter+1);
                    copyTitle.text = imageHolder.title[titleCounter];
                }
               else
                if(j%2!=0)
                {
                    newShapes.transform.localPosition= new Vector3(250,0,0);
                    if (titleCounter < imageHolder.title.Length)
                    {
                        newShapes.name = "Shape-" + (titleCounter+1);
                        copyTitle.text = imageHolder.title[titleCounter];
                    }
                    if (imageHolder.title.Length % 2 != 0 && i==roundedGroups-1)
                    {
                        Destroy(newShapes);
                        Destroy(copyTitle);
                        titleCounter--;
                        break;
                    }
                }

                
                    GameObject newImages = Instantiate(imageHolder.arrays[imageCounter++].objects[0],
                        newShapes.transform.GetChild(0).transform.position, Quaternion.identity);

                    newImages.transform.parent = newShapes.transform.GetChild(1).transform;
                    newImages.transform.localScale = new Vector3(1.75f,1.75f,1.75f);

                    ShapespArray[titleCounter++] = newShapes;

            }
            groupArray[i] = newGroup;
           
        }
        
    }
   

    public void NextSets()
    {
        if (currentPlace < roundedGroups-1)
        {
            groupArray[currentPlace].SetActive(false);
            groupArray[++currentPlace].SetActive(true);
        }
   
     
    }
    public void PreviousSets()
    {
        if (currentPlace >0)
        {
            groupArray[currentPlace].SetActive(false);
            groupArray[--currentPlace].SetActive(true);
        }

    }
     
        
       
}

