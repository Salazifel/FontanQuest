using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrFarmLvl1 : MonoBehaviour
{
    private string BuildingType = "ConstrFarmLvl1";
    private int Level = 1;
    private string ObjectFolder = "Farm";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
