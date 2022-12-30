using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWoodCutter : MonoBehaviour
{
    public GameObject MasterData;

    void Awake()
    {
        MasterData = GameObject.Find("MasterData");
    }

    public void give_BuildingType()
    {
        // MasterData.GetComponent<SavingGameData>().receive_buildingType("WoodCutterLvl1");
    }
}
