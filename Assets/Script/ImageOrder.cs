using System;
using System.Collections;
using System.Collections.Generic;
using IndieStudio.DrawingAndColoring.Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class ImageOrder : MonoBehaviour
{
    public ImageHolder imageHolder;
    public TextMeshProUGUI title;
    public GameObject drawManager;
    public GameObject drawChild;
    
    private GameObject[] drawLine1;
    
    public static int imageSet = 1;
    void Start()
    {
        title.text = "Image set " + imageSet;
        if (imageSet == 1)
        {
            InitializeSet1();
        }
        else if(imageSet==2)
        {
            InitializeSet2();
        }

    }


    void Update()
    {
        
    }

    private void InitializeSet1()
    {
        
        float Lines =Mathf.Ceil(imageHolder.imageset1.Length / 4.0f);
        float LinesUnfinished = imageHolder.imageset1.Length % 4.0f;
        
            for (int i = 0; i < Lines; i++)
            {
                if (i < Lines - 1)
                {
                    GameObject drawManagerGameObject = Instantiate(drawManager, new Vector3(0, 0, 0), Quaternion.identity);

                    drawManagerGameObject.transform.parent = gameObject.transform;
                    for (int j = 0; j < 4; j++)
                    {
                        GameObject drawChildGameObject = Instantiate(drawChild, new Vector3(252 * j, 0, 0), Quaternion.identity);
                        drawChildGameObject.transform.parent = drawManagerGameObject.transform;
                        
                        GameObject newImage = Instantiate(imageHolder.imageset1[j + i * 4], drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                        newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
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
                            GameObject drawChildGameObject = Instantiate(drawChild, new Vector3(252 * j, 0, 0), Quaternion.identity);
                            drawChildGameObject.transform.parent = drawManagerGameObject.transform;
                            
                            GameObject newImage = Instantiate(imageHolder.imageset1[j + i * 4], drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                            newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            GameObject drawChildGameObject = Instantiate(drawChild, new Vector3(252 * j, 0, 0), Quaternion.identity);
                            drawChildGameObject.transform.parent = drawManagerGameObject.transform;
                            
                            GameObject newImage = Instantiate(imageHolder.imageset1[j + i * 4], drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                            newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
                        }
                    }
                }
            }

    }

    private void InitializeSet2()
    {


        float Lines = Mathf.Ceil(imageHolder.imageset2.Length / 4.0f);
        float LinesUnfinished = imageHolder.imageset2.Length % 4.0f;

        for (int i = 0; i < Lines; i++)
        {
            if (i < Lines - 1)
            {
                GameObject drawManagerGameObject = Instantiate(drawManager, new Vector3(0, 0, 0), Quaternion.identity);

                drawManagerGameObject.transform.parent = gameObject.transform;
                for (int j = 0; j < 4; j++)
                {
                    GameObject drawChildGameObject =
                        Instantiate(drawChild, new Vector3(252 * j, 0, 0), Quaternion.identity);
                    drawChildGameObject.transform.parent = drawManagerGameObject.transform;

                    GameObject newImage = Instantiate(imageHolder.imageset2[j + i * 4],
                        drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                    newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
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
                        GameObject drawChildGameObject =
                            Instantiate(drawChild, new Vector3(252 * j, 0, 0), Quaternion.identity);
                        drawChildGameObject.transform.parent = drawManagerGameObject.transform;

                        GameObject newImage = Instantiate(imageHolder.imageset2[j + i * 4],
                            drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                        newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
                    }
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        GameObject drawChildGameObject =
                            Instantiate(drawChild, new Vector3(252 * j, 0, 0), Quaternion.identity);
                        drawChildGameObject.transform.parent = drawManagerGameObject.transform;

                        GameObject newImage = Instantiate(imageHolder.imageset2[j + i * 4],
                            drawChildGameObject.transform.GetChild(0).position, Quaternion.identity);
                        newImage.transform.parent = drawChildGameObject.transform.GetChild(0).transform;
                    }
                }
            }
        }
    }
}

