using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SavePart(SaveManager saveManager ,int i,int j)
    {
        BinaryFormatter formatter = new BinaryFormatter();
 
        string path = Application.persistentDataPath + "/" + i + "." + j;
        
        FileStream stream =  new FileStream(path,FileMode.Create);
        GameData data = new GameData(saveManager);
        
        formatter.Serialize(stream,data);
        stream.Close();
    }

    public static GameData LoadPart(int i,int j)
    {
    
        string path = Application.persistentDataPath + "/" + i + "." + j;
    
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream =  new FileStream(path,FileMode.Open);

          GameData data = formatter.Deserialize(stream) as GameData; 
          
          stream.Close();
          
          return data;
        }
        else
        {
            Debug.Log("Save file not found in "+path);
            return null;
        }
    }
    
}
