using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCityWalls : MonoBehaviour
{
    void OpenBuildWindow()
    {
        // Find the MessageWindow instance in the current scene
        MessageWindow messageWindow = FindObjectOfType<MessageWindow>();

        if (messageWindow != null)
        {
            // Prepare the callback actions
            UnityEngine.Events.UnityAction leftAction = messageWindow.DeactivateMessageWindow;
            UnityEngine.Events.UnityAction rightAction = RightButtonClicked;

            // Call the SetupMessageWindow function
            messageWindow.SetupMessageWindow(
                "Mauer",
                "Sollen wir eine Stadtmauer bauen? Das kostet " + BuildingCosts.CityWallCost + " Gold.",
                "Abrechen",
                leftAction,
                "Bauen",
                rightAction,
                null, // If you want a middle button, provide the text
                null
            );
        }
        else
        {
            Debug.LogError("MessageWindow instance was not found in the scene.");
        }
    }

    private void RightButtonClicked()
    {
        StaticResources.reduceNumOfCoins(BuildingCosts.CityWallCost);
        // loading in the existing BuiltBuildings-Block
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.BuiltBuildings(false, false, false, false), "builtBuildings", 1);
        builtBuildings.CityWalls = true;
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "builtBuildings", 1);
    }
}
