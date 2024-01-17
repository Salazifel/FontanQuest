using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInteractiveButtons : MonoBehaviour
{
    SaveGameObjects.BuiltBuildings builtBuildings;
    SaveGameObjects.GameData gameData;

    // All available Buttons
    GameObject buildCityWall;

    void Start()
    {
        displayAvailableButtons();

        buildCityWall = GameObject.Find("BuildCityWall");
    }

    public void DeactivateInteractiveButtons()
    {
        buildCityWall.SetActive(false);
    }

    public void displayAvailableButtons() {
        builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey("builtBuildings", 1);
        gameData = (SaveGameObjects.GameData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);

        switch (gameData.daysPlayed)
        {
            case 1:
                if (builtBuildings.CityWalls == false) {buildCityWall.SetActive(true);} else {}
                break;
            default:
                break;
        }
    }
}
