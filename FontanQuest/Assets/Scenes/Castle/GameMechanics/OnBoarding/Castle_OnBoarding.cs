using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle_OnBoarding : MonoBehaviour
{
    private GameObject onboardingGO;
    private CameraMovementAnimation cameraMovementAnimation;
    private SaveGameObjects.CastleOnBoardingSystem castleOnBoardingSystem;
    private GameObject RotateButton;

    private MessageWindow messageWindow;

    private int stepCounter = 0;

    void Start()
    {
        messageWindow = GameObject.Find("MessageWindow").GetComponent<MessageWindow>();

        onboardingGO = GameObject.Find("On_Boarding_Simulation");
        cameraMovementAnimation = onboardingGO.GetComponent<CameraMovementAnimation>();

        castleOnBoardingSystem = (SaveGameObjects.CastleOnBoardingSystem) SaveGameMechanic.getSaveGameObjectByPrimaryKey("CastleOnBoardingSystem", 1);
        if (castleOnBoardingSystem == null)
        {
            castleOnBoardingSystem = (SaveGameObjects.CastleOnBoardingSystem) SaveGameObjects.CreateSaveGameObject("CastleOnBoardingSystem");
        }

        if (castleOnBoardingSystem.onBoardingDone == false)
        {
            cameraMovementAnimation.initializeAnimation();
            RotateButton = GameObject.Find("RotateButton");
            RotateButton.SetActive(false);
        }
    }

    public void StepForwardInAnimation()
    {
        stepCounter ++;

        if (stepCounter == 1) {
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

        if (stepCounter == 3) {
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

        if (stepCounter == 5) {
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

        if (stepCounter == 8) {
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



        if (cameraMovementAnimation.step_to_target(CameraMovementAnimation.StepOptions.step_count, 10) == "Done")
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
        }
    }

    private void StartKingOnBoardingSimulation() {
        CastleMainUI castleMainUI = GameObject.Find("MainCanvas").GetComponent<CastleMainUI>();
        castleMainUI.DeactivateMessageWindow();
    }
}
