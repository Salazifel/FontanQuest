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
    GameObject YouTubeBuildBuilding;
    GameObject YouTubeStartGame;

    void Awake()
    {
        buildCityWall = GameObject.Find("BuildCityWall");
        wanderingMonk = GameObject.Find("WanderingMonk");
        monkGameButton = GameObject.Find("MonkGameButton");
        YouTubeBuildBuilding = GameObject.Find("YouTubeBuildBuilding");
        YouTubeStartGame = GameObject.Find("YouTubeStartGame");   
    }

    void Start()
    {
        displayAvailableButtons();
    }
    public void DeactivateInteractiveButtons()
    {
        buildCityWall.SetActive(false);
        wanderingMonk.SetActive(false);
        monkGameButton.SetActive(false);
        YouTubeBuildBuilding.SetActive(false);
        YouTubeStartGame.SetActive(false);
    }

    public void displayAvailableButtons(int preSetDay = -1) {

        builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null)
        {
            builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");
        }

        gameData = (SaveGameObjects.GameData) SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            gameData = (SaveGameObjects.GameData) SaveGameObjects.CreateSaveGameObject("GameData");
        }
        
        if (preSetDay == -1)
        {
            DeactivateInteractiveButtons();
            preSetDay = gameData.daysPlayed;
        }

        switch (preSetDay)
        {
            case 0:
                // City Wall
                if (builtBuildings.CityWalls == false) {buildCityWall.SetActive(true);} else {}
                // Monk
                if (builtBuildings.Temple == false) 
                {
                    wanderingMonk.SetActive(true);
                    wanderingMonk.GetComponentInChildren<MonkWelcomeButton>().ActivateMonkGameButton();
                } else {
                    monkGameButton.SetActive(true);
                }
                break;
            case 1:
                displayPreviousCases(1);
                // YouTubeHouse
                if (builtBuildings.YouTubeHouse == false) {YouTubeBuildBuilding.SetActive(true);} else {YouTubeStartGame.SetActive(true);}
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            default:
                break;
        }
    }

    private void displayPreviousCases(int prevCases)
    {
        for (int i = 0; i < prevCases; i++)
        {
            displayAvailableButtons(i);
        }
    }
}
