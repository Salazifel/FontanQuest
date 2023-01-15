using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrWoodCutterLvl2 : MonoBehaviour
{
    private string BuildingType = "ConstrWoodCutterLvl2";
    private int Level = 2;
    private string ObjectFolder = "WoodCutter";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
