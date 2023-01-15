using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrWoodCutterLvl3 : MonoBehaviour
{
    private string BuildingType = "ConstrWoodCutterLvl3";
    private int Level = 3;
    private string ObjectFolder = "WoodCutter";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
