using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLvl1 : MonoBehaviour
{
    public int Factor = 1;
    private string BuildingType = "HouseLvl1";
    private int Level = 1;
    private string ObjectFolder = "House";

    void Awake()
    {
        GetComponent<ActionHouse>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
