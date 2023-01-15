using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StablesLvl3 : MonoBehaviour
{
    public int Factor = 20;
    private string BuildingType = "StablesLvl3";
    private int Level = 3;
    private string ObjectFolder = "Stables";

    void Awake()
    {
        GetComponent<ActionStables>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
