using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutterLvl1 : MonoBehaviour
{
    public int Factor = 1;
    private string BuildingType = "WoodCutterLvl1";
    private int Level = 1;
    private string ObjectFolder = "WoodCutter";

    void Awake()
    {
        GetComponent<ActionWoodCutter>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
