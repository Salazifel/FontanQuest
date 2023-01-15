using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrStoneMineLvl1 : MonoBehaviour
{
    private string BuildingType = "ConstrStoneMineLvl1";
    private int Level = 1;
    private string ObjectFolder = "StoneMine";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
