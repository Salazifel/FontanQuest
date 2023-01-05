using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class RiddleManager : MonoBehaviour
{
    // riddle UI
    public GameObject RiddleUI;
    public TextMeshProUGUI RiddleText;
    public TMP_InputField InputField;
    public Button HintButton;
    public Button AnswerButton;
    public Button CloseHintButton;
    public Button SolveRiddleButton;
    public TextMeshProUGUI FeedBackText;

    //hint UI
    public GameObject Hintwindow;
    public TextMeshProUGUI HintText;

    //dialog UI
    public GameObject Dialog;
    public TextMeshProUGUI DialogText;

    //define riddles

    private static Queue<Riddle> Riddles = new Queue<Riddle>();

    // define dialogs
    private static string introText = "I heard someone is looking for me because of a dragon tooth. Well your right I have one, it's yours if you can solve some small riddles";
    private static string dialogText2 = "Grrr well ok that one was just a warm up the second is more difficutl";
    private static string dialogText3 = "What, how could you solve this one so fast, it took me 3 weeks and 143 coffees to solve it";
    private static string dialogText4 = "Well I guess I have to increas the difficulty of my riddles, here is your dragon tooth and now leave me alone I have to think";
    private static Queue<string> Dialogs = new Queue<string>();

    private const string Feedback1 = "Haha thats not right";
    private const string Feedback2 = "Noooooooope";
    private const string Feedback3 = "Where did you get this idea from, a flying mushroom?";

    #region riddle definition
    private string _riddle1Text = $"1.Riddle:{Environment.NewLine} It belongs to you, but your friend use it more.What is it?";
    private string _hint1Text = "It's a word";
    private string _solution1 = "Name";

    private string _riddle2Text = $"Riddle 2:{Environment.NewLine} I make a loud sound when I'm changing. When I do change, I get bigger but weight less. What am I?";
    private string _hint2Text = "You can buy it in cinemas";
    private string _solution2 = "Popcorn";

    private string _riddle3Text = $"Riddle 3:{Environment.NewLine} There’s only one word in the dictionary that’s spelled wrong.What is it?";
    private string _hint3Text = "The word is in the riddle itself";
    private string _solution3 = "wrong";

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Riddle Riddle1 = new Riddle(_riddle1Text, _solution1, _hint1Text);
        Riddle Riddle2 = new Riddle(_riddle2Text, _solution2, _hint2Text);
        Riddle Riddle3 = new Riddle(_riddle3Text, _solution3, _hint3Text);
        Riddles.Enqueue(Riddle1);
        Riddles.Enqueue(Riddle2);
        Riddles.Enqueue(Riddle3);

        Dialogs.Enqueue(introText);
        Dialogs.Enqueue(dialogText2);
        Dialogs.Enqueue(dialogText3);
        Dialogs.Enqueue(dialogText4);

        Hintwindow.gameObject.SetActive(false);
        Dialog.SetActive(true);
        RiddleUI.gameObject.SetActive(false);

        ShowNextDialog();

    }

    public void ShowNextRiddle()
    {
        Dialog.gameObject.SetActive(false);
        RiddleUI.gameObject.SetActive(true);
        Debug.Log(Riddles.Peek());
        Debug.Log(Riddles.Count);
        Debug.Log(Riddles.Peek().RiddleText);
        Debug.Log(Riddles.Peek().Hint);

        RiddleText.text = Riddles.Peek().RiddleText;
    }

    private void ShowNextDialog()
    {
        Dialog.gameObject.SetActive(true);
        DialogText.text = Dialogs.Dequeue();
    }

    public void Hint()
    {
        Hintwindow.SetActive(true);
        HintText.text = Riddles.Peek().Hint;
    }

    public void CloseHint()
    {
        Hintwindow.SetActive(false);
    }

    public void Answer()
    {
        string input = InputField.text;
        if (input != string.Empty)
        {
            if (input.Contains(Riddles.Peek().Solution, System.StringComparison.OrdinalIgnoreCase))
            {
                CorrectAnswer();
                return;
            }
            WrongAnswer();
        }
    }

    private void CorrectAnswer()
    {      
        FeedBackText.text = " ";
                Riddles.Dequeue();
        ShowNextDialog();
    }

    private void WrongAnswer()
    {
        InputField.text = string.Empty;
        switch (FeedBackText.text)
        {
            case Feedback1:
                FeedBackText.text = Feedback2;
                return;
            case Feedback2:
                FeedBackText.text = Feedback3;
                return;
            case Feedback3:
                FeedBackText.text = Feedback1;
                return;
            default:
                FeedBackText.text = Feedback1;
                return;
        }

    }
}
