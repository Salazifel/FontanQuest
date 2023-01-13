using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutterLvl2 : MonoBehaviour
{
    public int Factor = 2;
    private string BuildingType = "WoodCutterLvl2";
    private int Level = 2;
    private string ObjectFolder = "WoodCutter";

    void Awake()
    {
        GetComponent<ActionWoodCutter>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
