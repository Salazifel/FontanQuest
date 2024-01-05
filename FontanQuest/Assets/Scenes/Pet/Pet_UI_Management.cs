using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pet_UI_Management : MonoBehaviour
{
    private SaveGameObjects.PetSystem petSystem;
    GameObject messageWindowObject;
    GameObject nextPetButton;
    GameObject previousPetButton;
    GameObject PetSelectionDoneButton;
    MessageWindow messageWindow;
    private Pet_CameraIntro pet_CameraIntro;
    // Start is called before the first frame update
    void Start()
    {
        // Get MainCameraScript
        pet_CameraIntro = GameObject.Find("Main Camera").GetComponent<Pet_CameraIntro>();
        // Get PetSelectionButtons
        nextPetButton = GameObject.Find("NextPetButton");
        previousPetButton = GameObject.Find("PreviousPetButton");
        PetSelectionDoneButton = GameObject.Find("PetSelectionDoneButton");
        ToggleVisibiliyAnimalSelectionButtons(false);
        // Get MessageWindow
        messageWindowObject = GameObject.Find("MessageWindow");
        messageWindow = messageWindowObject.GetComponent<MessageWindow>();
        petSystem = (SaveGameObjects.PetSystem) SaveGameMechanic.getSaveGameObjectByPrimaryKey("PetSystem", 1);
        
        if (petSystem == null)
        {
            petSystem = (SaveGameObjects.PetSystem) SaveGameObjects.CreateSaveGameObject("PetSystem");
        }

        if (petSystem.animalSelected == true && petSystem.selectedAnimal == null)
        {
            // the app crashed or was closed while selecting the animal. Therefore, that process is resetted
            petSystem.animalSelected = false;
        }
        
        if (!petSystem.onBoardingDone)
        {
            messageWindow.SetupMessageWindow(
                "Willkommen!",
                "Hey du! Ich bin Otto. Es scheint als ob dir ein Tier zugelaufen ist? Du kannst es gerne bei meiner Farm unterstellen.",
                null,
                null,
                null,
                null,
                "Ok",
                StartMessageMiddleButtonClick,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            );
        } else 
        {
            pet_CameraIntro.ActivateCameraAnimation();
        }
    }

    void LateUpdate()
    {
        if (!petSystem.animalSelected && pet_CameraIntro.AnimationIsDone)
        {
            messageWindow.SetupMessageWindow(
                "Dein Tier",
                "Clicke nach links oder rechts, um dein Tier auszuwaehlen.",
                null,
                null,
                null,
                null,
                "Ok",
                SelectPetMiddleButtonClick,
                MessageWindow.Character_options.none,
                AnimationLibrary.Animations.Talk,
                null
            );
        }
    }

    private void SelectPetMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        petSystem.animalSelected = true;
        savePetSystem();
        ToggleVisibiliyAnimalSelectionButtons(true);
    }

    private void StartMessageMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        pet_CameraIntro.ActivateCameraAnimation();
        savePetSystem();
    }

    private void savePetSystem()
    {
        SaveGameMechanic.saveSaveGameObject(petSystem, "PetSystem", 1);
    }

    void ToggleVisibiliyAnimalSelectionButtons(Boolean setBoolean)
    {
        nextPetButton.SetActive(setBoolean);
        previousPetButton.SetActive(setBoolean);
        PetSelectionDoneButton.SetActive(setBoolean);
    }
}
