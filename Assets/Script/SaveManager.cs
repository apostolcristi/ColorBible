using System;
using System.Collections;
using System.Collections.Generic;
using IndieStudio.DrawingAndColoring.Logic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    [HideInInspector] public string colorPart;
    [HideInInspector] public string childBinaryStringNumber;
    public ArrayList colorPartArray = new ArrayList();
    public ArrayList lineArrayX = new ArrayList();
    public ArrayList lineArrayY = new ArrayList();
    public ArrayList ChildArrayX = new ArrayList();
    public ArrayList ChildArrayY = new ArrayList();
    public ArrayList StampArray = new ArrayList();
    private int childrenSize;
    private int lineK=0; 
    private int stampK=0;



    public void Update()
    {

    }

    public void WhiteScreen()
    {
        
        
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

        SaveSystem.SavePart(this, ImageOrder.imageSet, InstantiateImages.imageNumber);
        colorPartArray.Clear();
    }

    public void LoadColor()
    {

        GameObject partsParent = gameObject.transform.GetChild(0).gameObject;

        string[] colorPartHex;
        for (int i = 0; i < partsParent.transform.childCount; i++)
        {
            SpriteRenderer currentChild = partsParent.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();

            Color newColor;

            GameData data = SaveSystem.LoadPart(ImageOrder.imageSet, InstantiateImages.imageNumber);
            colorPart = data.hex[i].ToString();

            colorPartHex = colorPart.Split('-');
            colorPart = colorPartHex[3];
            ColorUtility.TryParseHtmlString("#" + colorPart, out newColor);
            currentChild.GetComponent<ShapePart>().SetColor(newColor);


        }
    }



    public void SaveLine()
    {
        childrenSize = gameObject.transform.childCount;

        lineK = 0;
        int f = 0;

        for (int i = 0; i < childrenSize; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.name == "Line(Clone)" || gameObject.transform.GetChild(i).gameObject.name =="Line")
            {
                
                GameObject lrGet = gameObject.transform.GetChild(i).gameObject;
                int verticesCount = lrGet.gameObject.GetComponent<LineRenderer>().positionCount;
                int matNum = -1;
                float ab = lrGet.GetComponent<LineRenderer>().colorGradient.colorKeys[0].color.r;
                float ac = lrGet.GetComponent<LineRenderer>().colorGradient.colorKeys[0].color.g;
                float ad = lrGet.GetComponent<LineRenderer>().colorGradient.colorKeys[0].color.b;

                float ab1 = lrGet.GetComponent<LineRenderer>().colorGradient.colorKeys[1].color.r;
                int gradientNr;
                if (ab1 == ab)
                {
                    gradientNr = 0;
                }
                else
                {
                    gradientNr = 1;
                }

                float alpha = lrGet.GetComponent<LineRenderer>().colorGradient.alphaKeys[0].alpha;
                float width = lrGet.GetComponent<LineRenderer>().endWidth;
                Color color = new Color(ab, ac, ad);
                string colorHexLine = ColorUtility.ToHtmlStringRGB(color);
                Vector3[] newLine = new Vector3[verticesCount];
                lrGet.GetComponent<LineRenderer>().GetPositions(newLine);
                Debug.Log(lrGet.GetComponent<LineRenderer>().material.name);
                if (lrGet.GetComponent<LineRenderer>().material.name == "Normal (Instance)")
                {
                    matNum = 0;

                }
                else if (lrGet.GetComponent<LineRenderer>().material.name == "Crayon (Instance)")

                {
                    matNum = 1;
                }
                else if (lrGet.GetComponent<LineRenderer>().material.name == "Water (Instance)")
                {
                    matNum = 2;

                }
                else if (lrGet.GetComponent<LineRenderer>().material.name == "Sprites/Default (Instance)" ||
                         lrGet.GetComponent<LineRenderer>().material.name == "Stars (Instance)")
                {
                    matNum = 3;
                }


                int childNumberLrGet = lrGet.transform.childCount;

                string newLineXString;
                string newLineYString;

                for (int j = 0; j < verticesCount; j++)
                {
                    newLineXString = newLine[j].x.ToString() + "(" + verticesCount + "(" + colorHexLine + "(" + matNum +
                                     "(" + childNumberLrGet + "(" + alpha + "(" + width + "(" + gradientNr;
                    newLineYString = newLine[j].y.ToString() + "(" + verticesCount + "(" + colorHexLine + "(" + matNum +
                                     "(" + childNumberLrGet + "(" + alpha + "(" + width + "(" + gradientNr;
                    lineArrayX.Add(newLineXString);
                    lineArrayY.Add(newLineYString);
                }


                if (childNumberLrGet != 0)
                {

                    for (int k = 0; k < childNumberLrGet; k++)
                    {
                        Vector3[] childLrGetPos = new Vector3[2];
                        string newChildXString1 = " ";
                        string newChildXString2 = " ";
                        string newChildYString1 = " ";
                        string newChildYString2 = " ";
                        GameObject childLrGet = lrGet.transform.GetChild(k).gameObject;
                        childLrGet.GetComponent<LineRenderer>().GetPositions(childLrGetPos);

                        newChildXString1 = childLrGetPos[0].x.ToString() + "(" +
                                           childLrGet.GetComponent<LineRenderer>().startWidth.ToString() + "(" +
                                           childLrGet.GetComponent<LineRenderer>().endWidth.ToString() + "(" +
                                           colorHexLine;
                        newChildYString1 = childLrGetPos[0].y.ToString() + "(" +
                                           childLrGet.GetComponent<LineRenderer>().startWidth.ToString() + "(" +
                                           childLrGet.GetComponent<LineRenderer>().endWidth.ToString() + "(" +
                                           colorHexLine;
                        newChildXString2 = childLrGetPos[1].x.ToString() + "(" +
                                           childLrGet.GetComponent<LineRenderer>().startWidth.ToString() + "(" +
                                           childLrGet.GetComponent<LineRenderer>().endWidth.ToString() + "(" +
                                           colorHexLine;
                        newChildYString2 = childLrGetPos[1].y.ToString() + "(" +
                                           childLrGet.GetComponent<LineRenderer>().startWidth.ToString() + "(" +
                                           childLrGet.GetComponent<LineRenderer>().endWidth.ToString() + "(" +
                                           colorHexLine;


                        ChildArrayX.Add(newChildXString1);
                        ChildArrayX.Add(newChildXString2);
                        ChildArrayY.Add(newChildYString1);
                        ChildArrayY.Add(newChildYString2);
                    }

/*
                foreach (var x in ChildArrayY)
                {
                    Debug.Log(x.ToString());
                }
                */
                }
                
                SaveSystem.SaveLine(this, ImageOrder.imageSet, InstantiateImages.imageNumber, f);
                f++;
                lineArrayX.Clear();
                lineArrayY.Clear();
                ChildArrayX.Clear();
                ChildArrayY.Clear();
                Destroy(gameObject.transform.GetChild(i).gameObject);

                lineK++;
            }
           PlayerPrefs.SetInt("lineK " + ImageOrder.imageSet + InstantiateImages.imageNumber,lineK);
        }
    }

    public void SaveStamp()
    {
        stampK = 0;
        childrenSize = gameObject.transform.childCount;
        int l = 0;
        
        for (int i = 0; i < childrenSize; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.name == "Stamp")
            {
                
                GameObject stampGet = gameObject.transform.GetChild(i).gameObject;

                int stampNr=-1;
                string chestie = stampGet.GetComponent<SpriteRenderer>().sprite.name;
                switch (chestie)
                {
                    case "AppleGreen-Stamp": stampNr = 0; break;
                    case "Black-Stamp": stampNr = 1; break;
                    case "Brown-Stamp": stampNr = 2; break;
                    case "Cyan-Stamp": stampNr = 3; break;
                    case "Gray-Stamp": stampNr = 4; break;
                    case "HotPink-Stamp": stampNr = 5; break;
                    case "LightBrown-Stamp": stampNr = 6; break;
                    case "NavyBlue-Stamp": stampNr = 7; break;
                    case "Orange-Stamp": stampNr = 8; break;
                    case "Pink-Stamp": stampNr = 9; break;
                    case "Purple-Stamp": stampNr = 10; break;
                    case "Red-Stamp": stampNr = 11; break;
                    case "TreeGreen-Stamp": stampNr = 12; break;
                    case "Yellow-Stamp": stampNr = 13; break;
                    
                    default: break;
                    
                    }

                string xCoord = stampGet.transform.position.x.ToString();
                string yCoord = stampGet.transform.position.y.ToString();
                string binarStamp = stampNr.ToString() + "(" + xCoord+ "(" + yCoord;
                StampArray.Add(binarStamp);
                SaveSystem.SaveStamp(this, ImageOrder.imageSet, InstantiateImages.imageNumber,l);
                l++;
                StampArray.Clear();
                Destroy(gameObject.transform.GetChild(i).gameObject);
                stampK++;
            }
    
        }
   
        PlayerPrefs.SetInt("stampK " + ImageOrder.imageSet + InstantiateImages.imageNumber,stampK);

    }
}