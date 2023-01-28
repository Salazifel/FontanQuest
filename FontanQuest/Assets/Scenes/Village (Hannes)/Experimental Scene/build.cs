using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class build : MonoBehaviour
{
    private GameObject BuildSubMenuBtns;
    private GameObject Building_Interaction_Menu;
    private GameObject ResourcesBuildingsBtns;
    private GameObject MainBuildingBtns;
    private GameObject PeopleBuildingsBtns;

    private bool isBuildSubMenuBtnsActive = false;

    private GameObject RotateBtn;
    private GameObject DoneBtn;
    private GameObject InfoBtn;
    private GameObject MoveBtn;
    private GameObject UpgradeBtn;
    private GameObject CancelBtn;



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
        Building_Interaction_Menu.SetActive(false);
        ResourcesBuildingsBtns.SetActive(false);
        MainBuildingBtns.SetActive(false);
        PeopleBuildingsBtns.SetActive(false);
    }

    void Start()
    {   
        BuildSubMenuBtns = GameObject.Find("BuildSubMenuBtns");
        Building_Interaction_Menu = GameObject.Find("Building_Interaction_Menu");
        ResourcesBuildingsBtns = GameObject.Find("ResourcesBuildingsBtns");
        MainBuildingBtns = GameObject.Find("MainBuildingBtns");
        PeopleBuildingsBtns = GameObject.Find("PeopleBuildingsBtns");

        RotateBtn = GameObject.Find("Rotate");
        DoneBtn = GameObject.Find("Done");
        InfoBtn = GameObject.Find("Info");
        MoveBtn = GameObject.Find("Move");
        UpgradeBtn = GameObject.Find("Upgrade");
        CancelBtn = GameObject.Find("Cancel");

        hide_all_Buttons();
    }
    public void show_Building_Interaction_Buttons__Is_building_built(bool is_built)
    {
        hide_BuildingsBtns();
        Building_Interaction_Menu.SetActive(true);
        if (is_built == true)
        {
            RotateBtn.SetActive(false);
            DoneBtn.SetActive(true);
            InfoBtn.SetActive(true);
            MoveBtn.SetActive(false);
            UpgradeBtn.SetActive(true);
            CancelBtn.SetActive(false);
        }
        else
        {
            RotateBtn.SetActive(true);
            DoneBtn.SetActive(true);
            InfoBtn.SetActive(false);
            MoveBtn.SetActive(true);
            UpgradeBtn.SetActive(false);
            CancelBtn.SetActive(true);
        }
    }

    public void hide_Building_Interaction_Buttons()
    {
        Building_Interaction_Menu.SetActive(false);
    }
}
