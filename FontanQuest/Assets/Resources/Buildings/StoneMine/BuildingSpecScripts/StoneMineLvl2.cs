using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMineLvl2 : MonoBehaviour
{
    public int Factor = 2;
    private string BuildingType = "StoneMineLvl2";
    private int Level = 2;
    private string ObjectFolder = "StoneMine";

    void Awake()
    {
        GetComponent<ActionStoneMine>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
