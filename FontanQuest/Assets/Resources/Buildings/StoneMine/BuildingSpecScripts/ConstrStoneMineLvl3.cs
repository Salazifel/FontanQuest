using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrStoneMineLvl3 : MonoBehaviour
{
    private string BuildingType = "ConstrStoneMineLvl3";
    private int Level = 3;
    private string ObjectFolder = "StoneMine";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
