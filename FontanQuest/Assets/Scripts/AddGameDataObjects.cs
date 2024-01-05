using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AddGameDataObjects
{
    public static void changeNumOfHay(int change_value)
    {
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null) {
            gameData = (SaveGameObjects.GameData) SaveGameObjects.CreateSaveGameObject("GameData");
        }

        // if 0 dont decrease 2DO
        gameData.numOfHay = gameData.numOfHay + change_value;

        SaveGameMechanic.saveSaveGameObject(gameData, "GameData", 1);
    }

    // public static int getNumOfHay()
    // {
    //     //2do
    // }
}


