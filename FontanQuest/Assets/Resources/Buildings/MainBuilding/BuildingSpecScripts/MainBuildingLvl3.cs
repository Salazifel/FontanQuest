using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuildingLvl3 : MonoBehaviour
{
    public int Factor = 20;
    private string BuildingType = "MainBuildingLvl3";
    private int Level = 3;
    private string ObjectFolder = "MainBuilding";

    void Awake()
    {
        GetComponent<ActionMainBuilding>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
