using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrTavernLvl2 : MonoBehaviour
{
    private string BuildingType = "ConstrTavernLvl2";
    private int Level = 2;
    private string ObjectFolder = "Tavern";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
