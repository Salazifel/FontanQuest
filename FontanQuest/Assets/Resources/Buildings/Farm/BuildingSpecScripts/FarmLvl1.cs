using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLvl1 : MonoBehaviour
{
    public int Factor = 1;
    private string BuildingType = "FarmLvl1";
    private int Level = 1;
    private string ObjectFolder = "Farm";

    void Awake()
    {
        GetComponent<ActionFarm>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
