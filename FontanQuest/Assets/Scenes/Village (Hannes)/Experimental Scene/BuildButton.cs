using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.UIElements;

public class BuildButton : MonoBehaviour
{
    private GameObject prefab;
    private Renderer rend; // renderer of the build building to change it to be a selected building
    private Material[] mats; // materials of the build building to change it to be a selected building
    public Material[] material; // the public materials to change the building colour
    private string ObjectFolder;
    private string ObjectType;
    private int ObjectLvl;
    private GameObject MasterData;

    private bool is_moving = false;

    private bool is_upgrading = false; // bool to check whether this is a new built or an upgrade
    private bool is_built = false;

    private bool is_build_mode = false; // a variable that blocks the player from building multiple buildings at once

    private int wood;
    private int stone;
    private int food;
    private int gold;

    private string[] prices;

    public void spawn_prefab()
    {
        free_building();

        is_build_mode = true;
        GetComponent<build>().show_Building_Interaction_Buttons__Is_building_built(false);
        is_moving = false;
        GameObject.Find("Move").GetComponent<UnityEngine.UI.Image>().color = Color.white;
        // get the price of the WoodCutterLvl1 from the MasterData
        prices = MasterData.GetComponent<Prices>().ReturnPrice(ObjectFolder, ObjectLvl);
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
        else
        {
            not_enough_ressources();
        }
    }

    public void assign_selected_building(GameObject building)
    {
        if (is_build_mode == true)
        {
            // if the player is in build mode, the player can't build another building
            return;
        }
        is_build_mode = true;
        Debug.Log(building.name);
        if (building.name.Contains("prefab") == true)
        {
            is_built = false;
            GetComponent<build>().show_Building_Interaction_Buttons__Is_building_built(is_built);
        }
        else
        {
            is_built = true;
            rend = building.GetComponent<Renderer>();
            mats = rend.materials;
            Material[] mats_tmp = rend.materials;
            for (int i = 0; i < rend.materials.Length; i++)
            {
                mats_tmp[i] = material[0];
            }
            rend.materials = mats_tmp;
            GetComponent<build>().show_Building_Interaction_Buttons__Is_building_built(is_built);
        }
        this.prefab = building;
    }

    public void rotate_prefab()
    {
        prefab.transform.Rotate(0, 90, 0);
    }

    public void move_prefab()
    {
        if (is_moving == false)
        {
            is_moving = true;
            
            GameObject.Find("Move").GetComponent<UnityEngine.UI.Image>().color = Color.black;
            
            // activates the "moving status" of the prefab
            GameObject.Find("Main Camera").GetComponent<AndroidInput>().change_moving_building_status(true, prefab);
        }
        else
        {
            // deactivates the "moving status" of the prefab
            is_moving = false;
            GameObject.Find("Move").GetComponent<UnityEngine.UI.Image>().color = Color.white;
            GameObject.Find("Main Camera").GetComponent<AndroidInput>().change_moving_building_status(false, prefab);
        }
    }

    public void BuildWoodcutter()
    {
        ObjectFolder = "WoodCutter";
        ObjectType = "WoodcutterPrefab";
        ObjectLvl = 1;
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
        if (is_built == false)
        {
            Debug.Log("Finalize_built");
            bool placable = false;
            GameObject.Find("Main Camera").GetComponent<AndroidInput>().change_moving_building_status(false, prefab); 
            Debug.Log("is_upgrading: " + is_upgrading);
            if (is_upgrading == false)
            {
                placable = prefab.GetComponent<BluePrint>().get_placable();
            }
            else
            {
                placable = true;
            }
            if (placable == true)
            {
                if (ResourceContainer.CheckRessources(wood, stone, food, gold))
                {
                    Debug.Log(ObjectFolder + " " + ObjectType);
                    GameObject ConstrPrefab = Resources.Load("Buildings/"+ ObjectFolder + "/" + "Constr" + ObjectFolder + "Lvl" + ObjectLvl) as GameObject;
                    GameObject newBuilding = Instantiate(ConstrPrefab, prefab.transform.position, prefab.transform.rotation);
                    Destroy(prefab);

                    // needed to save and load the game
                    name = "Constr" + ObjectFolder + "Lvl" + ObjectLvl;
                    newBuilding.GetComponent<buildingDataSys>().set_BuildingType(name);
                    newBuilding.GetComponent<buildingDataSys>().set_WearDown(0);

                    GetComponent<build>().hide_all_Buttons();
                    ResourceContainer.changeRes(-wood, -stone, -food, -gold);
                    is_build_mode = false;
                }
                else
                {
                    not_enough_ressources();
                    if (is_upgrading == true)
                    {
                        free_building();
                        GetComponent<build>().hide_Building_Interaction_Buttons();
                        is_build_mode = false;
                    }
                }
            }
            else
            {
                if (is_moving == true)
                {
                    is_moving = false;
                    move_prefab();
                }
            }
        }
        else
        {
            rend.materials = mats;
            is_build_mode = false;
            GetComponent<build>().hide_all_Buttons();
        }
    }

    public void Cancel_built()
    {
        GetComponent<build>().hide_Building_Interaction_Buttons();
        is_build_mode = false;
        GameObject.Find("Main Camera").GetComponent<AndroidInput>().change_moving_building_status(false, prefab);
        Destroy(prefab);
    }

    public void upgrade_building()
    {
        Debug.Log(prefab.name);
        string tmp = prefab.GetComponent<buildingDataSys>().get_ObjectFolder();
        ObjectFolder = tmp;
        ObjectType = tmp + "Prefab";

        string input = prefab.name;
        int level = 0;
        string number = new string(input.Where(c => char.IsDigit(c)).ToArray());
        if (!string.IsNullOrEmpty(number)) {
            level = int.Parse(number);
            Debug.Log(level);
        } else {
            Debug.Log("Input does not contain an integer");
            return;
        }
        ObjectLvl = level + 1;
        if (ObjectLvl > 3)
        {
            MasterData.GetComponent<MessageDisplay>().new_Message("Oh. Ihr habt grosse Ambitionen. Aber mehr als 3 Level für jedes Gebauede gibt es leider noch nicht. Ihr muesst euch hiermit begnuegen.", "Advisor");
            return;
        }
        Debug.Log(ObjectFolder + " " + ObjectType + " " + ObjectLvl);
        is_built = false;
        is_upgrading = true;

        prices = MasterData.GetComponent<Prices>().ReturnPrice(ObjectFolder, ObjectLvl);
        wood = int.Parse(prices[0]);
        stone = int.Parse(prices[1]);
        food = int.Parse(prices[2]);
        gold = int.Parse(prices[3]);

        Finalize_built();
    }

    public void show_building_info()
    {
        string tmp = prefab.GetComponent<buildingDataSys>().get_ObjectFolder();
        ObjectFolder = tmp;
        ObjectType = tmp + "Prefab";

        string input = prefab.name;
        int level = 0;
        string number = new string(input.Where(c => char.IsDigit(c)).ToArray());
        if (!string.IsNullOrEmpty(number)) {
            level = int.Parse(number);
            Debug.Log(level);
        } else {
            Debug.Log("Input does not contain an integer");
            return;
        }
        ObjectLvl = level + 1;
        Debug.Log(ObjectFolder + " " + ObjectType + " " + ObjectLvl);

        prices = MasterData.GetComponent<Prices>().ReturnPrice(ObjectFolder, ObjectLvl);
        wood = int.Parse(prices[0]);
        stone = int.Parse(prices[1]);
        food = int.Parse(prices[2]);
        gold = int.Parse(prices[3]);

        MasterData.GetComponent<MessageDisplay>().new_Message("Name: " + get_building_name_translation(ObjectFolder) +"\n"
                                                            + "Level: " + level + "\n"
                                                            + "Preise zur Levelerhoehung: \n"
                                                            + wood + " Holz, " + stone + " Stein, " + gold + " Gold.", "Advisor");
    }

    private string get_building_name_translation(string s)
    {
        if (s == "House")
        {return "Haus";}
        else if (s == "Farm")
        {return "Bauernhof";}
        else if (s == "MainBuilding")
        {return "Burg";}
        else if (s == "Stables")
        {return "Staelle";}
        else if (s == "WoodCutter")
        {return "Holzfaeller";}
        else if (s == "StoneMine")
        {return "Mine";}
        else if (s == "Tavern")
        {return "Taverne";}

        return "ERROR";
    }

    private void not_enough_ressources()
    {
        // hiding the buttons
        GetComponent<build>().hide_Building_Interaction_Buttons();
        Debug.Log("Price: " + wood + " " + stone + " " + food + " " + gold);
        MasterData.GetComponent<MessageDisplay>().new_Message("Oh nein. Es scheint so, als ob du nicht genug Ressourcen hast um dieses Gebaeude zu bauen.", "Advisor");
    }

    public void free_building()
    {
        is_built = false;
        is_upgrading = false;
        is_build_mode = false;

        GetComponent<build>().hide_Building_Interaction_Buttons();      

        try
        {
            rend.materials = mats;
        }
        catch (System.Exception)
        {
            Debug.Log("No materials to change");
        }

        GameObject.Find("Main Camera").GetComponent<AndroidInput>().change_moving_building_status(false, prefab);

        Debug.Log("free_building");
    }
}
