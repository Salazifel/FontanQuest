using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pet_UI_Management_GameSet : MonoBehaviour
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
    public Pet_CameraIntro pet_CameraIntro;
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
        // ToggleVisibiliyAnimalSelectionButtons(false);
        // ToggleVisibiliyGameSelectionButtons(false);
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
        
        if (!petSystem.Fuettern_onBoardingDone)
        {
            messageWindow.SetupMessageWindow(
                "Fuettern",
                "You can feed your pet here, just click on the feed button or drag the hay to the feeder!",
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
            messageWindow.DeactivateMessageWindow();
            pet_CameraIntro.ActivateCameraAnimation(false);
        }
    }
        void LateUpdate(){
        }
    
    private void StartMessageMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        pet_CameraIntro.ActivateCameraAnimation(false);
        petSystem.Fuettern_onBoardingDone = true;
    }
    public void savePetSystem()
    {
        SaveGameMechanic.saveSaveGameObject(petSystem, "PetSystem", 1);
    }

    public void loadPetSystem()
    {
        SaveGameMechanic.getSaveGameObjectByPrimaryKey("PetSystem",1);

    }

    // public void ToggleVisibiliyAnimalSelectionButtons(Boolean setBoolean)
    // {
    //     nextPetButton.SetActive(setBoolean);
    //     previousPetButton.SetActive(setBoolean);
    //     PetSelectionDoneButton.SetActive(setBoolean);
    // }
    // public void ToggleVisibiliyGameSelectionButtons(Boolean setBoolean)
    // {
    //     fuetternGameButton.SetActive(setBoolean);
    //     spielenGameButton.SetActive(setBoolean);
    //     rennenGameButton.SetActive(setBoolean);
    //     reselectButton.SetActive(setBoolean);
    // }


}
