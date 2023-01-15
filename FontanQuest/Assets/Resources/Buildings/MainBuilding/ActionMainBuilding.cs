using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMainBuilding : MonoBehaviour
{
    public GameObject MasterData;

    private int maxWood;
    private int maxStone;
    private int maxFood;

    private int factor;
    private string BuildingType;
    private string ObjectFolder;
    private int Level;

    // Start is called before the first frame update
    void Start()
    {
        maxWood = 10 * factor;
        maxStone = 10 * factor;
        maxFood = 10 * factor;

        ResourceContainer.setMaxRes();
        ResourceContainer.setMaxRes(maxWood, maxStone, maxFood);

        MasterData = GameObject.Find("MasterData");

        // needed for the game to save and load:
        GetComponent<buildingDataSys>().set_ObjectFolder(ObjectFolder);
        GetComponent<buildingDataSys>().set_BuildingType(BuildingType);
    }

    public void set_Level(int Factor, string BuildingType, int Level, string ObjectFolder)
    {
        // from the house Lvl X script
        this.factor = Factor;
        this.BuildingType = BuildingType;
        this.Level = Level;
        this.ObjectFolder = ObjectFolder;
    }
}
