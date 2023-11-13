using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSavingBuildings : MonoBehaviour
{
    private GameObject CityWalls;
    private GameObject Castle;

    void Awake()
    {
        CityWalls = GameObject.Find("W A L L S");
        Castle = GameObject.Find("C A S T L E");

        DeactivateAllBuildings();
    }

    void ActivateCityWalls() 
    {
        CityWalls.SetActive(true);
    }

    void DeactivateAllBuildings()
    {
        CityWalls.SetActive(false);
        Castle.SetActive(false);
    }
}
