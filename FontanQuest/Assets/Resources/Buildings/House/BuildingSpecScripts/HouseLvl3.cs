using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLvl3 : MonoBehaviour
{
    public int Factor = 3;
    private string BuildingType = "HouseLvl3";
    private int Level = 3;
    private string ObjectFolder = "House";

    void Awake()
    {
        GetComponent<ActionHouse>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
