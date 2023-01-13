using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StablesLvl1 : MonoBehaviour
{
    public int Factor = 10;
    private string BuildingType = "StablesLvl1";
    private int Level = 1;
    private string ObjectFolder = "Stables";

    void Awake()
    {
        GetComponent<ActionStables>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
