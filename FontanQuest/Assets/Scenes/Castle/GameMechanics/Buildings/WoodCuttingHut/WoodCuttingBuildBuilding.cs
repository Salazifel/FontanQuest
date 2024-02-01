using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCuttingBuildBuilding : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }

    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Holzfaeller", "Howdy Partner! Ich heiße Marina und habe gehört der Koenig braucht Feuerholz für die Küche. Da er ja so viel isst, dachte ich mir, koennte ich ja hier fuer in arbeiten?", null, null, null, null, "Klar!", RightButtonClicked, MessageWindow.Character_options.Character_Female_Peasant_01, AnimationLibrary.Animations.Talk, null);
    }

    private void RightButtonClicked()
    {
        // loading in the existing BuiltBuildings-Block
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings)SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        if (builtBuildings == null) { builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameObjects.CreateSaveGameObject("BuiltBuildings");}
        builtBuildings.WoodCutting = 1;
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().ActivateWoodCutter();
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
        messageWindow.DeactivateMessageWindow();

        Message_EventSystem.SendMessage(new MessageObjectBlueprint.messageObject(
            "Holzfaeller",
            "Danke, dass ich bleiben darf. Komm bald wieder damit wir Holz hacken koennen.",
            null,
            null,
            null,
            null,
            "Ok",
            messageWindow.DeactivateMessageWindow,
            MessageWindow.Character_options.Character_Female_Peasant_01,
            AnimationLibrary.Animations.Talk,
            null
        ));
    }
}
