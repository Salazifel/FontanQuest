using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCuttingStartGame : MonoBehaviour
{
    MessageWindow messageWindow; 
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }
    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Der Berg!", "Grüzi! Ich bin Heinrich und haenge ziemlich in den Seilen. Meinst du, du kannst für mich da hoch klettern?", "Spaeter", messageWindow.DeactivateMessageWindow, "Klar!", rightButtonClick, null, null, MessageWindow.Character_options.Character_Male_Sorcerer, AnimationLibrary.Animations.Talk, null);
    }

    public void rightButtonClick()
    {
        SceneManager.Load("WoodChopping");
    }
}
