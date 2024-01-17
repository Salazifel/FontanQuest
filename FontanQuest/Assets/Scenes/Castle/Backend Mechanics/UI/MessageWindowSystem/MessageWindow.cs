using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;
using UnityEditor;

public class MessageWindow : MonoBehaviour
{
    private TextMeshProUGUI headline; // Assuming you are using TextMeshPro UGUI
    private TextMeshProUGUI mainText; // Assuming you are using TextMeshPro UGUI

    private Button leftButton;
    private Button rightButton;
    private Button middleButton;

    // Define UnityEvents for buttons
    private UnityEvent leftButtonEvent;
    private UnityEvent rightButtonEvent;
    private UnityEvent middleButtonEvent;

    // Audio
    private AudioSource audioSource;
    private AudioSource backgroundMusic;
    private float backgroundMusicVolume;
    private float backgroundMusicMessageReducedVolume = 0.2f;

    // all characters
    private GameObject CharacterDisplayRawImage;
    private Dictionary<string, GameObject> CharacterDictionary = new Dictionary<string, GameObject>();
    private GameObject CharacterPrefabs;
    public enum Character_options
    {
        Character_Female_Druid,
        Character_Female_Gypsy,
        Character_Female_Peasant_01,
        Character_Female_Peasant_02,
        Character_Female_Queen,
        Character_Female_Witch,
        Character_Male_Baird,
        Character_Male_King,
        Character_Male_Peasant_01,
        Character_Male_Rouge_01,
        Character_Male_Sorcerer,
        Character_Male_Wizard,
        none
    }

    public void SetupMessageWindowWorkerFunction(MessageObjectBlueprint.messageObject messageObject) {
        // activate the object so all changes can be made
        this.gameObject.SetActive(true);

        // Set headline and main text
        AdjustHeadline(messageObject.headlineText);
        AdjustMainText(messageObject.mainTextContent);

        // Set up buttons
        DeactivateAllButtons();
        if (!string.IsNullOrEmpty(messageObject.leftButtonText) && messageObject.leftButtonCallback != null)
        {
            // Enable the left button and set text and callback
            AdjustButton(leftButton, messageObject.leftButtonText, messageObject.leftButtonCallback);
        }

        if (!string.IsNullOrEmpty(messageObject.rightButtonText) && messageObject.rightButtonCallback != null)
        {
            // Enable the right button and set text and callback
            AdjustButton(rightButton, messageObject.rightButtonText, messageObject.rightButtonCallback);
        }

        if (!string.IsNullOrEmpty(messageObject.middleButtonText) && messageObject.middleButtonCallback != null)
        {
            // Only the middle button is to be shown
            AdjustButton(middleButton, messageObject.middleButtonText, messageObject.middleButtonCallback);
        }
        else
        {
            // If middle button text is not set, assume two-button layout
            middleButton.gameObject.SetActive(false);
        }

        // Select right character
        ActivateCharacter(messageObject.character_Options);

        // Select the right Animation
        ActivateAnimation(messageObject.animations);

        // Select and start Audio
        ActivateAudioSource(messageObject.audioClipPath);

        // Display Message
        
        if (CharacterDisplayRawImage) {
            CharacterDisplayRawImage.SetActive(true);
        }
    }

    public void SetupMessageWindowByMessageObject(MessageObjectBlueprint.messageObject messageObject) {
        SetupMessageWindowWorkerFunction(messageObject);
    }

    public void SetupMessageWindow(
                                    string headlineText,
                                    string mainTextContent,
                                    string leftButtonText,
                                    UnityAction leftButtonCallback,
                                    string rightButtonText,
                                    UnityAction rightButtonCallback,
                                    string middleButtonText,
                                    UnityAction middleButtonCallback,
                                    Character_options character_Options,
                                    AnimationLibrary.Animations animations,
                                    string audioClipPath)
    {
        MessageObjectBlueprint.messageObject messageObject = new MessageObjectBlueprint.messageObject(
                    headlineText, 
                    mainTextContent, 
                    leftButtonText, 
                    leftButtonCallback, 
                    rightButtonText, 
                    rightButtonCallback, 
                    middleButtonText, 
                    middleButtonCallback, 
                    character_Options, 
                    animations,
                    audioClipPath);
        SetupMessageWindowWorkerFunction(messageObject);
    }

    public void ActivateAudioSource(string audioClipPath)
    {
        if (audioClipPath == null)
        {
            return; // no audio is supposed to be played
        }

        AudioClip clip = Resources.Load<AudioClip>(audioClipPath);

        // deactivate background music
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = backgroundMusicMessageReducedVolume;
        }
    
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play(0);
        }
        else
        {
            Debug.LogError("AudioClip not found.");
        }
    }

    public void DeactivateAudioSource()
    {
        audioSource.Stop();
    }

    public void ActivateCharacter(Character_options characterOption)
    {
        // Convert the enum value to string
        string characterKey = characterOption.ToString();

        // Check if the selected character is 'none'
        if (characterOption == Character_options.none)
        {
            return;
        }

        // Find and activate the corresponding GameObject
        if (CharacterDictionary.TryGetValue(characterKey, out GameObject characterPrefab))
        {
            // Activate the GameObject
            characterPrefab.SetActive(true);
        }
        else
        {
            Debug.LogError("Character prefab not found for: " + characterKey);
        }
    }

    public void ActivateAnimation(AnimationLibrary.Animations animation)
    {
        // Check if the character prefab is valid
        if (CharacterPrefabs == null)
        {
            Debug.LogError("Character prefab is null.");
            return;
        }

        // Get the Animator component from the character prefab
        Animator animator = CharacterPrefabs.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the character prefab.");
            return;
        }

        // Get the appropriate animation controller from the AnimationLibrary
        RuntimeAnimatorController controller = AnimationLibrary.getAnimationController(animation);

        // Assign the controller to the Animator
        if (controller != null)
        {
            animator.runtimeAnimatorController = controller;
        }
        else
        {
            Debug.LogError("Animation controller not found for: " + animation.ToString());
        }
    }

    void Awake()
    {
        // Assign the objects above from the children of the object this script is attached to 
        headline = transform.Find("TextHeadline/Headline").GetComponent<TextMeshProUGUI>();
        mainText = transform.Find("TextBox/MainText").GetComponent<TextMeshProUGUI>();

        leftButton = transform.Find("LeftButton").GetComponent<Button>();
        rightButton = transform.Find("RightButton").GetComponent<Button>();
        middleButton = transform.Find("MiddleButton").GetComponent<Button>();

        DeactivateAllButtons();

        audioSource = transform.Find("MessageWindowAudioSource").GetComponent<AudioSource>();
        try {
            backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
            backgroundMusicVolume = backgroundMusic.volume;
        } catch {
            // no background music available in this scene
            backgroundMusic = null;
        }

        leftButton.onClick.AddListener(DefaultLeftButtonClick);
        rightButton.onClick.AddListener(DefaultRightButtonClick);
        middleButton.onClick.AddListener(DefaultMiddleButtonClick);

        // Get all the characters
        CharacterPrefabs = GameObject.Find("CharacterPrefabs");

        // List of character names
        // string[] characterNames = {
        //     "Character_Female_Druid", "Character_Female_Gypsy", 
        //     "Character_Female_Peasant_01", "Character_Female_Peasant_02", 
        //     "Character_Female_Queen", "Character_Female_Witch", 
        //     "Character_Male_Baird", "Character_Male_King", 
        //     "Character_Male_Peasant_01", "Character_Male_Rouge_01", 
        //     "Character_Male_Sorcerer", "Character_Male_Wizard"
        // };

        // Find all GameObjects with the tag "MessageWindow"
        GameObject[] allObjectsWithTag = GameObject.FindGameObjectsWithTag("MessageWindow");

        // Iterate through the character names
        foreach (Character_options character_option in Enum.GetValues(typeof(Character_options)))
        {
            string characterName = character_option.ToString();
            // Iterate through each GameObject with the tag
            foreach (GameObject obj in allObjectsWithTag)
            {
                // Check if the GameObject's name matches the character name
                if (obj.name == characterName)
                {
                    // Add the found object to the dictionary and break the inner loop
                    CharacterDictionary.Add(characterName, obj);
                    break;
                }
            }
        }

        CharacterDisplayRawImage = GameObject.Find("CharacterDisplayRawImage");

        HideAllCharacters();
    }

    public void HideAllCharacters()
    {
        foreach (KeyValuePair<string, GameObject> entry in CharacterDictionary)
        {
            if (entry.Value != null)
            {
                entry.Value.SetActive(false);
            }
        }
    }

    public void AdjustHeadline(string text)
    {
        headline.text = text;
    }

    private void AdjustButton(Button button, string text, UnityAction callback)
    {
        button.gameObject.SetActive(true);
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(callback);
    }

    public void AdjustMainText(string text)
    {
        mainText.text = text;
    }

    public void DeactivateMessageWindow()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = backgroundMusicVolume;
        }

        this.gameObject.SetActive(false);
        if (CharacterDisplayRawImage) {
            CharacterDisplayRawImage.SetActive(false);
        }
    }

    void DeactivateAllButtons()
    {
        leftButton.gameObject.SetActive(false);
        rightButton.gameObject.SetActive(false);
        middleButton.gameObject.SetActive(false);

        leftButton.onClick.RemoveAllListeners();
        rightButton.onClick.RemoveAllListeners();
        middleButton.onClick.RemoveAllListeners();
    }

    // Set the callbacks for the buttons
    public void SetButtonCallbacks(UnityAction leftAction, UnityAction rightAction, UnityAction middleAction)
    {
        if (leftAction != null)
        {
            leftButton.onClick.AddListener(leftAction);
        }
        if (rightAction != null)
        {
            rightButton.onClick.AddListener(rightAction);
        }
        if (middleAction != null)
        {
            middleButton.onClick.AddListener(middleAction);
        }
    }

    private void DefaultLeftButtonClick()
    {
        Debug.Log("Left button clicked!");
    }

    private void DefaultRightButtonClick()
    {
        Debug.Log("Right button clicked!");
    }

    private void DefaultMiddleButtonClick()
    {
        Debug.Log("Middle button clicked!");
    }

    private void CharacterManagement()
    {

    }

    // ########################################### using the EVENTSYSTEM
    private void OnEnable()
    {
        Message_EventSystem.OnMessageReceived += HandleMessage;
    }

    private void OnDisable()
    {
        Message_EventSystem.OnMessageReceived -= HandleMessage;
    }

    private void HandleMessage(MessageObjectBlueprint.messageObject messageObject)
    {
        SetupMessageWindowByMessageObject(messageObject);
    }
}
