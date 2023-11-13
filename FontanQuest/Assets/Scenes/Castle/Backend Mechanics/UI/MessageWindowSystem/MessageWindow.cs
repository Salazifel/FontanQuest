using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

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

    public void SetupMessageWindow(
    string headlineText,
    string mainTextContent,
    string leftButtonText,
    UnityAction leftButtonCallback,
    string rightButtonText,
    UnityAction rightButtonCallback,
    string middleButtonText,
    UnityAction middleButtonCallback)
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

    public void AdjustButtons(string text1, string text2 = null)
    {
        DeactivateAllButtons();

        // If 'text2' is null or empty, only show the middle button
        if (string.IsNullOrEmpty(text2)) // Use string.IsNullOrEmpty to check for both null and empty strings
        {
            middleButton.gameObject.SetActive(true); // Use SetActive to change the active state
            middleButton.GetComponentInChildren<TextMeshProUGUI>().text = text1;
        }
        else
        {
            leftButton.gameObject.SetActive(true);
            rightButton.gameObject.SetActive(true);

            // Assign texts to buttons, assuming each button has one TextMeshProUGUI child
            leftButton.GetComponentInChildren<TextMeshProUGUI>().text = text1;
            rightButton.GetComponentInChildren<TextMeshProUGUI>().text = text2;
        }
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

}
