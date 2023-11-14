using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

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

    // all characters
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
        Character_Male_Peasant_02,
        Character_Male_Sorcerer,
        Character_Male_Wizard,
        none
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
    AnimationLibrary.Animations animations)
    {
        // Set headline and main text
        AdjustHeadline(headlineText);
        AdjustMainText(mainTextContent);

        // Set up buttons
        DeactivateAllButtons();
        if (!string.IsNullOrEmpty(leftButtonText) && leftButtonCallback != null)
        {
            // Enable the left button and set text and callback
            AdjustButton(leftButton, leftButtonText, leftButtonCallback);
        }

        if (!string.IsNullOrEmpty(rightButtonText) && rightButtonCallback != null)
        {
            // Enable the right button and set text and callback
            AdjustButton(rightButton, rightButtonText, rightButtonCallback);
        }

        if (!string.IsNullOrEmpty(middleButtonText) && middleButtonCallback != null)
        {
            // Only the middle button is to be shown
            AdjustButton(middleButton, middleButtonText, middleButtonCallback);
        }
        else
        {
            // If middle button text is not set, assume two-button layout
            middleButton.gameObject.SetActive(false);
        }

        // Select right character
        ActivateCharacter(character_Options);

        // Select the right Animation
        ActivateAnimation(animations);

        // Display Message
        this.gameObject.SetActive(true);
    }

    public void ActivateCharacter(Character_options characterOption)
    {
        // Convert the enum value to string
        string characterKey = characterOption.ToString();

        // Check if the selected character is 'none'
        if (characterOption == Character_options.none)
        {
            // Handle the 'none' case if needed
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

        leftButton.onClick.AddListener(DefaultLeftButtonClick);
        rightButton.onClick.AddListener(DefaultRightButtonClick);
        middleButton.onClick.AddListener(DefaultMiddleButtonClick);

        // Get all the characters
        CharacterPrefabs = GameObject.Find("CharacterPrefabs");

        CharacterDictionary.Add("Character_Female_Druid", GameObject.Find("Character_Female_Druid"));
        CharacterDictionary.Add("Character_Female_Gypsy", GameObject.Find("Character_Female_Gypsy"));
        CharacterDictionary.Add("Character_Female_Peasant_01", GameObject.Find("Character_Female_Peasant_01"));
        CharacterDictionary.Add("Character_Female_Peasant_02", GameObject.Find("Character_Female_Peasant_02"));
        CharacterDictionary.Add("Character_Female_Queen", GameObject.Find("Character_Female_Queen"));
        CharacterDictionary.Add("Character_Female_Witch", GameObject.Find("Character_Female_Witch"));
        CharacterDictionary.Add("Character_Male_Baird", GameObject.Find("Character_Male_Baird"));
        CharacterDictionary.Add("Character_Male_King", GameObject.Find("Character_Male_King"));
        CharacterDictionary.Add("Character_Male_Peasant_01", GameObject.Find("Character_Male_Peasant_01"));
        CharacterDictionary.Add("Character_Male_Peasant_02", GameObject.Find("Character_Male_Peasant_02"));
        CharacterDictionary.Add("Character_Male_Sorcerer", GameObject.Find("Character_Male_Sorcerer"));
        CharacterDictionary.Add("Character_Male_Wizard", GameObject.Find("Character_Male_Wizard"));
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
        this.gameObject.SetActive(false);
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

}
