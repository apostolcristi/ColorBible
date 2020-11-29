using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicButton : MonoBehaviour
{

    
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => InstantiateImages.instance.Album());
    }


    void Update()
    {
      
    }
}
