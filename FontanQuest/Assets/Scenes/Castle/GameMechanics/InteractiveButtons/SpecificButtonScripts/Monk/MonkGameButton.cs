using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonkGameButton : MonoBehaviour
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
        messageWindow.SetupMessageWindow("Kung Fu!", "Willkommen in meinem Dojo. Moechtest du das Kaempfen lernen?", "Noch nicht", leftButtonClick, "Klar!", rightButtonClick, null, null, MessageWindow.Character_options.Character_Male_Rouge_01, AnimationLibrary.Animations.Talk, null);
    }

    private void leftButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
    }

    private void rightButtonClick()
    {
        SceneManager.Load("AM-2D-Game");
    }
}
