using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrMainBuildingLvl1 : MonoBehaviour
{
    private string BuildingType = "ConstrMainBuildingLvl1";
    private int Level = 1;
    private string ObjectFolder = "MainBuilding";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
