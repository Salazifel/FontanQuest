using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTests : MonoBehaviour
{
    public DateTime currentDebugDate;
    void Awake() {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        currentDebugDate = gameData.currentDebugTime;
    }

    public void resetSaveFile()
    {
        SaveGameMechanic.saveSaveGameObject(SaveGameObjects.CreateSaveGameObject("BuiltBuildings"), "BuiltBuildings", 1);
        SaveGameMechanic.saveSaveGameObject(SaveGameObjects.CreateSaveGameObject("CastleOnBoardingSystem"), "CastleOnBoardingSystem", 1);
        
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        gameData.currentDebugTime = DateTime.Today;
        currentDebugDate = DateTime.Today;

        SaveGameMechanic.saveSaveGameObject(gameData, "GameData", 1);
        SceneManager.Load("CastleOnboarding");

        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadButtons();
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().LoadBuildings();
    }

    public void AddDay()
    {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData) SaveGameObjects.CreateSaveGameObject("GameData");
        }
        gameData.daysPlayed ++;

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
