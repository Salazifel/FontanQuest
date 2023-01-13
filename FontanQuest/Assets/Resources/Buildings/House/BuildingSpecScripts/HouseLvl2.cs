using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseLvl2 : MonoBehaviour
{
    public int Factor = 2;
    private string BuildingType = "HouseLvl2";
    public int Level = 2;
    private string ObjectFolder = "House";

    void Awake()
    {
        GetComponent<ActionHouse>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
