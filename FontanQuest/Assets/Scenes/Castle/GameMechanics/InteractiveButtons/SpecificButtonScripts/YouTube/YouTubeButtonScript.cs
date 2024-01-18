using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouTubeButtonScript : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }
    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("YouTube", "Hey! Willkommen in unserem kleinen Kino. Möchtest du mit uns Sport treiben?", "Gerad nicht", messageWindow.DeactivateMessageWindow, "Klar!", rightButtonClick, null, null, MessageWindow.Character_options.Character_Female_Witch, AnimationLibrary.Animations.Talk, null);
    }

    private void rightButtonClick()
    {
        SceneManager.Load("");
    }
}
