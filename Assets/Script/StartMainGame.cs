using System;
using System.Collections;
using System.Collections.Generic;
using IndieStudio.DrawingAndColoring.Logic;
using UnityEngine;

public class StartMainGame : MonoBehaviour
{

    public GameObject linePrefab;

    private GameObject line;

    private Vector3[] lineCoord;

    private bool ready = false;
  

    public Material[] mat;

    public Sprite[] sprites;

    public GameObject undo, redo;

    public GameObject redoHolder;

    public GameObject paintLine;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateImages.imageArray[ImageOrder.imageSet,InstantiateImages.imageNumber].GetComponent<SaveManager>().LoadColor();
         
            
    }

    private void Update()
    {
        if (ready == false)
        {
            ready = true;
            LoadLines();
            LoadStamps();
        }

       
    }

    public void LoadLines()
    {
        int lineK = PlayerPrefs.GetInt("lineK " + ImageOrder.imageSet + InstantiateImages.imageNumber);
        string[] binarData;

        for (int i = 0; i <lineK ; i++)
        {
            line = Instantiate(linePrefab, transform.position, Quaternion.identity);
            Line lineComponent = line.GetComponent<Line>();
            LineData lineData = SaveSystem.LoadLine(ImageOrder.imageSet, InstantiateImages.imageNumber, i);
   
            string LineStringSize = lineData.LineX[0].ToString();
            binarData = LineStringSize.Split('(');
            
            int size = int.Parse(binarData[1]);
            int matNumber = int.Parse(binarData[3]);
            int childSizeLine = int.Parse(binarData[4]);
            float alpha = float.Parse(binarData[5]);
            float width = float.Parse(binarData[6]);
            int gradientNr = int.Parse(binarData[7]);
            string colorLineHex = binarData[2].ToString();
            line.GetComponent<LineRenderer>().positionCount = size;
            lineCoord = new Vector3[size];
            for (int j = 0; j < size; j++)
            {
                string LineXString = lineData.LineX[j].ToString();
                string LineYString = lineData.LineY[j].ToString();
                string[] binarDataX = LineXString.Split('(');
                string[] binarDataY = LineYString.Split('(');
                float XCoord = float.Parse(binarDataX[0]);
                float YCoord = float.Parse(binarDataY[0]);
                lineCoord[j] = new Vector3(XCoord, YCoord, 0);

            }

            if (childSizeLine != 0)
            {
                string[] splitDataX1;
                string[] splitDataX2;
                string[] splitDataY1;
                string[] splitDataY2;
                for (int k = 0; k < childSizeLine; k++)
                {
                    Color ColorChildLine;
                    Gradient childGradient = new Gradient();
                    
                    GameObject paintLinePb = Instantiate(paintLine, transform.position, Quaternion.identity);
                    Vector3[] childLineCoord = new Vector3[2];

                    string binarFormatX1 = lineData.ChildArrayX[k * 2].ToString();
                    string binarFormatX2 = lineData.ChildArrayX[k * 2 + 1].ToString();
                    string binarFormatY1 = lineData.ChildArrayY[k * 2].ToString();
                    string binarFormatY2 = lineData.ChildArrayY[k * 2 + 1].ToString();

                    splitDataX1 = binarFormatX1.Split('('); 
                    splitDataX2 = binarFormatX2.Split('('); 
                    splitDataY1 = binarFormatY1.Split('('); 
                    splitDataY2 = binarFormatY2.Split('('); 
                    
                    
                    float XCoord1 = float.Parse(splitDataX1[0]);
                    float XCoord2 = float.Parse(splitDataX2[0]);
                    float YCoord1 = float.Parse(splitDataY1[0]);
                    float YCoord2 = float.Parse(splitDataY2[0]);

                    string colorCode = splitDataX1[3];
                    
                    childLineCoord[0] = new Vector3(XCoord1, YCoord1, 0);
                    childLineCoord[1] = new Vector3(XCoord2, YCoord2, 0);

                    ColorUtility.TryParseHtmlString("#" + colorCode,out ColorChildLine);
                    childGradient.SetKeys(new GradientColorKey[] {new GradientColorKey(ColorChildLine,1f), }, new GradientAlphaKey[]{new GradientAlphaKey(1f,1f), });
                    paintLinePb.GetComponent<LineRenderer>().colorGradient = childGradient;

                    float widthChildStart = float.Parse(splitDataX1[1]);
                    float widthChildEnd = float.Parse(splitDataX1[2]);
                    paintLinePb.GetComponent<LineRenderer>().material = mat[0];
                    paintLinePb.GetComponent<LineRenderer>().widthCurve = AnimationCurve.Linear(0f,widthChildStart,1f,widthChildEnd);
                    
                    paintLinePb.GetComponent<LineRenderer>().SetPositions(childLineCoord);
                    paintLinePb.transform.SetParent(line.transform);

                }
            }
            if (matNumber == 1)
            {
                line.GetComponent<LineRenderer>().textureMode = LineTextureMode.Tile;
            }
            else if (matNumber == 3)
            {
                line.GetComponent<LineRenderer>().textureMode = LineTextureMode.Tile;
                Destroy(lineComponent);
                line.GetComponent<LineRenderer>().numCapVertices = 0;
            }
            else
            {
                line.GetComponent<LineRenderer>().textureMode = LineTextureMode.Stretch;
            }
        

            Color ColorLine;
            ColorUtility.TryParseHtmlString("#" + colorLineHex,out ColorLine);
            Gradient gradient = new Gradient();
            if (gradientNr == 1)
            {
                gradient.SetKeys(new GradientColorKey[] {new GradientColorKey(Color.red,0f), new GradientColorKey(Color.green, .15f),new GradientColorKey(Color.blue, .28f),new GradientColorKey(Color.cyan, .55f)
                    ,new GradientColorKey(Color.magenta,.72f) , new GradientColorKey(Color.yellow,.86f),new GradientColorKey(Color.magenta,1f) },new GradientAlphaKey[]{ new GradientAlphaKey(alpha,1f), } );
            }
            else
            {
                gradient.SetKeys(new GradientColorKey[] {new GradientColorKey(ColorLine,1f), },new GradientAlphaKey[]{ new GradientAlphaKey(alpha,1f), } );
            }
           
            gradient.mode = GradientMode.Blend;
            line.GetComponent<LineRenderer>().widthCurve = AnimationCurve.Constant(1,1,width);
            line.GetComponent<LineRenderer>().colorGradient = gradient;
            line.GetComponent<LineRenderer>().material = mat[matNumber];
            Debug.Log(ColorLine);
            line.transform.SetParent(InstantiateImages.drawArray[ImageOrder.imageSet,InstantiateImages.imageNumber].transform);
             line.GetComponent<LineRenderer>().SetPositions(lineCoord);

        }
     
    }

    public void LoadStamps()
    {
        int stampK = PlayerPrefs.GetInt("stampK " + ImageOrder.imageSet + InstantiateImages.imageNumber);
        Debug.Log(stampK);
        string[] stampArray;
        
        for (int i = 0; i < stampK; i++)
        {
         
            StampData stampData = SaveSystem.LoadStamp(ImageOrder.imageSet, InstantiateImages.imageNumber,i);
            GameObject stampImg = new GameObject("Stamp");
            string stampString = stampData.stampArray[0].ToString();
            stampArray = stampString.Split('(');
            
            int spriteNr = int.Parse(stampArray[0].ToString());
            float xCoord = float.Parse(stampArray[1].ToString());
            float yCoord = float.Parse(stampArray[2].ToString());
            stampImg.AddComponent<SpriteRenderer>().sprite = sprites[spriteNr];
            stampImg.GetComponent<SpriteRenderer>().material = mat[4];
            stampImg.AddComponent<RectTransform>().localScale = new Vector3(0.64f,0.64f,0.64f);
            stampImg.GetComponent<RectTransform>().localPosition = new Vector3(xCoord,yCoord,0f);
            
            stampImg.layer = 9;
            stampImg.transform.SetParent(InstantiateImages.drawArray[ImageOrder.imageSet,InstantiateImages.imageNumber].transform);
         
        }
    }

    public void Undo()
    {
      int lastChild =InstantiateImages.drawArray[ImageOrder.imageSet, InstantiateImages.imageNumber].transform.childCount -1;
      Debug.Log(lastChild);

      Transform lastChildTransform =InstantiateImages.drawArray[ImageOrder.imageSet, InstantiateImages.imageNumber].transform
          .GetChild(lastChild);

      lastChildTransform.SetParent(redoHolder.transform);
      lastChildTransform.gameObject.SetActive(false);
          
    
    }
    public void Redo()
    {
        int lastChild =redoHolder.transform.childCount -1;
        Debug.Log(lastChild);

        Transform lastChildTransform = redoHolder.transform.GetChild(lastChild);
               lastChildTransform.SetParent(InstantiateImages.drawArray[ImageOrder.imageSet, InstantiateImages.imageNumber].transform);
               lastChildTransform.gameObject.SetActive(true);

    }

    public void Trash()
    {
        for (int i = 0; i < InstantiateImages.drawArray[ImageOrder.imageSet, InstantiateImages.imageNumber].transform.childCount; i++)
        {
            Destroy( InstantiateImages.drawArray[ImageOrder.imageSet, InstantiateImages.imageNumber].transform.GetChild(i).gameObject); 
            SaveSystem.DeleteStamp(ImageOrder.imageSet, InstantiateImages.imageNumber,i);
            SaveSystem.DeleteLine(ImageOrder.imageSet, InstantiateImages.imageNumber,i);
            
            
        }
            
        GameObject partsParent = InstantiateImages.imageArray[ImageOrder.imageSet, InstantiateImages.imageNumber].transform.GetChild(0).gameObject;
        for (int i = 0; i < partsParent.transform.childCount; i++)
        {
            partsParent.transform.GetChild(i).gameObject.GetComponent<ShapePart>().SetColor(Color.white);
        }
    }
}
