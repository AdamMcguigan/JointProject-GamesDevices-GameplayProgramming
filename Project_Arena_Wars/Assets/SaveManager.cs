using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";
    public static void save(saveObject so)
    {
        string dir = Application.persistentDataPath + directory;

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }

    public static saveObject load()
    {
        string fullpath = Application.persistentDataPath + directory + fileName;
        saveObject so = new saveObject();

        if (File.Exists(fullpath))
        {
            string json = File.ReadAllText(fullpath);
            so = JsonUtility.FromJson<saveObject>(json);
        }
        else
        {
            Debug.Log("Save File does not exist ");
        }

        return so;
    }

}
