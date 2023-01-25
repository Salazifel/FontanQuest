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
    public Button FinishChapterButton;
    public TextMeshProUGUI FeedBackText;

    //hint UI
    public GameObject Hintwindow;
    public TextMeshProUGUI HintText;

    //dialog UI
    public GameObject Dialog;
    public TextMeshProUGUI DialogText;

    //define riddles
    private static Queue<Riddle> Riddles = new Queue<Riddle>();

    // define dialog, riddle and feedback strings
    private static Queue<string> Dialogs = new Queue<string>();
    #region dialog strings
    private static string introText = $"Merkwuerdiger Mann: {Environment.NewLine}Ich habe gehoert jemand sucht nach mir wegen eines Drachenzahnes.Nun ich bin Akirbus und ihr habt Glueck ich habe wirklich einen. Es ist eurer wenn ihr 3 einfache Raetsel loest. Hihihihi";
    private static string dialogText2 = $"Akirbus: {Environment.NewLine}Grrr...nun gut das war natuerlich nur zum aufwaermen das naechste ist viel schwerer";
    private static string dialogText3 = $"Akirbus: {Environment.NewLine}Waaaas? Wie konntet ihr das nur so schnell loesen?";
    private static string dialogText4 = $"Akirbus: {Environment.NewLine}Na schoen, hier habt ihr den Drachenzahn. Nun verzieht euch, ich muss mir neue Raetsel ausdenken.";
    #endregion

    #region feedback strings
    private const string Feedback1 = "Haha das ist falsch";
    private const string Feedback2 = "Noooooooope";
    private const string Feedback3 = "Wo hast du den diese Idee her, von einem fliegenden Fliegenpilz? Hihihi";
    #endregion

    #region riddle definition
    private string _riddle1Text = $"1.Raetsel:{Environment.NewLine}Es gehoert dir, aber deine Freunde benutzen es viel oefter als du.";
    private string _hint1Text = "Es handelt sich um ein Wort";
    private string _solution1 = "Name";

    private string _riddle2Text = $"2. Raetsel:{Environment.NewLine}Ich mache ein lautes Gerausche wenn ich mich veraendere und bin danach viel groeﬂer als vorher. Was bin ich?";
    private string _hint2Text = "Man kann mich in Kinos kaufen";
    private string _solution2 = "Popcorn";

    private string _riddle3Text = $"3. Raetsel{Environment.NewLine}Es gibt nur ein Wort das falsch im Woerterbuch geschrieben wird. Welches Wort ist es?";
    private string _hint3Text = "Das Wort ist ebenfalls im Raetsel enthalten";
    private string _solution3 = "falsch";

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //create riddles
        Riddle Riddle1 = new Riddle(_riddle1Text, _solution1, _hint1Text);
        Riddle Riddle2 = new Riddle(_riddle2Text, _solution2, _hint2Text);
        Riddle Riddle3 = new Riddle(_riddle3Text, _solution3, _hint3Text);

        // store riddles in queue
        Riddles.Enqueue(Riddle1);
        Riddles.Enqueue(Riddle2);
        Riddles.Enqueue(Riddle3);

        // store dialogs in queue
        Dialogs.Enqueue(introText);
        Dialogs.Enqueue(dialogText2);
        Dialogs.Enqueue(dialogText3);
        Dialogs.Enqueue(dialogText4);

        // set canvas visibilyties
        Dialog.SetActive(true);
        Hintwindow.gameObject.SetActive(false);
        RiddleUI.gameObject.SetActive(false);
        FinishChapterButton.gameObject.SetActive(false);
        

        ShowNextDialog();
    }

    /// <summary>
    /// read in the answer from the input field and compares it to the solution of the riddle
    /// </summary>
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

    /// <summary>
    /// close the hint canvas and returns to the riddle
    /// </summary>
    public void CloseHint()
    {
        Hintwindow.SetActive(false);
    }

    /// <summary>
    /// shows the hint canvas with a hint for the curent riddle
    /// </summary>
    public void Hint()
    {
        Hintwindow.SetActive(true);
        HintText.text = Riddles.Peek().Hint;
    }

    /// <summary>
    /// shows the next riddle in the queue 
    /// </summary>
    public void ShowNextRiddle()
    {
        Dialog.gameObject.SetActive(false);
        RiddleUI.gameObject.SetActive(true);
        RiddleText.text = Riddles.Peek().RiddleText;
        InputField.text = String.Empty;
    }

    private void CorrectAnswer()
    {
        FeedBackText.text = " ";
        Riddles.Dequeue();
        ShowNextDialog();
            }
    private void ShowNextDialog()
    {
        Dialog.gameObject.SetActive(true);
        DialogText.text = Dialogs.Dequeue();
        if(Dialogs.Count == 0)
        {
            SolveRiddleButton.gameObject.SetActive(false);
            FinishChapterButton.gameObject.SetActive(true);
        }
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
