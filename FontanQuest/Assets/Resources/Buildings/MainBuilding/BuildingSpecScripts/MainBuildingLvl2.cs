using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBuildingLvl2 : MonoBehaviour
{
    public int Factor = 15;
    private string BuildingType = "MainBuildingLvl2";
    private int Level = 2;
    private string ObjectFolder = "MainBuilding";

    void Awake()
    {
        GetComponent<ActionMainBuilding>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
