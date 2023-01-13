using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StablesLvl2 : MonoBehaviour
{
    public int Factor = 15;
    private string BuildingType = "StablesLvl2";
    private int Level = 2;
    private string ObjectFolder = "Stables";

    void Awake()
    {
        GetComponent<ActionStables>().set_Level(Factor, BuildingType, Level, ObjectFolder);
    }
}
