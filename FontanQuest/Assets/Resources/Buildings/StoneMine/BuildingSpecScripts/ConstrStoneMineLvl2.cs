using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrStoneMineLvl2 : MonoBehaviour
{
    private string BuildingType = "ConstrStoneMineLvl2";
    private int Level = 2;
    private string ObjectFolder = "StoneMine";

    void Awake()
    {
        GetComponent<TaskBuild>().set_Level(BuildingType, Level, ObjectFolder);
    }
}
