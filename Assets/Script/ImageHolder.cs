using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;




[System.Serializable]
public class GameObjectArray
{
    [HideInInspector] public string mainTitle;
   public GameObject[] objects;
    

}

[ExecuteAlways]
public class ImageHolder : MonoBehaviour 
{
    
    public string[] title;
    
    public GameObjectArray[] arrays;
    private bool isPurchased=false;
    private int number;

    private void OnValidate()
    {
      
        number = title.Length;
        Array.Resize(ref arrays,number);
        for (int i = 0; i < title.Length; i++)
        {
            arrays[i].mainTitle = title[i];
            
        }
    }

    void Start()
    {
        
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    
}
