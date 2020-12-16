using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LineData
{
    public ArrayList LineX = new ArrayList();
    public ArrayList LineY = new ArrayList();
    public ArrayList ChildArrayX = new ArrayList();
    public ArrayList ChildArrayY = new ArrayList();


    public LineData(SaveManager saveManager)
    {
     LineX = saveManager.lineArrayX;
     LineY = saveManager.lineArrayY;
     ChildArrayX = saveManager.ChildArrayX;
     ChildArrayY = saveManager.ChildArrayY;
    }
}