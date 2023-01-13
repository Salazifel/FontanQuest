using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrFarmLvl3 : MonoBehaviour
{
    private string BuildingType = "ConstrFarmLvl3";
    private int Level = 3;
    private string ObjectFolder = "Farm";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
