using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveGameObjects.GameData gameData1 = new SaveGameObjects.GameData();
        gameData1.coins = 3;

        SaveGameObjects.GameData gameData2 = new SaveGameObjects.GameData();
        gameData2.coins = 4;

        SaveGameObjects.House house1 = new SaveGameObjects.House();
        house1.weardown = 0.5f;

        SaveGameMechanic.saveSaveGameObject(gameData1, "gamedata");
        //SaveGameMechanic.saveSaveGameObject(gameData2, "gamedata");
        //SaveGameMechanic.saveSaveGameObject(house1, "gamedata");

        SaveGameMechanic.deleteSaveGameObject(new SaveGameObjects.GameData(), "gameData", 1);

        //SaveGameMechanic.getSaveGameObject(1).Print();

        //Debug.Log(SaveGameMechanic.getSaveFileString());
    }
}
