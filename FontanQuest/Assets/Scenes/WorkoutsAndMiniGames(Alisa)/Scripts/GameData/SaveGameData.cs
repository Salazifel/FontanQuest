using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    private static string savefile = Application.persistentDataPath + "/MiniGameData.json";


    public static void Save()
    {

        if (File.Exists(savefile))
        {
            File.Delete(savefile);
        }

        MiniGameData data = new MiniGameData();
        string jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(savefile, jsonString);
    }

    public static void Load()
    {
        if (File.Exists(savefile) == false)
        {
            return;
        }
        //read
        string fileContents = File.ReadAllText(savefile);
        //load
        MiniGameData GameData = JsonUtility.FromJson<MiniGameData>(fileContents);
        //update for the rest of the game
        MiniGameData.UpdateGamedate(GameData);
  }


}
