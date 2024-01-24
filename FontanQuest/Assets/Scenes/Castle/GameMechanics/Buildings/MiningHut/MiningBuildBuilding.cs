using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningBuildBuilding : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }

    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Mine", "Hallo! Ich bin Bergfrau. Ich habe gehört in den tiefen des Berges gitb es einen Drachen? Kann ich danach suchen? All das Gold und Silber, dass ich finde kannst du behalten, ich will den Drachen!", null, null, null, null, "Ok", RightButtonClicked, MessageWindow.Character_options.Character_Female_Gypsy, AnimationLibrary.Animations.Talk, null);
    }

    private void RightButtonClicked()
    {
        // loading in the existing BuiltBuildings-Block
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");}
        builtBuildings.Mining = true;
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().ActivateMining();
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
        messageWindow.DeactivateMessageWindow();

        Message_EventSystem.SendMessage(new MessageObjectBlueprint.messageObject(
            "Mine",
            "Klasse, danke! Ich mache mich gleich ran nach dem Drachen zu suchen. Komm doch wieder vorbei, um mir in der Mine zu helfen!",
            null,
            null,
            null,
            null,
            "Ok",
            messageWindow.DeactivateMessageWindow,
            MessageWindow.Character_options.Character_Female_Gypsy,
            AnimationLibrary.Animations.Talk,
            null
        ));

        // deactivate the built button and reloud the available buttons
        GameObject.Find("GameData").GetComponent<DisplayInteractiveButtons>().displayAvailableButtons();
    }
}
