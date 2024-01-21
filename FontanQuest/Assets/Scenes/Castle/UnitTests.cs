using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTests : MonoBehaviour
{
    void LateUpdate() {
        //StaticResources.addNumOfCoins(5);
    }

    public void resetSaveFile()
    {
        SaveGameMechanic.saveSaveGameObject(SaveGameObjects.CreateSaveGameObject("BuiltBuildings"), "BuiltBuildings", 1);
        SaveGameMechanic.saveSaveGameObject(SaveGameObjects.CreateSaveGameObject("CastleOnBoardingSystem"), "CastleOnBoardingSystem", 1);
    }

    public void AddDay()
    {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData) SaveGameObjects.CreateSaveGameObject("GameData");
        }
        gameData.daysPlayed ++;

        SaveGameMechanic.saveSaveGameObject(gameData, "GameData", 1);

        Debug.Log(gameData.daysPlayed.ToString());
    }
}
