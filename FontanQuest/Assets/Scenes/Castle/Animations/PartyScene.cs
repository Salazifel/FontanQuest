using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PartyScene : MonoBehaviour
{
    MessageWindow messageWindow;
    CameraMovementAnimation cameraMovementAnimation1;
    CameraMovementAnimation cameraMovementAnimation2;

    private Boolean messageDisplayed = false;
    // Start is called before the first frame update

    void Awake()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();
        cameraMovementAnimation1 = GameObject.Find("IntermediatePosition").GetComponent<CameraMovementAnimation>();
        cameraMovementAnimation2 = GameObject.Find("FinalPosition").GetComponent<CameraMovementAnimation>();
    }

    void Start()
    {
        cameraMovementAnimation1.initializeAnimation();
        messageWindow.DeactivateMessageWindow();
    }
    public void displayMessage()
    {
        if (messageDisplayed == false)
        {
            messageWindow.SetupMessageWindow("Glückwunsch!", "Oh wow! Wir haben es geschafft, was für eine Feier! Toll!", null, null, null, null, "Ja!", messageWindow.DeactivateMessageWindow, MessageWindow.Character_options.Character_Male_King, AnimationLibrary.Animations.Talk, null);
            messageDisplayed = true;
        }
    }

    void Update()
    {
        if (cameraMovementAnimation1.AnimationIsDone == false)
        {
            cameraMovementAnimation1.step_to_target(CameraMovementAnimation.StepOptions.time_count);
        } else 
        {
            if (cameraMovementAnimation2.AnimationIsDone == false)
            {
                cameraMovementAnimation2.step_to_target(CameraMovementAnimation.StepOptions.time_count);
            }
            else 
            {
                displayMessage();
            }
        }
    }
}
