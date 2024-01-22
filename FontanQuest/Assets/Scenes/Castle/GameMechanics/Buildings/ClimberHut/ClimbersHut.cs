using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbersHut : MonoBehaviour
{
    MessageWindow messageWindow;
    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }
    public void builtClimbersHut()
    {
        //messageWindow.SetupMessageWindow("Der Berg!", "Grüzi! Ich bin Heinrich")
    }

    public void StartClimbersGame()
    {

    }
}
