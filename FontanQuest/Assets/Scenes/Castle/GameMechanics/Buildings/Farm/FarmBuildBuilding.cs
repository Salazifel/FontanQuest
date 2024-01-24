using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBuildBuilding : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }

    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Bauernhof", "Hey! Ich heiße Otto. Ich habe gehört der König will ein Fest feiern? Ich könnte mich um Essen kümmern, wenn ich eine Farm bauen darf?", "Bald", messageWindow.DeactivateMessageWindow, "Klar!", RightButtonClicked, null, null, MessageWindow.Character_options.Character_Male_Rouge_01, AnimationLibrary.Animations.Talk, null);
    }

    private void RightButtonClicked()
    {
        // loading in the existing BuiltBuildings-Block
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");}
        builtBuildings.Farm = true;
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().ActivateFarm();
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
        messageWindow.DeactivateMessageWindow();

        Message_EventSystem.SendMessage(new MessageObjectBlueprint.messageObject(
            "Glückwunsch!",
            "Oh du hast eine tolle Fram gebaut, du solltest wieder vorbei kommen, dann kannst du dir ein Haustier aussuchen, ok?",
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

        // deactivate the built button and reloud the available buttons
        GameObject.Find("GameData").GetComponent<DisplayInteractiveButtons>().displayAvailableButtons();
    }
}
