using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BuildCityWalls : MonoBehaviour
{
    GameObject mainCanvas;
    CastleMainUI castleMainUIScript;
    GameObject messageWindowObject;
    MessageWindow messageWindow;

    GameObject backgroundMusic;

    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }
    void OpenBuildWindow()
    {
        // Find the MessageWindow instance in the current scene
        mainCanvas = GameObject.Find("MainCanvas");
        castleMainUIScript = mainCanvas.GetComponent<CastleMainUI>();

        // Call the SetupMessageWindow function
        messageWindow.SetupMessageWindow(
            "Mauer",
            "Sollen wir eine Stadtmauer bauen?",
            "Abrechen",
            messageWindow.DeactivateMessageWindow,
            "Bauen",
            RightButtonClicked,
            null, // If you want a middle button, provide the text
            null,
            MessageWindow.Character_options.Character_Male_Rouge_01,
            AnimationLibrary.Animations.Talk,
            "audios/Emil_StadtMauerBauen_"
        );
    }

    private void RightButtonClicked()
    {
        // loading in the existing BuiltBuildings-Block
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");}
        builtBuildings.CityWalls = 1;
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().ActivateCityWalls();
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
        messageWindow.DeactivateMessageWindow();

        Message_EventSystem.SendMessage(new MessageObjectBlueprint.messageObject(
            "Glückwunsch!",
            "Vielen Dank, dass du die Mauer mit mir gebaut hast. Nun sind wir sicher in der Stadt",
            null,
            null,
            null,
            null,
            "Gerne",
            messageWindow.DeactivateMessageWindow,
            MessageWindow.Character_options.Character_Male_Rouge_01,
            AnimationLibrary.Animations.Talk,
            null
        ));
    }
}
