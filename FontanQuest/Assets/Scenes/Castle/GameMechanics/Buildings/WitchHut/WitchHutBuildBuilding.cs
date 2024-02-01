using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHutBuildBuilding : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }

    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Im Walde", "Willkommen, willkommen! Ich heiße Esmeralda und würde gerne am Fest des Koenigs teilnehmen, um ihm ein ganz besonderes Getraenk zu geben! Dagegen kannst du doch nichts haben, oder?", null, null, null, null, "...?", RightButtonClicked, MessageWindow.Character_options.Character_Female_Druid, AnimationLibrary.Animations.Talk, null);
    }
    private void RightButtonClicked()
    {
        // loading in the existing BuiltBuildings-Block
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");}
        builtBuildings.Witch = 1;
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().ActivateWitch();
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
        messageWindow.DeactivateMessageWindow();

        Message_EventSystem.SendMessage(new MessageObjectBlueprint.messageObject(
            "Im Walde",
            "Klasse, dass ich bleiben kann. Dann komm doch bald wieder. Mein Hauskaninchen braucht immer ein wenig auslauf!",
            null,
            null,
            null,
            null,
            "Ok",
            messageWindow.DeactivateMessageWindow,
            MessageWindow.Character_options.Character_Female_Druid,
            AnimationLibrary.Animations.Talk,
            null
        ));
    }
}
