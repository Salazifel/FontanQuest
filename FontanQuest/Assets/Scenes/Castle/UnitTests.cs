using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UnitTests : MonoBehaviour
{
    public DateTime currentDebugDate;
    void Awake() {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData)SaveGameObjects.CreateSaveGameObject("GameData");
        }
        currentDebugDate = gameData.currentDebugTime;
    }

    public void resetSaveFile()
    {
        DeleteAllFilesAndFolders(Application.persistentDataPath);

        SaveGameMechanic.saveSaveGameObject(SaveGameObjects.CreateSaveGameObject("BuiltBuildings"), "BuiltBuildings", 1);
        SaveGameMechanic.saveSaveGameObject(SaveGameObjects.CreateSaveGameObject("CastleOnBoardingSystem"), "CastleOnBoardingSystem", 1);
        
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData)SaveGameObjects.CreateSaveGameObject("GameData");
        }
        gameData.currentDebugTime = DateTime.Today;
        currentDebugDate = DateTime.Today;

        SaveGameMechanic.saveSaveGameObject(gameData, "GameData", 1);
        SceneManager.Load("CastleOnboarding");

        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadButtons();
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
    }

    private void DeleteAllFilesAndFolders(string targetDirectoryPath)
    {
        // Delete all files in the directory
        string[] files = Directory.GetFiles(targetDirectoryPath);
        foreach (string file in files)
        {
            File.Delete(file);
        }

        // Delete all folders and their contents
        string[] folders = Directory.GetDirectories(targetDirectoryPath);
        foreach (string folder in folders)
        {
            DeleteAllFilesAndFolders(folder); // Recursively delete all files and folders
            Directory.Delete(folder); // Then delete the folder itself
        }
    }

    public void AddDay()
    {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData) SaveGameObjects.CreateSaveGameObject("GameData");
        }
        
        gameData.daysPlayed ++;
        if (gameData.daysPlayed > 14) 
        {
            gameData.daysPlayed = 1;
            currentDebugDate = DateTime.Today;
        }

        currentDebugDate = currentDebugDate.AddDays(1);

        gameData.currentDebugTime = currentDebugDate;

        SaveGameMechanic.saveSaveGameObject(gameData, "GameData", 1);

        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadButtons();
    }

    internal DateTime getCurrentDebugDate()
    {
        Debug.Log(currentDebugDate.ToString());
        return currentDebugDate;
    }
}
