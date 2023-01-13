using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrMainBuildingLvl2 : MonoBehaviour
{
    private string BuildingType = "ConstrMainBuildingLvl2";
    private int Level = 2;
    private string ObjectFolder = "MainBuilding";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
