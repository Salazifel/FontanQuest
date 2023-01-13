using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrWoodCutterLvl1 : MonoBehaviour
{
    private string BuildingType = "ConstrWoodCutterLvl1";
    private int Level = 1;
    private string ObjectFolder = "WoodCutter";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
