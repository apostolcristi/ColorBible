using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    //TODO: When we will have partts
    // public static void SavePart(SaveManager saveManager ,int SetNumber,int ImageNumber)
    // {
    //     BinaryFormatter formatter = new BinaryFormatter();
    //
    //     string path = Application.persistentDataPath + "/" + SetNumber + "." + ImageNumber;
    //     
    //     FileStream stream =  new FileStream(path,FileMode.Create);
    //     GameData data = new GameData(saveManager);
    //     
    //     formatter.Serialize(stream,data);
    //     stream.Close();
    // }
    //
    // public static GameData LoadPart(int SetNumber,int ImageNumber)
    // {
    //
    //     string path = Application.persistentDataPath + "/" + SetNumber + "." + ImageNumber;
    //
    //     if (File.Exists(path))
    //     {
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         FileStream stream =  new FileStream(path,FileMode.Open);
    //
    //       GameData data = formatter.Deserialize(stream) as GameData; 
    //       
    //       stream.Close();
    //       
    //       return data;
    //     }
    //     else
    //     {
    //         Debug.Log("Save file not found in "+path);
    //         return null;
    //     }
    // }
    
    public static void SaveLine(SaveManager saveManager, int SetNumber,int ImageNumber, int index)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/childSize-" + SetNumber + "-" + ImageNumber + "-" + index  +".fun";
        
        FileStream stream =  new FileStream(path,FileMode.Create);
        LineData data = new LineData(saveManager);
        
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static LineData LoadLine(int SetNumber,int ImageNumber, int index)
    {
    
        string path = Application.persistentDataPath + "/childSize-" + SetNumber + "-" + ImageNumber + "-" + index +".fun";
    
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream =  new FileStream(path,FileMode.Open);

            LineData data = formatter.Deserialize(stream) as LineData; 
          
            stream.Close();
          
            return data;
        }
        else
        {
            Debug.Log("Save file not found in "+path);
            return null;
        }
    }
    public static void SaveStamp(SaveManager saveManager, int SetNumber,int ImageNumber,int index)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/Stamp-" + SetNumber + "-" + ImageNumber + "-" + index + ".fun";
        
        FileStream stream =  new FileStream(path,FileMode.Create);
        StampData data = new StampData(saveManager);
        
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static StampData LoadStamp(int SetNumber,int ImageNumber,int index)
    {
    
        string path = Application.persistentDataPath + "/Stamp-" + SetNumber + "-" + ImageNumber + "-" + index + ".fun";
    
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream =  new FileStream(path,FileMode.Open);

            StampData data = formatter.Deserialize(stream) as StampData; 
          
            stream.Close();
          
            return data;
        }
        else
        {
            Debug.Log("Save file not found in "+path);
            return null;
        }
    }

    public static void DeleteStamp(int SetNumber, int ImageNumber, int index)
    {
        string path = Application.persistentDataPath + "/Stamp-" + SetNumber + "-" + ImageNumber + "-" + index + ".fun";
        File.Delete(path);
    }
    public static void DeleteLine(int SetNumber, int ImageNumber, int index)
    {
        string path = Application.persistentDataPath + "/childSize-" + SetNumber + "-" + ImageNumber + "-" + index +".fun";
        File.Delete(path);
    }
}
