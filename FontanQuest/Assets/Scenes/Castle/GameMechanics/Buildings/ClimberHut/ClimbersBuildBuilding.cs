using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbersBuildBuilding : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }

    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Klettern", "Grüzi! Ich bin Heinrich. Ich wollte den Berg hier rauf aber brauche erstmal eine Pause. Kann ich hier übernachten?", null, null, null, null, "Klar!", RightButtonClicked, MessageWindow.Character_options.Character_Male_Sorcerer, AnimationLibrary.Animations.Talk, null);
    }

    private void RightButtonClicked()
    {
        // loading in the existing BuiltBuildings-Block
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");}
        builtBuildings.Climber = 1;
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().ActivateClimber();
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
        messageWindow.DeactivateMessageWindow();

        Message_EventSystem.SendMessage(new MessageObjectBlueprint.messageObject(
            "Klettern!",
            "Ach ist das ein schönes Zelt, ein toller Schlafsack, so eine Entspannung. Komm doch wieder, dann können wir zusammen weiterklettern",
            null,
            null,
            null,
            null,
            "Ok",
            messageWindow.DeactivateMessageWindow,
            MessageWindow.Character_options.Character_Male_Sorcerer,
            AnimationLibrary.Animations.Talk,
            null
        ));

        // deactivate the built button and reloud the available buttons
        //GameObject.Find("GameData").GetComponent<DisplayInteractiveButtons>().displayAvailableButtons();
    }
}