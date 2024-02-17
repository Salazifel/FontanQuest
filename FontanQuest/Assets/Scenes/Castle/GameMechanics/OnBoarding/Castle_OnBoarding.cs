using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Castle_OnBoarding : MonoBehaviour
{
    private GameObject onboardingGO;
    private CameraMovementAnimation cameraMovementAnimation;
    private SaveGameObjects.CastleOnBoardingSystem castleOnBoardingSystem;
    private GameObject RotateButton;
    private GameObject StepButton;
    private MessageWindow messageWindow;

    private int stepCounter = 0;

    private Boolean checkSteps = false;

    TextMeshProUGUI StepDisplay;

    void Start()
    {
        StepDisplay = GameObject.Find("STEPS").GetComponent<TextMeshProUGUI>();
        initialSteps = SmartWatchData.steps;

        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();

        onboardingGO = GameObject.Find("On_Boarding_Simulation");
        cameraMovementAnimation = onboardingGO.GetComponent<CameraMovementAnimation>();

        castleOnBoardingSystem = (SaveGameObjects.CastleOnBoardingSystem) SaveGameMechanic.getSaveGameObjectByPrimaryKey("CastleOnBoardingSystem", 1);
        if (castleOnBoardingSystem == null)
        {
            castleOnBoardingSystem = (SaveGameObjects.CastleOnBoardingSystem) SaveGameObjects.CreateSaveGameObject("CastleOnBoardingSystem");
        }

        StepButton = GameObject.Find("StepButton");

        if (castleOnBoardingSystem.onBoardingDone == false)
        {
            cameraMovementAnimation.initializeAnimation();
            RotateButton = GameObject.Find("RotateButton");
            RotateButton.SetActive(false);
            StepButton.SetActive(true);
            checkSteps = true;
        } else 
        {
            StepButton.SetActive(false);
        }

        if (castleOnBoardingSystem.onBoardingVideoWatched == false)
        {
            SceneManager.Load("CastleOnBoarding");
        }
    }

    private double initialSteps;
    private double previousStepCount = 0;
    private double doneSteps = 0;
    public void Update()
    {
        if (initialSteps == 0)
        {
            initialSteps = SmartWatchData.steps;
            return;
        }

        double tmp = SmartWatchData.steps - initialSteps;


        double tmp1 = tmp;

        for (int i = 0; i < tmp - doneSteps;)
        {
            StepForwardInAnimation();
            doneSteps++;
        }

        previousStepCount = tmp;

        StepDisplay.text = tmp.ToString();
    }

    public void StepForwardInAnimation()
    {
        stepCounter ++;

        if (stepCounter == 10) {
                messageWindow.SetupMessageWindowByMessageObject(new MessageObjectBlueprint.messageObject(
                "Willkommen!",
                "Los lass uns zur Burg gehen. Mache ein paar Schritte",
                null,
                null,
                null,
                null,
                "Ok",
                StartKingOnBoardingSimulation,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            ));
        }

        if (stepCounter == 30) {
                messageWindow.SetupMessageWindowByMessageObject(new MessageObjectBlueprint.messageObject(
                "Willkommen!",
                "Ja, weiter so!",
                null,
                null,
                null,
                null,
                "Ok",
                StartKingOnBoardingSimulation,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            ));
        }

        if (stepCounter == 50) {
                messageWindow.SetupMessageWindowByMessageObject(new MessageObjectBlueprint.messageObject(
                "Willkommen!",
                "Uff, das ist anstrenged. Die Haelfte haben wir",
                null,
                null,
                null,
                null,
                "Ok",
                StartKingOnBoardingSimulation,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            ));
        }

        if (stepCounter == 80) {
                messageWindow.SetupMessageWindowByMessageObject(new MessageObjectBlueprint.messageObject(
                "Willkommen!",
                "Wir haben es fast geschafft!",
                null,
                null,
                null,
                null,
                "Ok",
                StartKingOnBoardingSimulation,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            ));
        }



        if (cameraMovementAnimation.step_to_target(CameraMovementAnimation.StepOptions.step_count, 100) == "Done")
        {
            // end OnBoarding
            GameObject.Find("StepButton").SetActive(false);
            RotateButton.SetActive(true);

            messageWindow.SetupMessageWindowByMessageObject(new MessageObjectBlueprint.messageObject(
                "Willkommen!",
                "Du hast es geschafft! Nun bist du bei deiner Burg. Oh, der Koenig scheint nach uns zu rufen.",
                null,
                null,
                null,
                null,
                "Ok",
                StartKingOnBoardingSimulation,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            ));

            castleOnBoardingSystem.onBoardingDone = true;
            SaveGameMechanic.saveSaveGameObject(castleOnBoardingSystem, "CastleOnBoardingSystem", 1);
        }
    }

    private void StartKingOnBoardingSimulation() {
        messageWindow.DeactivateMessageWindow();
    }

    public void SkipWalking()
    {
        for (int i = 0; i < 100; i ++)
        {
            StepForwardInAnimation();
        }
    }
}
