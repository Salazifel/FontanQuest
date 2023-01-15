using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutterLvl3 : MonoBehaviour
{
    public int Factor = 3;
    private string BuildingType = "WoodCutterLvl3";
    private int Level = 3;
    private string ObjectFolder = "WoodCutter";

    void Awake()
    {
        GetComponent<ActionWoodCutter>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
