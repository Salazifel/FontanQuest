using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSavingBuildings : MonoBehaviour
{
    private GameObject CityWalls;
    private GameObject Castle;
    private GameObject Temple;
    private GameObject YouTubeHouse;

    void Awake()
    {
        CityWalls = GameObject.Find("W A L L S");
        Castle = GameObject.Find("C A S T L E");
        Temple = GameObject.Find("monk_temple");
        YouTubeHouse = GameObject.Find("YouTubeHouse");        

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
        if (builtBuildings.YouTubeHouse == true) {YouTubeHouse.SetActive(true);}
    }

    public void ActivateCityWalls() 
    {
        CityWalls.SetActive(true);
    }

    public void ActivateFarm()
    {

    }

    public void ActiveTemple()
    {

    }

    public void ActivateClimber()
    {

    }

    public void ActivateWitch()
    {

    }

    public void ActivateWoodCutter()
    {

    }

    public void ActivateMining()
    {
        
    }

    public void ActivateYouTubeHouse()
    {
        YouTubeHouse.SetActive(true);
    }

    public void DeactivateAllBuildings()
    {
        CityWalls.SetActive(false);
        Castle.SetActive(false);
        Temple.SetActive(false);
        YouTubeHouse.SetActive(false);
    }
}
