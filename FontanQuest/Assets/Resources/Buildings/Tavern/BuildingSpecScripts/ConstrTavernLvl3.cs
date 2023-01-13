using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrTavernLvl3 : MonoBehaviour
{
    private string BuildingType = "ConstrTavernLvl3";
    private int Level = 3;
    private string ObjectFolder = "Tavern";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
