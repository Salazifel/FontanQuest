using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrMainBuildingLvl3 : MonoBehaviour
{
    private string BuildingType = "ConstrMainBuildingLvl3";
    private int Level = 3;
    private string ObjectFolder = "MainBuilding";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
