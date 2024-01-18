using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSavingBuildings : MonoBehaviour
{
    private GameObject CityWalls;
    private GameObject Castle;
    private GameObject Temple;

    void Awake()
    {
        CityWalls = GameObject.Find("W A L L S");
        Castle = GameObject.Find("C A S T L E");
        Temple = GameObject.Find("monk_temple");
        

        displayBuiltBuildings();
    }

    public void displayBuiltBuildings()
    {
        DeactivateAllBuildings();
        LoadBuildings();
    }

    public void LoadBuildings()
    {
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings"); }
        builtBuildings.Print();
        // now checking each building
        if (builtBuildings.CityWalls == true) { ActivateCityWalls(); }
        if (builtBuildings.Castle == true) { }
        if (builtBuildings.Temple == true) { Temple.SetActive(true);}
    }

    public void ActivateCityWalls() 
    {
        CityWalls.SetActive(true);
    }

    public void DeactivateAllBuildings()
    {
        CityWalls.SetActive(false);
        Castle.SetActive(false);
        Temple.SetActive(false);
    }
}
