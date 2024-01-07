using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pet_UI_Management_GameSet : MonoBehaviour
{   
    int numofHay;
    public SaveGameObjects.PetSystem petSystem;

    GameObject messageWindowObject;
    // GameObject nextPetButton;
    // GameObject previousPetButton;
    // GameObject PetSelectionDoneButton;
    // GameObject fuetternGameButton;
    // GameObject spielenGameButton;
    // GameObject rennenGameButton;
    GameObject backtoGameButton;
    // GameObject reselectButton;
    MessageWindow messageWindow;
    public Pet_CameraIntro pet_CameraIntro;
    private AnimalManager animalManager;
    // Start is called before the first frame update
    void Start()
    {   

        Debug.Log("Script is Active!");
        animalManager = GameObject.Find("Pet").GetComponent <AnimalManager>();
        // Get MainCameraScript
        pet_CameraIntro = GameObject.Find("Main Camera").GetComponent<Pet_CameraIntro>();
        // Get PetSelectionButtons
        // nextPetButton = GameObject.Find("NextPetButton");
        // previousPetButton = GameObject.Find("PreviousPetButton");
        // PetSelectionDoneButton = GameObject.Find("PetSelectionDoneButton");
        // fuetternGameButton = GameObject.Find("FuetternGameButton");
        // spielenGameButton = GameObject.Find("SpielenGameButton");
        // rennenGameButton= GameObject.Find("RennenGameButton");
        // reselectButton = GameObject.Find("ReselectButton");
        backtoGameButton = GameObject.Find("BackButton");
        Debug.Log(backtoGameButton);
        // ToggleVisibiliyAnimalSelectionButtons(false);
        // ToggleVisibiliyGameSelectionButtons(false);
        // Get MessageWindow
        messageWindowObject = GameObject.Find("MessageWindow");
        messageWindow = messageWindowObject.GetComponent<MessageWindow>();

        petSystem = (SaveGameObjects.PetSystem) SaveGameMechanic.getSaveGameObjectByPrimaryKey("PetSystem", 1);
        
        if (petSystem != null)
        {   
            animalManager.ActivateAnimal(petSystem.selectedAnimal);
        }
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
            animalManager.ActivateAnimal(petSystem.selectedAnimal);
            messageWindow.DeactivateMessageWindow();
            pet_CameraIntro.ActivateCameraAnimation(false);
            ToggleVisibiliyBacktoGame(true);
        }
    }
        void LateUpdate(){
            
            if (!petSystem.gameSelected && pet_CameraIntro.AnimationIsDone)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Pet", LoadSceneMode.Single);
            }

        }
    
    private void StartMessageMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        pet_CameraIntro.ActivateCameraAnimation(false);
        petSystem.Fuettern_onBoardingDone = true;
        savePetSystem();
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
    public void ToggleVisibiliyBacktoGame(Boolean setBoolean)
    {
        backtoGameButton.SetActive(setBoolean);

    }

    public void GameScene(){
        Debug.Log(petSystem.gameSelected);
        ToggleVisibiliyBacktoGame(false);
        pet_CameraIntro.ActivateCameraAnimation(true);
        petSystem.gameSelected = false;
    }


}
