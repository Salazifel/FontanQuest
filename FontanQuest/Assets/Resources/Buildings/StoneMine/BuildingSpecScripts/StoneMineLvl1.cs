using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMineLvl1 : MonoBehaviour
{
    public int Factor = 1;
    private string BuildingType = "StoneMineLvl1";
    private int Level = 1;
    private string ObjectFolder = "StoneMine";

    void Awake()
    {
        GetComponent<ActionStoneMine>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
