using System;
using System.Collections;
using System.Collections.Generic;
using IndieStudio.DrawingAndColoring.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class ImageOrder : MonoBehaviour
{
    
    public ImageHolder imageHolder;
    public TextMeshProUGUI title;
    public GameObject drawManager;
    public GameObject drawChild;
    

    
    public static int imageSet = 0;
    void Start()
    {
        title.text = "Set de imagine " + (imageSet + 1);
      
           // InitializeSet();
        Initialize();
    
    }


    void Update()
    {
        
    }

  /*  private void InitializeSet()
    {
        float Lines =Mathf.Ceil(imageHolder.arrays[imageSet].objects.Length / 4.0f);
        float LinesUnfinished = imageHolder.arrays[imageSet].objects.Length % 4.0f;
        
            for (int i = 0; i < Lines; i++)
            {
                if (i < Lines - 1)
                {
                    GameObject drawManagerGameObject = Instantiate(drawManager, new Vector3(0, 0, 0), Quaternion.identity);

                    drawManagerGameObject.transform.parent = gameObject.transform;
                    for (int j = 0; j < 4; j++)
                    {
                        GameObject drawChildGameObject = Instantiate(drawChild, drawManagerGameObject.transform.position, Quaternion.identity);
                        drawChildGameObject.transform.parent = drawManagerGameObject.transform;

                        GameObject newImage = Instantiate(imageHolder.arrays[imageSet].objects[j + i * 4], drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                        newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
                        
                         newImage.GetComponent<Button> ().onClick.AddListener (() =>newImage.GetComponent<ImageID>().ImageActive() );
                        newImage.name += "-" + (j + i * 4);
                    }
                }
                else if (i == Lines - 1)
                { 
                    GameObject drawManagerGameObject = Instantiate(drawManager, new Vector3(0, 0, 0), Quaternion.identity);

                    drawManagerGameObject.transform.parent = gameObject.transform;
                    if (LinesUnfinished != 0)
                    {
                        for (int j = 0; j < LinesUnfinished; j++)
                        {
                            GameObject drawChildGameObject = Instantiate(drawChild, drawManagerGameObject.transform.position, Quaternion.identity);
                            drawChildGameObject.transform.parent = drawManagerGameObject.transform;
                            
                            GameObject newImage = Instantiate(imageHolder.arrays[imageSet].objects[j + i * 4], drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                            newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
                            
                            newImage.GetComponent<Button> ().onClick.AddListener (() =>newImage.GetComponent<ImageID>().ImageActive() );
                            newImage.name += "-" + (j + i * 4);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            GameObject drawChildGameObject = Instantiate(drawChild, new Vector3(252 * j, 0, 0), Quaternion.identity);
                            drawChildGameObject.transform.parent = drawManagerGameObject.transform;
                            
                            GameObject newImage = Instantiate(imageHolder.arrays[imageSet].objects[j + i * 4], drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                            newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
                            
                            newImage.GetComponent<Button> ().onClick.AddListener (() =>newImage.GetComponent<ImageID>().ImageActive() );
                            newImage.name += "-" + (j + i * 4);
                        }
                    }
                }
            }
    }    */

  private void Initialize()
  {
      for (int i = 0; i < imageHolder.arrays[imageSet].objects.Length; i++)
      {
          GameObject drawChildParent = Instantiate(drawChild,transform.position,Quaternion.identity);
          drawChildParent.transform.SetParent(gameObject.transform);
          drawChildParent.transform.localScale=new Vector3(1.5f, 1.5f, 1);
          GameObject newImage = Instantiate(imageHolder.arrays[imageSet].objects[i], drawChildParent.transform.GetChild(0).position, Quaternion.identity);
          drawChildParent.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = newImage.GetComponent<Image>().sprite.name;
          newImage.transform.SetParent(drawChildParent.transform);
          newImage.transform.localScale=new Vector3(1f, 1f, 1);
          newImage.GetComponent<Button>().onClick.AddListener(()=>newImage.GetComponent<ImageID>().ImageActive());
          newImage.GetComponent<Button>().onClick.AddListener(()=>GameObject.Find("SFXSound").GetComponent<DontDestroySFX>().ButtonPress());
          newImage.name += "-" + i;
      }
  }


}
    


