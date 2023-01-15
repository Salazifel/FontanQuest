using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrHouseLvl1 : MonoBehaviour
{
    private string BuildingType = "ConstrHouseLvl1";
    private int Level = 1;
    private string ObjectFolder = "House";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
