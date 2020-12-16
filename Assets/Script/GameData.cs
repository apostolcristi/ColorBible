using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData
{
    public ArrayList hex= new ArrayList();

    public GameData(SaveManager saveManager)
    {

        hex = saveManager.colorPartArray;

    }
    
}
