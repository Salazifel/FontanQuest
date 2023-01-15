using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMineLvl3 : MonoBehaviour
{
    public int Factor = 3;
    private string BuildingType = "StoneMineLvl3";
    private int Level = 3;
    private string ObjectFolder = "StoneMine";

    void Awake()
    {
        GetComponent<ActionStoneMine>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
