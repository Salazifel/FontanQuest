using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingDataSys : MonoBehaviour
{
    public string BuildingType;
    public int wearDown;

    public void set_BuildingType(string bType)
    {
        BuildingType = bType;
    }

    public void set_WearDown(int wD)
    {
        wearDown = wD;
    }

    public string get_BuildingType()
    {
        return BuildingType;
    }

    public int get_WearDown()
    {
        return wearDown;
    }
}
