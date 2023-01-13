using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernLvl1 : MonoBehaviour
{
    public int Factor = 1;
    private string BuildingType = "TavernLvl1";
    private int Level = 1;
    private string ObjectFolder = "Tavern";

    void Awake()
    {
        GetComponent<ActionTavern>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
