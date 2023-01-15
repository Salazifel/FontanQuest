using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTavern : MonoBehaviour
{
    private int factor;
    private string BuildingType;
    private string ObjectFolder;
    private int Level;

    private GameObject MasterData;

    public void set_Level(int Factor, string BuildingType, int Level, string ObjectFolder)
    {
        // from the house Lvl X script
        this.factor = Factor;
        this.BuildingType = BuildingType;
        this.Level = Level;
        this.ObjectFolder = ObjectFolder;
    }

    void Start()
    {
        MasterData = GameObject.Find("MasterData");

        // needed for the game to save and load:
        GetComponent<buildingDataSys>().set_ObjectFolder(ObjectFolder);
        GetComponent<buildingDataSys>().set_BuildingType(BuildingType);
    }
}
