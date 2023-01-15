using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrHouseLvl3 : MonoBehaviour
{
    private string BuildingType = "ConstrHouseLvl3";
    private int Level = 3;
    private string ObjectFolder = "House";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
