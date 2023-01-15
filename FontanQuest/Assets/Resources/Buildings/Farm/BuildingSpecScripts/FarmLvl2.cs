using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLvl2 : MonoBehaviour
{
    public int Factor = 2;
    private string BuildingType = "FarmLvl2";
    public int Level = 2;
    private string ObjectFolder = "Farm";

    void Awake()
    {
        GetComponent<ActionFarm>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
