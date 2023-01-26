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
        Debug.Log("Save" + jsonString);
        File.WriteAllText(savefile, jsonString);
    }

    public static void Load()
    {
        if (File.Exists(savefile) == false)
        {
            return;
        }

        string fileContents = File.ReadAllText(savefile);
        MiniGameData GameData = JsonUtility.FromJson<MiniGameData>(fileContents);
        MiniGameData.FirstVisit = GameData.firstVisit;
        MiniGameData.ChoppingHighscore = GameData.choppingHighscore;
        MiniGameData.StoneMiningHighscore = GameData.stoneMiningHighscore;
        Debug.Log("Load: " + fileContents);
    }


}
