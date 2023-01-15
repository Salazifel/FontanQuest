using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrHouseLvl2 : MonoBehaviour
{
    private string BuildingType = "ConstrHouseLvl2";
    private int Level = 2;
    private string ObjectFolder = "House";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
