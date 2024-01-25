using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningStartGame : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }
    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Der Berg!", "Oh hallo! Nein, ich habe den Drachen noch nicht gefunden aber jede Menge Steine. Meinst du, du koenntest sie zuerschlagen?", "Spaeter", messageWindow.DeactivateMessageWindow, "Klar!", rightButtonClick, null, null, MessageWindow.Character_options.Character_Female_Gypsy, AnimationLibrary.Animations.Talk, null);
    }

    public void rightButtonClick()
    {
        SceneManager.Load("StoneCrushing");
    }
}
