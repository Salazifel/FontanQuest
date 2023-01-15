using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    private GameObject prefab;
    private string ObjectFolder;
    private string ObjectType;
    private int ObjectLvl;
    private GameObject MasterData;

    private int wood;
    private int stone;
    private int food;
    private int gold;

    public void spawn_prefab()
    {
        // get the price of the WoodCutterLvl1 from the MasterData
        string[] prices = MasterData.GetComponent<Prices>().ReturnPrice(ObjectFolder, ObjectLvl);
        wood = int.Parse(prices[0]);
        stone = int.Parse(prices[1]);
        food = int.Parse(prices[2]);
        gold = int.Parse(prices[3]);
        // get the prefab of the building from Ressources.Load given the root folder "Buildings", the ObjectFolder and ObjectType
        prefab = Resources.Load("Buildings/" + ObjectFolder + "/" + ObjectType) as GameObject;
        // call the function CheckRessources from the ResourceContainer static script, and if it returns True, spawn the barracks blueprint
        if (ResourceContainer.CheckRessources(wood, stone, food, gold))
        {
            // spawn the prefab
            Debug.Log("Prefab: " + prefab);
            prefab = Instantiate(prefab);
            prefab.GetComponent<BluePrint>().set_Level(ObjectLvl, ObjectType, ObjectFolder);
        }
    }

    public void BuildWoodcutter()
    {
        ObjectFolder = "WoodCutter";
        ObjectType = "WoodcutterPrefab";
        ObjectLvl = 1;
        Debug.Log("Woodcutter");
        spawn_prefab();
    }

    public void BuildHouse()
    {
        ObjectFolder = "House";
        ObjectType = "HousePrefab";
        ObjectLvl = 1;
        spawn_prefab();
    }

    public void BuildTavern()
    {
        ObjectFolder = "Tavern";
        ObjectType = "TavernPrefab";
        ObjectLvl = 1;
        spawn_prefab();
    }

    public void BuildFarm()
    {
        ObjectFolder = "Farm";
        ObjectType = "FarmPrefab";
        ObjectLvl = 1;
        spawn_prefab();
    }

    public void BuildStoneMine()
    {
        ObjectFolder = "StoneMine";
        ObjectType = "StoneMinePrefab";
        ObjectLvl = 1;
        spawn_prefab();
    }

    public void BuidMainBuilding()
    {
        ObjectFolder = "MainBuilding";
        ObjectType = "MainBuildingPrefab";
        ObjectLvl = 1;
        spawn_prefab();
    }

    public void BuildStables()
    {
        ObjectFolder = "Stables";
        ObjectType = "StablesPrefab";
        ObjectLvl = 1;
        spawn_prefab();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(prefab);
        }
    }

    void Awake()
    {
        MasterData = GameObject.Find("MasterData");
    }

    public void Finalize_built()
    {
        // call the changeRes function from the ResourceContainer static script, and pass the price of the building as parameters
        ResourceContainer.changeRes(-wood, -stone, -food, -gold);
    }
}
