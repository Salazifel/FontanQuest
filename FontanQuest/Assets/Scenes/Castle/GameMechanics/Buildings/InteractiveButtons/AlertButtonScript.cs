using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertButtonScript : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }

    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Verflucht!", "Oh nein! Der böse Magier hat unsere Burg verflucht, kannst du dich zu einer Wanderung aufmachen, um ein Heilmittel zu besorgen?", "Spaeter", messageWindow.DeactivateMessageWindow, "Klar!", RightButtonClick, null, null, MessageWindow.Character_options.Character_Male_Peasant_01, AnimationLibrary.Animations.Talk, null);
    }

    void RightButtonClick()
    {
        SceneManager.Load("HikkingStoryManager");
    }
}
