using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmStartGame : MonoBehaviour
{
    MessageWindow messageWindow;

    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }
    void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Bauernhof", "Willkommen auf dem Hof! Willst du zu deinem Haustier?", "Gerade nicht", messageWindow.DeactivateMessageWindow, "Klar!", rightButtonClick, null, null, MessageWindow.Character_options.Character_Male_Rouge_01, AnimationLibrary.Animations.Talk, null);
    }

    void rightButtonClick()
    {
        SceneManager.Load("Pet");
    }
}
