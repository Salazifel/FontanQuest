using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle_OnBoarding : MonoBehaviour
{
    private GameObject onboardingGO;
    private CameraMovementAnimation cameraMovementAnimation;
    private SaveGameObjects.CastleOnBoardingSystem castleOnBoardingSystem;
    private GameObject RotateButton;

    void Start()
    {
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
        if (cameraMovementAnimation.step_to_target(CameraMovementAnimation.StepOptions.step_count, 10) == "Done")
        {
            // end OnBoarding
            GameObject.Find("StepButton").SetActive(false);
            RotateButton.SetActive(true);

            Message_EventSystem.SendMessage(new MessageObjectBlueprint.messageObject(
                "Willkommen!",
                "Du hast es geschafft! Nun bist du bei deiner Burg. Oh, der König scheint nach uns zu rufen.",
                null,
                null,
                null,
                null,
                "Ok",
                StartKingOnBoardingSimulation,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk
            ));
        }
    }

    private void StartKingOnBoardingSimulation() {
        CastleMainUI castleMainUI = GameObject.Find("MainCanvas").GetComponent<CastleMainUI>();
        castleMainUI.DeactivateMessageWindow();
    }
}
