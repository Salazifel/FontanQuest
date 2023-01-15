using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrStablesLvl2 : MonoBehaviour
{
    private string BuildingType = "ConstrStablesLvl2";
    private int Level = 2;
    private string ObjectFolder = "Stables";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
