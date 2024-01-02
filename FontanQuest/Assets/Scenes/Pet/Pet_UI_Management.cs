using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pet_UI_Management : MonoBehaviour
{
    public SaveGameObjects.PetSystem petSystem;
    GameObject messageWindowObject;
    GameObject nextPetButton;
    GameObject previousPetButton;
    GameObject PetSelectionDoneButton;
    GameObject fuetternGameButton;
    GameObject spielenGameButton;
    GameObject rennenGameButton;
    GameObject reselectButton;
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
        fuetternGameButton = GameObject.Find("FuetternGameButton");
        spielenGameButton = GameObject.Find("SpielenGameButton");
        rennenGameButton= GameObject.Find("RennenGameButton");
        reselectButton = GameObject.Find("ReselectButton");
        ToggleVisibiliyAnimalSelectionButtons(false);
        ToggleVisibiliyGameSelectionButtons(false);
        // Get MessageWindow
        messageWindowObject = GameObject.Find("MessageWindow");
        messageWindow = messageWindowObject.GetComponent<MessageWindow>();
        petSystem = (SaveGameObjects.PetSystem) SaveGameMechanic.getSaveGameObjectByPrimaryKey(new SaveGameObjects.PetSystem(false, false), "PetSystem", 1);
        
        if (petSystem == null)
        {
            petSystem = new SaveGameObjects.PetSystem(false, false);
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
                MessageWindow.Character_options.Character_Male_Peasant_01,
                AnimationLibrary.Animations.Talk
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
                AnimationLibrary.Animations.Talk
            );
        }
        if (petSystem.animalSelected && petSystem.selectedAnimal != null)
        {
            messageWindow.SetupMessageWindow(
                "Wahlen",
                "Clicke ein spiel, um sich um dein Tier zu kümmern.",
                null,
                null,
                null,
                null,
                "Ok",
                SelectGameMiddleButtonClick,
                MessageWindow.Character_options.none,
                AnimationLibrary.Animations.Talk
            );
        }

        else {
            //here it will be implemented the 
        }
    }
    private void StartMessageMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        pet_CameraIntro.ActivateCameraAnimation();
        savePetSystem();
    }
    private void SelectPetMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        petSystem.animalSelected = true;
        savePetSystem();
        ToggleVisibiliyAnimalSelectionButtons(true);
    }
    private void SelectGameMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        petSystem.onBoardingDone = true;
        savePetSystem();
        ToggleVisibiliyAnimalSelectionButtons(false);
        ToggleVisibiliyGameSelectionButtons(true);
    }


    public void savePetSystem()
    {
        SaveGameMechanic.getSaveGameObjectByPrimaryKey(petSystem, "PetSystem", 1);
    }

    void ToggleVisibiliyAnimalSelectionButtons(Boolean setBoolean)
    {
        nextPetButton.SetActive(setBoolean);
        previousPetButton.SetActive(setBoolean);
        PetSelectionDoneButton.SetActive(setBoolean);
    }
    void ToggleVisibiliyGameSelectionButtons(Boolean setBoolean)
    {
        fuetternGameButton.SetActive(setBoolean);
        spielenGameButton.SetActive(setBoolean);
        rennenGameButton.SetActive(setBoolean);
        reselectButton.SetActive(setBoolean);
    }


}
