using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrTavernLvl1 : MonoBehaviour
{
    private string BuildingType = "ConstrTavernLvl1";
    private int Level = 1;
    private string ObjectFolder = "Tavern";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
