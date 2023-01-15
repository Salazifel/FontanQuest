using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrFarmLvl2 : MonoBehaviour
{
    private string BuildingType = "ConstrFarmLvl2";
    private int Level = 2;
    private string ObjectFolder = "Farm";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
