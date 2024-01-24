using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleClickBuilding : MonoBehaviour
{
    MessageWindow messageWindow;

    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
    }
    public void OpenBuildWindow()
    {
        messageWindow.SetupMessageWindow("Koenig", "Bring mir noch mehr Freunde fuer das grosse Bankett!", null, null, null, null, "Klar!", messageWindow.DeactivateMessageWindow, MessageWindow.Character_options.Character_Male_King, AnimationLibrary.Animations.Talk, null);
    }
}
