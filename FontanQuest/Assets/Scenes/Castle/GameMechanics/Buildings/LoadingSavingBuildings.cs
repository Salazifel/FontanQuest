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

        LoadBuildings();
    }

    public void LoadBuildings()
    {
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.BuiltBuildings(false, false, false, false), "builtBuildings", 1);
        if (builtBuildings == null) { builtBuildings = new SaveGameObjects.BuiltBuildings(false, false, false, false); }
        
        // now checking each building
        if (builtBuildings.CityWalls == true) { ActivateCityWalls(); }
        if (builtBuildings.Castle == true) { }
    }

    public void ActivateCityWalls() 
    {
        CityWalls.SetActive(true);
    }

    public void DeactivateAllBuildings()
    {
        CityWalls.SetActive(false);
        Castle.SetActive(false);
    }
}
