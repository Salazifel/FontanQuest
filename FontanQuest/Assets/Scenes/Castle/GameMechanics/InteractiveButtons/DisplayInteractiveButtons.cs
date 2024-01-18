using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInteractiveButtons : MonoBehaviour
{
    SaveGameObjects.BuiltBuildings builtBuildings;
    SaveGameObjects.GameData gameData;

    // All available Buttons
    GameObject buildCityWall;
    GameObject wanderingMonk;
    GameObject monkGameButton;

    void Start()
    {
        buildCityWall = GameObject.Find("BuildCityWall");
        wanderingMonk = GameObject.Find("WanderingMonk");
        monkGameButton = GameObject.Find("MonkGameButton");

        displayAvailableButtons();
    }

    public void DeactivateInteractiveButtons()
    {
        buildCityWall.SetActive(false);
        wanderingMonk.SetActive(false);
        monkGameButton.SetActive(false);
    }

    public void displayAvailableButtons() {
        DeactivateInteractiveButtons();

        builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        gameData = (SaveGameObjects.GameData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);

        Debug.Log(gameData.daysPlayed.ToString());

        switch (gameData.daysPlayed)
        {
            case 0:
                if (builtBuildings.CityWalls == false) {buildCityWall.SetActive(true);} else {}
                if (builtBuildings.Temple == false) 
                {
                    wanderingMonk.SetActive(true);
                    wanderingMonk.GetComponentInChildren<MonkWelcomeButton>().ActivateMonkGameButton();
                } else {
                    monkGameButton.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
}
