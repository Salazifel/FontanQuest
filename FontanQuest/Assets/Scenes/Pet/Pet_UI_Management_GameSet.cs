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

    public Pet_UI_Management_GameSet gameSet;
    GameObject messageWindowObject;
    // GameObject nextPetButton;
    GameObject cleanItem1;
    GameObject cleanItem2;
    GameObject playItem1;
    GameObject playItem2;
    
    GameObject backtoGameButton;
    GameObject washPetButton;
    GameObject playPetButton;
    MessageWindow messageWindow;
    public Pet_CameraIntro pet_CameraIntro;
    private AnimalManager animalManager;
    // Start is called before the first frame update
    void Start()
    {   
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (currentSceneName == "Kuemmern"){
        gameSet = GameObject.Find("Script Controller").GetComponent <Pet_UI_Management_GameSet>();
        petSystem = gameSet.petSystem;
        cleanItem1 = GameObject.Find("bucket-milk");
        cleanItem2 = GameObject.Find("shrub-flowers");
        playItem1 = GameObject.Find("cat-ball");
        playItem2 = GameObject.Find("soccer-ball");
        washPetButton = GameObject.Find("WashPetButton");
        playPetButton = GameObject.Find("PlayPetButton");
        ToggleVisibiliyCleanItem(false);
        ToggleVisibiliyPlayItem(false);
        }
        else if (currentSceneName == "Fuettern" ){
        gameSet = GameObject.Find("Script Controller").GetComponent <Pet_UI_Management_GameSet>();
        petSystem = gameSet.petSystem;
        }
        else
        {
            // Default case or handle other scenes
            Debug.Log("You are in a different scene");
            // Execute default actions or handle other scenes
        }
        animalManager = GameObject.Find("Pet").GetComponent <AnimalManager>();
        // Get MainCameraScript
        pet_CameraIntro = GameObject.Find("Main Camera").GetComponent<Pet_CameraIntro>();
        // Get PetSelectionButtons
        // nextPetButton = GameObject.Find("NextPetButton");
        // previousPetButton = GameObject.Find("PreviousPetButton");
        
        backtoGameButton = GameObject.Find("BackButton");


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
        
        if (!petSystem.Fuettern_onBoardingDone && currentSceneName == "Fuettern")
        {
            messageWindow.SetupMessageWindow(
                "Fuettern",
                "Hier kannst du dein Tier füttern, du musst nur das Heu zum Futterplatz tragen!",
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
        }
        if (!petSystem.Kuemmern_onBoardingDone && currentSceneName == "Kuemmern")
        {
            messageWindow.SetupMessageWindow(
                "Kuemmern",
                "Hier kannst du Ihr Haustier waschen und mit ihm spielen",
                null,
                null,
                null,
                null,
                "Ok",
                StartMessageKuemmernMiddleButtonClick,
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
    private void StartMessageKuemmernMiddleButtonClick()
    {
        messageWindow.DeactivateMessageWindow();
        pet_CameraIntro.ActivateCameraAnimation(false);
        petSystem.Kuemmern_onBoardingDone = true;
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

    public void ToggleVisibiliyCleanItem(Boolean setBoolean)
    {
        cleanItem1.SetActive(setBoolean);
        cleanItem2.SetActive(setBoolean);

    }

    public void ToggleVisibiliyPlayItem(Boolean setBoolean)
    {
        playItem1.SetActive(setBoolean);
        playItem2.SetActive(setBoolean);

    }

    public void GameScene(){
        Debug.Log(petSystem.gameSelected);
        ToggleVisibiliyBacktoGame(false);
        pet_CameraIntro.ActivateCameraAnimation(true);
        petSystem.gameSelected = false;
    }

    public void CleanPet(){
        ToggleVisibiliyPlayItem(false);
        ToggleVisibiliyCleanItem(true);
    }



    public void PlayPet(){
        ToggleVisibiliyCleanItem(false);
        ToggleVisibiliyPlayItem(true);
    }

    
}   
