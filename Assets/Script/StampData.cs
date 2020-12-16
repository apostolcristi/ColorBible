using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StampData
{
    public ArrayList stampArray = new ArrayList();


    public StampData(SaveManager saveManager)
    {
        stampArray = saveManager.StampArray;
    }
}