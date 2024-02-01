using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSavingBuildings : MonoBehaviour
{
    private Dictionary<string, GameObject> buildingPointers;
    private Dictionary<string, GameObject> buttonPointers;

    public enum additionalBuildingStrings {
        CityWalls,
        Castle
    }

    void Awake()
    {
        ActivityManagerPerDay.InitializeDailyActivities();
        getStartGameButtonGameObjectReferences();
        getGameObjectReferences(); 

        LoadBuildingsAndButtons();
    }

    public void getStartGameButtonGameObjectReferences()
    {
        buttonPointers = new Dictionary<string, GameObject>();

        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString(), GameObject.Find("monk_temple"));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), GameObject.Find("YouTubeHouse"));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString(), GameObject.Find("FarmHouse"));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.MountainClimberExergame.ToString(), GameObject.Find("ClimbersHutBuilding"));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString(), GameObject.Find("WoodCutterBuilding"));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString(), GameObject.Find("MiningBuilding"));
        buttonPointers.Add(additionalBuildingStrings.CityWalls.ToString(), GameObject.Find("W A L L S"));
        buttonPointers.Add(additionalBuildingStrings.Castle.ToString(), GameObject.Find("C A S T L E"));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString(), GameObject.Find("WitchHutBuilding"));

        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString(), GameObject.Find(""));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString(), GameObject.Find(""));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString(), GameObject.Find(""));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString(), GameObject.Find(""));
        buttonPointers.Add(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString(), GameObject.Find(""));
    }

    public void getGameObjectReferences()
    {
        buildingPointers = new Dictionary<string, GameObject>();

        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString(), GameObject.Find("monk_temple"));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), GameObject.Find("YouTubeHouse"));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString(), GameObject.Find("FarmHouse"));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.MountainClimberExergame.ToString(), GameObject.Find("ClimbersHutBuilding"));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString(), GameObject.Find("WoodCutterBuilding"));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString(), GameObject.Find("MiningBuilding"));
        buildingPointers.Add(additionalBuildingStrings.CityWalls.ToString(), GameObject.Find("W A L L S"));
        buildingPointers.Add(additionalBuildingStrings.Castle.ToString(), GameObject.Find("C A S T L E"));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString(), GameObject.Find("WitchHutBuilding"));

        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString(), GameObject.Find(""));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString(), GameObject.Find(""));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString(), GameObject.Find(""));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString(), GameObject.Find(""));
        buildingPointers.Add(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString(), GameObject.Find(""));
    }

    public void LoadButtons()
    {
        DeactivateAllButtons();

        // LOADING IN THE DATA

        List<SaveGameObjects.MainSaveObject> mainSaveObjects = SaveGameMechanic.getAllSaveGameObjectsOfType("DayActivity", "DayActivity");
        List<SaveGameObjects.DayActivity> dayActivities = new List<SaveGameObjects.DayActivity>();
        foreach (SaveGameObjects.MainSaveObject mainSaveObject in mainSaveObjects)
        {
            dayActivities.Add((SaveGameObjects.DayActivity)mainSaveObject);
        }

        mainSaveObjects = SaveGameMechanic.getAllSaveGameObjectsOfType("DayActivity", "DayActivity");
        List<SaveGameObjects.DayActivity> RewardActivity = new List<SaveGameObjects.DayActivity>();
        foreach (SaveGameObjects.MainSaveObject mainSaveObject in mainSaveObjects)
        {
            dayActivities.Add((SaveGameObjects.DayActivity)mainSaveObject);
        }

        // DISPLAYING THE BUTTONS
        foreach(SaveGameObjects.DayActivity dayActivity in dayActivities)
        {
            foreach(Tuple<string, int, bool> exercise in dayActivity.exercises)
            {
                if (buttonPointers.TryGetValue(exercise.Item1, out GameObject var)) 
                {
                    
                }
            }
        }
    }

    public void DeactivateAllButtons()
    {

    }

    public void LoadBuildings()
    {
        DeactivateAllBuildings();

        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings"); }
        
        // now checking each building
        if (builtBuildings.CityWalls > 0 && buildingPointers.TryGetValue(additionalBuildingStrings.CityWalls.ToString(), out GameObject cityWallsObject)) 
        {
            cityWallsObject.SetActive(true);
        }
        if (builtBuildings.Castle > 0 && buildingPointers.TryGetValue(additionalBuildingStrings.Castle.ToString(), out GameObject castleObject)) 
        {
            castleObject.SetActive(true);
        }
        if (builtBuildings.Temple > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.AsianMonkExergame.ToString(), out GameObject templeObject)) 
        {
            templeObject.SetActive(true);
        }
        if (builtBuildings.Farm > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.PetRewardGame.ToString(), out GameObject farmObject)) 
        {
            farmObject.SetActive(true);
        }
        if (builtBuildings.YouTubeHouse > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.YouTubeScene.ToString(), out GameObject youtubeHouseObject)) 
        {
            youtubeHouseObject.SetActive(true);
        }
        if (builtBuildings.Witch > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.ObstacleRunning.ToString(), out GameObject witchObject)) 
        {
            witchObject.SetActive(true);
        }
        if (builtBuildings.WoodCutting > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.WoodCuttingExergame.ToString(), out GameObject woodCuttingObject)) 
        {
            woodCuttingObject.SetActive(true);
        }
        if (builtBuildings.Climber > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.MountainClimberExergame.ToString(), out GameObject climberObject)) 
        {
            climberObject.SetActive(true);
        }
        if (builtBuildings.Mining > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.StoneCuttingExergame.ToString(), out GameObject miningObject)) 
        {
            miningObject.SetActive(true);
        }
        if (builtBuildings.DoodleJumpHouse > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.DoodleJumpRewardGame.ToString(), out GameObject doodleJumpHouseObject)) 
        {
            doodleJumpHouseObject.SetActive(true);
        }
        if (builtBuildings.FitnessBoxingHouse > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.FitnessBoxing.ToString(), out GameObject fitnessBoxingHouseObject)) 
        {
            fitnessBoxingHouseObject.SetActive(true);
        }
        if (builtBuildings.WeedThePlantHouse > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.WeedThePlant.ToString(), out GameObject weedThePlantHouseObject)) 
        {
            weedThePlantHouseObject.SetActive(true);
        }
        if (builtBuildings.HikingHouse > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.HikingExergame.ToString(), out GameObject hikingHouseObject)) 
        {
            hikingHouseObject.SetActive(true);
        }
        if (builtBuildings.Market > 0 && buildingPointers.TryGetValue(SceneManagerStaticScript.AvailableScenes.ParentsMarketKidsPerspective.ToString(), out GameObject marketObject)) 
        {
            marketObject.SetActive(true);
        }
    }

    public void DeactivateAllBuildings()
    {

    }
}
