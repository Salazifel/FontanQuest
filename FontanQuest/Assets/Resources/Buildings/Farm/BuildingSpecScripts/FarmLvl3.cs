using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLvl3 : MonoBehaviour
{
    public int Factor = 3;
    private string BuildingType = "FarmLvl3";
    private int Level = 3;
    private string ObjectFolder = "Farm";

    void Awake()
    {
        GetComponent<ActionFarm>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
