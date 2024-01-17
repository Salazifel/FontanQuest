using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pet_UI_Management : MonoBehaviour
{   
    public DateTime timeNow;
    public SaveGameObjects.PetSystem petSystem;
    GameObject messageWindowObject;
    GameObject nextPetButton;
    GameObject previousPetButton;
    GameObject PetSelectionDoneButton;
    GameObject fuetternGameButton;
    GameObject spielenGameButton;
    GameObject rennenGameButton;
    GameObject reselectButton;
    GameObject approveButton;
    MessageWindow messageWindow;
    public Pet_CameraIntro pet_CameraIntro;
    private AnimalManager animalManager;

    public int fuettern;
    public int kuemmern;
    public int rennen;

    public GameObject pet;
    void Start()
    {   
        
        timeNow = DateTime.Now;
        Debug.Log(timeNow);
        fuettern = 0;
        kuemmern = 0;
        rennen = 0;
        animalManager = GameObject.Find("Pet").GetComponent <AnimalManager>();
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
        approveButton = GameObject.Find("ApproveButton");
        ToggleApproveButton(false);
        ToggleVisibiliyAnimalSelectionButtons(false);
        ToggleVisibiliyGameSelectionButtons(false);
        // Get MessageWindow
        messageWindowObject = GameObject.Find("MessageWindow");
        messageWindow = messageWindowObject.GetComponent<MessageWindow>();

        petSystem = (SaveGameObjects.PetSystem) SaveGameMechanic.getSaveGameObjectByPrimaryKey("PetSystem", 1);
        pet = GameObject.Find("Pet");
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
        {   Debug.Log(petSystem.lastLog_Fuettern);
            petSystem.gameSelected = false;
            messageWindow.DeactivateMessageWindow();
            pet_CameraIntro.ActivateCameraAnimation(false);
            CheckPassingTime();
            

        }
    }
        void LateUpdate()
    {   
        if (petSystem != null)


        {
            if (!petSystem.onBoardingDone && pet_CameraIntro.AnimationIsDone)
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
                    MessageWindow.Character_options.Character_Male_Rouge_01,
                    AnimationLibrary.Animations.Talk,
                    null
                );
            }
            if (petSystem.animalSelected && petSystem.selectedAnimal != null && !petSystem.selectionComplete)
            {
                messageWindow.SetupMessageWindow(
                    "Wahlen",
                    "Clicke ein spiel, um sich um dein Tier zu kuemmern.",
                    null,
                    null,
                    null,
                    null,
                    "Ok",
                    SelectGameMiddleButtonClick,
                    MessageWindow.Character_options.Character_Male_Rouge_01,
                    AnimationLibrary.Animations.Talk,
                    null
                );
            }

            else {
                if (pet_CameraIntro.AnimationIsDone && petSystem.animalSelected && !petSystem.gameSelected)
                {
                RefreshScale();
                ToggleVisibiliyGameSelectionButtons(true);
                timeNow = DateTime.Now;
                }
                if (pet_CameraIntro.AnimationIsDone && !petSystem.animalSelected && petSystem.onBoardingDone){
                ToggleVisibiliyAnimalSelectionButtons(true);
                }
                if (petSystem.gameSelected && pet_CameraIntro.AnimationIsDone){
                    if (fuettern == 1){
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Fuettern", LoadSceneMode.Single);
                    }
                    if (kuemmern == 1){
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Kuemmern", LoadSceneMode.Single);
                    }
                    if (rennen == 1){
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Rennen", LoadSceneMode.Single);
                    }
                }
            }
        }
    }
    private void StartMessageMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        pet_CameraIntro.ActivateCameraAnimation(false);
    }
    private void SelectPetMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        petSystem.onBoardingDone = true;
        savePetSystem();
        Debug.Log("Saved");
        Debug.Log("AnimalSelectButtons activated!");
        loadPetSystem();
        Debug.Log("Loaded");
    }
    private void SelectGameMiddleButtonClick()
    {   
        messageWindow.DeactivateMessageWindow();
        petSystem.selectionComplete = true;
        savePetSystem();
        Debug.Log("Saved");
        Debug.Log("GameSelectButtons activated!");
        loadPetSystem();
        Debug.Log("Loaded");
    }


    public void savePetSystem()
    {
        SaveGameMechanic.saveSaveGameObject(petSystem, "PetSystem", 1);
    }

    public void loadPetSystem()
    {
        SaveGameMechanic.getSaveGameObjectByPrimaryKey("PetSystem",1);

    }

    public void ToggleVisibiliyAnimalSelectionButtons(Boolean setBoolean)
    {
        nextPetButton.SetActive(setBoolean);
        previousPetButton.SetActive(setBoolean);
        PetSelectionDoneButton.SetActive(setBoolean);
    }
    public void ToggleVisibiliyGameSelectionButtons(Boolean setBoolean)
    {
        fuetternGameButton.SetActive(setBoolean);
        spielenGameButton.SetActive(setBoolean);
        rennenGameButton.SetActive(setBoolean);
        reselectButton.SetActive(setBoolean);
    }

public void CheckPassingTime()
{
    // Calculate elapsed time for each activity
    TimeSpan elapsedtime_Fuettern = timeNow - petSystem.lastLog_Fuettern;
    TimeSpan elapsedtime_Putzen = timeNow - petSystem.lastLog_Putzen;
    TimeSpan elapsedtime_Spielen = timeNow - petSystem.lastLog_Spielen;

    Debug.Log(petSystem.lastLog_Fuettern);
    Debug.Log(elapsedtime_Fuettern);

    // Calculate hunger decrease for each activity
    int x_hunger_Fuettern = (elapsedtime_Fuettern.Hours *60 + elapsedtime_Fuettern.Minutes) / 120;
    int x_hunger_Putzen = (elapsedtime_Putzen.Hours *60 + elapsedtime_Putzen.Minutes) / 120;
    int x_hunger_Spielen = (elapsedtime_Spielen.Hours *60 + elapsedtime_Spielen.Minutes) / 120;
    Debug.Log(x_hunger_Fuettern);
    // Update hunger based on elapsed time for each activity
    petSystem.Pet_Hunger -= x_hunger_Fuettern * 5;
    if (petSystem.Pet_Hunger < 0){
        petSystem.Pet_Hunger = 0;
    }
    Debug.Log(petSystem.Pet_Hunger);
    // Similarly, update hunger for other activities if needed
    savePetSystem();
}

public void ToggleApproveButton(Boolean setBoolean){
    approveButton.SetActive(setBoolean);
}

public void RefreshScale(){
    pet.transform.localScale = new Vector3(petSystem.petScaleX, petSystem.petScaleY, petSystem.petScaleZ);
}

}
