using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButtonsClick : MonoBehaviour
{
    public string buildingType;
    public void OpenBuildWindow()
    {
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().interactiveButtonClick(buildingType);
    }
}
