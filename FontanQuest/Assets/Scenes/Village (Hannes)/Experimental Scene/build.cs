using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class build : MonoBehaviour
{
    private GameObject BuildSubMenuBtns;
    private GameObject ResourcesBuildingsBtns;
    private GameObject MainBuildingBtns;
    private GameObject PeopleBuildingsBtns;

    private bool isBuildSubMenuBtnsActive = false;

    public void show_BuildSubMenuBtns()
    {
        // find GameObject by name "BuidSubMenuBtns" and set it to active
        if (isBuildSubMenuBtnsActive == false)
        {
            BuildSubMenuBtns.SetActive(true);
            isBuildSubMenuBtnsActive = true;
        }
        else
        {
            hide_all_Buttons();
            isBuildSubMenuBtnsActive = false;
        }
    }

    public void hide_BuildingsBtns()
    {
        ResourcesBuildingsBtns.SetActive(false);
        MainBuildingBtns.SetActive(false);
        PeopleBuildingsBtns.SetActive(false);
    }

    public void show_ResourcesBuildingsBtns()
    {
        hide_BuildingsBtns();
        // call the DisplayBuildPrices(string category) function from the BuildPrices script
        // and pass the category "Resources" as a parameter
        ResourcesBuildingsBtns.SetActive(true);
        GetComponent<DisplayBuildingPrices>().DisplayBuildPrices("ResourcesBuildingsBtns");
    }

    public void show_MainBuildingsBtns()
    {
        hide_BuildingsBtns();
        MainBuildingBtns.SetActive(true);
        GetComponent<DisplayBuildingPrices>().DisplayBuildPrices("MainBuildingBtns");
    }

    public void show_PeopleBuildingsBtns()
    {
        hide_BuildingsBtns();
        PeopleBuildingsBtns.SetActive(true);
        GetComponent<DisplayBuildingPrices>().DisplayBuildPrices("PeopleBuildingsBtns");
    }

    public void hide_all_Buttons()
    {
        BuildSubMenuBtns.SetActive(false);
        ResourcesBuildingsBtns.SetActive(false);
        MainBuildingBtns.SetActive(false);
        PeopleBuildingsBtns.SetActive(false);
    }

    void Start()
    {   
        BuildSubMenuBtns = GameObject.Find("BuildSubMenuBtns");
        ResourcesBuildingsBtns = GameObject.Find("ResourcesBuildingsBtns");
        MainBuildingBtns = GameObject.Find("MainBuildingBtns");
        PeopleBuildingsBtns = GameObject.Find("PeopleBuildingsBtns");

        hide_all_Buttons();
    }
}
