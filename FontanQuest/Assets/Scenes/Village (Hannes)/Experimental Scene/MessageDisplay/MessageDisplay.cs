using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageDisplay : MonoBehaviour
{
    private GameObject MessageDisplayContainer;
    private TextMeshProUGUI MessageDisplayText;
    private GameObject MessageDisplayBtn;
    private TextMeshProUGUI MessageDisplayBtnText;

    private GameObject MessageDisplayCloseBtn;
    private GameObject Advisor;
    private GameObject EvilWizard;

    private string RemainingMessage;
    private string currentSender;

    private int StringLen = 180;

    private bool MessageDisplayActive = false;

    private List<Message> MessageQueue = new List<Message>();

    private class Message
    {
        public string message;
        public string sender;
    }
    
    void Awake()
    {
        MessageDisplayContainer = GameObject.Find("MessageDisplay");
        MessageDisplayText = GameObject.Find("MessageBoxText (TMP)").GetComponent<TextMeshProUGUI>();
        MessageDisplayBtn = GameObject.Find("MessageNext");
        MessageDisplayBtnText = GameObject.Find("Message Next Text (TMP)").GetComponent<TextMeshProUGUI>();
        MessageDisplayCloseBtn = GameObject.Find("MessageClose");
        Advisor = GameObject.Find("Advisor");
        EvilWizard = GameObject.Find("EvilWizard");

        hide_MessageDisplay();
    }

    void hide_MessageDisplay()
    {
        MessageDisplayContainer.SetActive(false);
        Advisor.SetActive(false);
        EvilWizard.SetActive(false);
    }

    void show_MessageDisplay()
    {
        MessageDisplayContainer.SetActive(true);
    }

    void hide_allMessagers()
    {
        Advisor.SetActive(false);
        EvilWizard.SetActive(false);
    }

    public void new_Message(string message, string sender)
    {
        if (MessageDisplayActive)
        {
            MessageQueue.Add(new Message { message = message, sender = sender });
            return;
        }

        showMessageHelper(message, sender);
    }

    public void continue_Message(string message, string sender)
    {
        showMessageHelper(message, sender);
    }

    public void showMessageHelper(string message, string sender)
    {
        MessageDisplayActive = true;

        if (sender == "Advisor")
        {
            hide_allMessagers();
            Advisor.SetActive(true);
        }
        else if (sender == "EvilWizard")
        {
            hide_allMessagers();
            EvilWizard.SetActive(true);
        }

        show_MessageDisplay();
        // check whether the whole message string fits into the message box, if not, split it into multiple messages and show the next button to click through them
        if (message.Length > StringLen)
        {
            // with a maximum string length of 180, find the largest substring from the last whitespace before the 180th character
            int lastSpace = message.Substring(0, StringLen).LastIndexOf(' ');
            if (lastSpace > 0)
            {
                StringLen = lastSpace;
            }
            MessageDisplayText.text = message.Substring(0, StringLen);
            MessageDisplayBtnText.text = "Next";
            MessageDisplayBtn.SetActive(true);
            RemainingMessage = message.Substring(StringLen);
            currentSender = sender;
        }
        else
        {
            MessageDisplayText.text = message;
            MessageDisplayBtnText.text = "Close";
            MessageDisplayBtn.SetActive(true);
            RemainingMessage = "";
            currentSender = "";
        }
    }

    public void MessageNextButtonAction()
    {
        if (RemainingMessage != "")
        {
            continue_Message(RemainingMessage, currentSender);
        }
        else
        {
            MessageDisplayActive = false;
            hide_MessageDisplay();
        }
    }

    public void MessageCloseButtonAction()
    {
        MessageDisplayActive = false;
        hide_MessageDisplay();
    }

    void Update()
    {
        if (MessageQueue.Count > 0)
        {
            Message nextMessage = MessageQueue[0];
            MessageQueue.RemoveAt(0);
            new_Message(nextMessage.message, nextMessage.sender);
        }
    }
}
