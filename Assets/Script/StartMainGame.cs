using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMainGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InstantiateImages.imageArray[ImageOrder.imageSet,InstantiateImages.imageNumber].GetComponent<SaveManager>().LoadColor();
    }

   
}
