using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrStablesLvl1 : MonoBehaviour
{
    private string BuildingType = "ConstrStablesLvl1";
    private int Level = 1;
    private string ObjectFolder = "Stables";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
