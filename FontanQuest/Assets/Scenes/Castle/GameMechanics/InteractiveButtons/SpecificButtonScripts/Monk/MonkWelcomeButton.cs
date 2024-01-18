using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonkWelcomeButton : MonoBehaviour
{
    MessageWindow messageWindow;
    NavMeshAgent monkNavMeshAgent;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
        monkNavMeshAgent = GameObject.Find("MonkCharacter").GetComponent<NavMeshAgent>();
    }

    public void ActivateMonkGameButton() 
    {
        monkNavMeshAgent.destination.Set(29.7f, -38.8f, 269.8f);
    }
    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Kung Fu!", "Oh ein Schmetterling! Schau mal! ... Hm, wo ich wohl heute schlafen soll. Kann ich in die Burg kommen? Ich bin Meister So Chill.", null, null, "Klar!", rightButtonClick, null, null, MessageWindow.Character_options.Character_Male_Rouge_01, AnimationLibrary.Animations.Talk, null);
    }

    private void leftButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
    }

    private void rightButtonClick()
    {
        SaveGameObjects.BuiltBuildings builtBuildings = (SaveGameObjects.BuiltBuildings) SaveGameMechanic.getSaveGameObjectByPrimaryKey("BuiltBuildings", 1);
        builtBuildings.Temple = true;
        SaveGameMechanic.saveSaveGameObject(builtBuildings, "BuiltBuildings", 1);
        GameObject.Find("GameData").GetComponent<DisplayInteractiveButtons>().displayAvailableButtons();
        GameObject.Find("GameData").GetComponent<LoadingSavingBuildings>().displayBuiltBuildings();
        messageWindow.DeactivateMessageWindow();
    }
}
