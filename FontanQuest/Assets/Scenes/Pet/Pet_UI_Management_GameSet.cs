using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pet_UI_Management_GameSet : MonoBehaviour
{   

    public GameObject stats;
    public GameObject hungerParent; // GameObject representing the first set
    public GameObject funParent; // GameObject representing the second set
    public GameObject cleanParent; // GameObject representing the third set

    public DateTime timeNow_GameSet;
    public string currentSceneName;
    // int numofHay;


    public SaveGameObjects.PetSystem petSystem;

    public Pet_UI_Management_GameSet gameSet;
    GameObject messageWindowObject;
    // GameObject nextPetButton;
    GameObject cleanItem1;
    GameObject cleanItem2;
    GameObject playItem1;
    GameObject playItem2;

    // these are icons to show the status of the pet's hunger/fun/cleanliness
    // GameObject infoGraph;
    // GameObject moodDead;
    // GameObject moodSad;
    // GameObject moodNeutral;
    // GameObject moodHappy;
    // GameObject moodLaughing;
    // GameObject hayCube;
    GameObject backtoGameButton;
    GameObject washPetButton;
    GameObject playPetButton;

    private int initialFeedStat; // variable to store initial feed level.
    private MessageWindow messageWindow;
    public Pet_CameraIntro pet_CameraIntro;
    private AnimalManager animalManager;
    // Start is called before the first frame update
    public GameObject pet_GameSet;
    void Start()
    {   
        stats = GameObject.Find("Stats");
        
        hungerParent = GameObject.Find("HungerInfo");
        
        funParent = GameObject.Find("FunInfo");
        
        cleanParent = GameObject.Find("CleanInfo");
        ResumeGame();
        currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        //mood-icons
        // infoGraph = GameObject.Find("Info");
        // moodDead = GameObject.Find("Dead");
        // moodSad = GameObject.Find("Sad");
        // moodNeutral = GameObject.Find("Neutral");
        // moodHappy = GameObject.Find("Happy");
        // moodLaughing = GameObject.Find("Laughing");
        //Toggle all buttons off at the start.
        // ToggleVisibiliyMood(false);
        // infoGraph.SetActive(false);
        if (currentSceneName == "Kuemmern"){
        gameSet = GameObject.Find("Script Controller").GetComponent <Pet_UI_Management_GameSet>();
        petSystem = gameSet.petSystem;
        //items for play and clean
        cleanItem1 = GameObject.Find("bucket-milk");
        cleanItem2 = GameObject.Find("shrub-flowers");
        playItem1 = GameObject.Find("cat-ball");
        playItem2 = GameObject.Find("soccer-ball");
        //
        washPetButton = GameObject.Find("WashPetButton");
        playPetButton = GameObject.Find("PlayPetButton");
        //Toggle all buttons off at the start.
        ToggleVisibiliyCleanItem(false);
        ToggleVisibiliyPlayItem(false);
        }
        else if (currentSceneName == "Fuettern" || currentSceneName == "Rennen" ){
        gameSet = GameObject.Find("Script Controller").GetComponent <Pet_UI_Management_GameSet>();
        petSystem = gameSet.petSystem;
        initialFeedStat = petSystem.Pet_Hunger;
        // if (currentSceneName == "Fuettern"){
        //     numofHay = AddGameDataObjects.getNumOfHay();
        //     hayCube = GameObject.Find("hay-cube");
        //     for (int i = 0; i < numofHay; i++)
        //     {
        //         // Instantiate hay cubes at the same position
        //         Instantiate(hayCube, transform.position, Quaternion.identity);
        //     }

        // }
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

        pet_GameSet = GameObject.Find("Pet");

        if (petSystem != null)
        {   
            animalManager.ActivateAnimal(petSystem.selectedAnimal);
            Debug.Log(petSystem.selectedAnimal);
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
        }
        if (currentSceneName == "Rennen")
            {
            messageWindow.SetupMessageWindow(
                "Rennen",
                "Vermeide Hindernisse mit deinem Lieblingstier!",
                null,
                null,
                null,
                null,
                "Ok",
                StartMessageRennenMiddleButtonClick,
                MessageWindow.Character_options.Character_Male_Rouge_01,
                AnimationLibrary.Animations.Talk,
                null
            );
        } 
        else 
        {   
            animalManager.ActivateAnimal(petSystem.selectedAnimal);
            messageWindow.DeactivateMessageWindow();
            timeNow_GameSet = DateTime.Now;
            pet_CameraIntro.ActivateCameraAnimation(false);
            ToggleVisibiliyBacktoGame(true);
            UpdateMoodUI(petSystem.Pet_Hunger, hungerParent);
            UpdateMoodUI(petSystem.Pet_Happiness, funParent);
            UpdateMoodUI(petSystem.Pet_Cleanliness, cleanParent);
            pet_GameSet.transform.localScale = new Vector3(petSystem.petScaleX, petSystem.petScaleY, petSystem.petScaleZ);
            
        }
        
    }
        void LateUpdate(){


            UpdateMoodUI(petSystem.Pet_Hunger, hungerParent);
                UpdateMoodUI(petSystem.Pet_Happiness, funParent);
                UpdateMoodUI(petSystem.Pet_Cleanliness, cleanParent);

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
    private void StartMessageRennenMiddleButtonClick()
    {   
        pet_GameSet.transform.localScale = new Vector3(petSystem.petScaleX, petSystem.petScaleY, petSystem.petScaleZ);
        messageWindow.DeactivateMessageWindow();
        pet_CameraIntro.ActivateCameraAnimation(false);
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
    public void ToggleVisibiliyMood(Boolean setBoolean)
    {   
        stats.SetActive(setBoolean);
        // moodDead.SetActive(setBoolean);
        // moodSad.SetActive(setBoolean);
        // moodNeutral.SetActive(setBoolean);
        // moodHappy.SetActive(setBoolean);
        // moodLaughing.SetActive(setBoolean);
    }

    // public void moodDisplay(string _nameofGame){
    //     infoGraph.SetActive(true);
    //     if (_nameofGame == "Fuettern"){
    //         if (petSystem.Pet_Hunger >= 91){
    //             ToggleVisibiliyMood(false);
    //             moodLaughing.SetActive(true);
    //         }
    //         else if (petSystem.Pet_Hunger <= 90 && petSystem.Pet_Hunger >= 70){
    //             ToggleVisibiliyMood(false);
    //             moodHappy.SetActive(true);
    //         }
    //         else if (petSystem.Pet_Hunger <= 69 && petSystem.Pet_Hunger >= 40){
    //             ToggleVisibiliyMood(false);

    //             moodNeutral.SetActive(true);
    //             Debug.Log(petSystem.Pet_Hunger);
    //         }
    //         else if (petSystem.Pet_Hunger <= 39 && petSystem.Pet_Hunger >= 10){
    //             ToggleVisibiliyMood(false);
    //             moodSad.SetActive(true);
    //         }
    //         else{
    //             ToggleVisibiliyMood(false);
    //             moodDead.SetActive(true);
    //         }
    //     }      
    // }
public void UpdateMoodUI(int parameterValue, GameObject set)
    {
        ToggleVisibilityMood(set, false,"");

        if (parameterValue >= 91)
        {
            ToggleVisibilityMood(set, true, "Laughing");
        }
        else if (parameterValue <= 90 && parameterValue >= 70)
        {
            ToggleVisibilityMood(set, true, "Happy");
        }
        else if (parameterValue <= 69 && parameterValue >= 40)
        {
            ToggleVisibilityMood(set, true, "Neutral");
        }
        else if (parameterValue <= 39 && parameterValue >= 10)
        {
            ToggleVisibilityMood(set, true, "Sad");
        }
        else
        {
            ToggleVisibilityMood(set, true, "Dead");
        }
    }

public void ToggleVisibilityMood(GameObject set, bool visibility, string nameofChild)
{
    foreach (Transform moodObject in set.transform)
    {
        if (moodObject.name == nameofChild)
        {
            moodObject.gameObject.SetActive(visibility);
        }
        else if (string.IsNullOrEmpty(nameofChild))
        {
            moodObject.gameObject.SetActive(visibility);
        }
        else{
            Debug.Log("No such child exist!");
        }
    }
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
        petSystem.lastLog_Fuettern = DateTime.Now;
        petSystem.lastLog_Spielen = DateTime.Now;
        petSystem.lastLog_Putzen = DateTime.Now;
        petSystem.petScaleX = pet_GameSet.transform.localScale.x;
        petSystem.petScaleY = pet_GameSet.transform.localScale.y;
        petSystem.petScaleZ = pet_GameSet.transform.localScale.z;
        savePetSystem();
        //or implement these within feed/play and clean functions.
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

    void PauseGame ()
    {
        Time.timeScale = 0;
    }
    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
}   
