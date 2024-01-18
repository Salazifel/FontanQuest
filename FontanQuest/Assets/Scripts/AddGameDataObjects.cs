using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AddGameDataObjects
{
    public static void changeNumOfHay(int change_value)
    {
        SaveGameObjects.GameData gameData = getGameData();

        // if 0 dont decrease 2DO
        gameData.numOfHay = gameData.numOfHay + change_value;
        if (gameData.numOfHay < 0)
        {
            gameData.numOfHay = 0;
        }

        SaveGameMechanic.saveSaveGameObject(gameData, "GameData", 1);
    }

    public static bool checkPurchase(int change_value)
    {
        SaveGameObjects.GameData gameData = getGameData();
        if (gameData.numOfHay + change_value > 0) 
        {
            return true;
        }
        
        return false;
    }

    public static int getNumOfHay()
    {
        SaveGameObjects.GameData gameData = getGameData();
        return gameData.numOfHay;
    }

    private static SaveGameObjects.GameData getGameData()
    {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null) {
            gameData = (SaveGameObjects.GameData) SaveGameObjects.CreateSaveGameObject("GameData");
        }
        return gameData;
    }
}


