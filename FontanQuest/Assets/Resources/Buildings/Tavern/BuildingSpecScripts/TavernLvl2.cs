using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernLvl2 : MonoBehaviour
{
    public int Factor = 2;
    private string BuildingType = "TavernLvl2";
    private int Level = 2;
    private string ObjectFolder = "Tavern";

    void Awake()
    {
        GetComponent<ActionTavern>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
