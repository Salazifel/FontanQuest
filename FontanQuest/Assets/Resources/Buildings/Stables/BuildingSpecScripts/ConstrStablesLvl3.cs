using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrStablesLvl3 : MonoBehaviour
{
    private string BuildingType = "ConstrStablesLvl3";
    private int Level = 3;
    private string ObjectFolder = "Stables";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
