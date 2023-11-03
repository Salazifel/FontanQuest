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

        //SaveGameMechanic.saveSaveGameObject(gameData1, "gamedata");
        //SaveGameMechanic.saveSaveGameObject(gameData2, "gamedata");
        //SaveGameMechanic.saveSaveGameObject(house1, "gamedata");

        //SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.GameData(), "gamedata", 1).Print();

        //SaveGameMechanic.deleteBySaveFileName("gamedata");

        //SaveGameMechanic.deleteGameSaveType(new SaveGameObjects.GameData(), "gamedata");

        //SaveGameMechanic.deleteSaveGameObject(new SaveGameObjects.GameData(), "gameData", 1);

        /*
        List<SaveGameObjects.MainSaveObject> tmpGameSaveObjectsList = SaveGameMechanic.getAllSaveGameObjectsOfType(new SaveGameObjects.GameData(), "gamedata");

        for (int i = 0; i < tmpGameSaveObjectsList.Count; i++) 
        {
            tmpGameSaveObjectsList[i].Print();
        }
        */

        //SaveGameMechanic.getSaveGameObject(1).Print();

        //Debug.Log(SaveGameMechanic.getSaveFileString());
    }
}
