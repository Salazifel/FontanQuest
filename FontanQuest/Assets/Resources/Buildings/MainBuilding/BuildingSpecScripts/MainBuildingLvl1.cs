using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuildingLvl1 : MonoBehaviour
{
    public int Factor = 10;
    private string BuildingType = "MainBuildingLvl1";
    private int Level = 1;
    private string ObjectFolder = "MainBuilding";

    void Awake()
    {
        GetComponent<ActionMainBuilding>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
