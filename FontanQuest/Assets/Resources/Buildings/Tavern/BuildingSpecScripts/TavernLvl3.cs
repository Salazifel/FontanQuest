using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernLvl3 : MonoBehaviour
{
    public int Factor = 3;
    private string BuildingType = "TavernLvl3";
    private int Level = 3;
    private string ObjectFolder = "TavernLvl3";

    void Awake()
    {
        GetComponent<ActionTavern>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
