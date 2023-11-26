using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AvatarsystemManager : MonoBehaviour
{
    private SaveGameObjects.AvatarSystem avatarSystem;
    GameObject messageWindowObject;
    MessageWindow messageWindow;

    // UI Elements
    GameObject NextCharacterButton;
    GameObject PreviousCharacterButton;
    void Start()
    {
        messageWindowObject = GameObject.Find("MessageWindow");
        messageWindow = messageWindowObject.GetComponent<MessageWindow>();
        messageWindow.DeactivateMessageWindow();

        NextCharacterButton = GameObject.Find("NextCharacterButton");
        PreviousCharacterButton = GameObject.Find("PreviousCharacterButton");
        NextCharacterButton.SetActive(false);
        PreviousCharacterButton.SetActive(false);

        avatarSystem = (SaveGameObjects.AvatarSystem)SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.AvatarSystem(false), "Avatarsystem", 1);
        if (avatarSystem == null)
        {
            avatarSystem = new SaveGameObjects.AvatarSystem(false);
        }

        if (avatarSystem.onBoardingDone == false)
        {
            AvatarOnBoarding();
        }
        LoadAvatarSytem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadAvatarSytem()
    {

    }

    void AvatarOnBoarding()
    {
        messageWindow.SetupMessageWindow("Willkommen",
            "Oh, wer bist du denn? Passe hier dein Aussehen an.",
            null,
            null,
            null,
            null,
            "Okay!",
            AvatarOnboardingReadyClick,
            MessageWindow.Character_options.none,
            AnimationLibrary.Animations.Talk);
    }

    void AvatarOnboardingReadyClick()
    {
        messageWindow.DeactivateMessageWindow();
        NextCharacterButton.SetActive(true);
        PreviousCharacterButton.SetActive(true);

    }
}
