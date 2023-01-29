using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryTeller : MonoBehaviour
{
    public static Queue<string> Dialogs = new Queue<string>();
    public static Queue<int> Steps = new Queue<int>();
    public static bool freshStart = true;
    private static int level;
    public GameObject FlutterManager;
    private int steps = 0;
    private int startSteps = -1;
    private flutterCommunication flutterCommunication;

    public Canvas DialogCanvas;
    public Canvas LevelCanvas;
    public Canvas QuitGameCanvas;
    public TextMeshProUGUI DialogTextMesh;
    public TextMeshProUGUI StepsToWalk;
    public TextMeshProUGUI StepsWalked;
    private StoryControll Controller;

    public Button NextText;
    public Button StartNextChallenge;
    public Button CompleteButton;

    #region previewTexts
    public const string Intro = "Heiler: Heute morgen sind viele der Dorfbewohner krank geworden. Ich glaube es war der boese Zauberer. Ich kenne ein Rezept fuer ein Heilmittel aber mir fehlen die Zutaten. Ich brauche eure Hilfe die Zutaten im verwunschenen Wald zu finden!";
    public const string IronOreSceneIntroText = "Die erste Zutat ist Eisenerz vielleicht finden wir welches im Baeren Teritorium";
    public const string SolveTheRiddeText = "Ok die erste Zutat haben wir. Als naechstes steht ein Drachenzahn auf der Liste. Ich habe von einem merkwuerdigen alten Mann im Wald gehoert der solche Sachen sammelt, wir sollten versuchen ihn zu finden.";
    public const string MushroomSceneIntroText = "Was ein komischer alter Kauz aber naja jetzt fehlt nur noch eine Zutat. Irgend so ein komischer Pilz, ich wette wir finden einen auf der Lichtung.";
    public const string BackToTheWizardText = "Super wir haben alles zusammen! Nichts wie zurueck zum Heiler damit er das Heilmittel zubereiten kann. Ich kriege langsam echt Hunger.";
    public const string FinalText = "Heiler: Oh da seid ihr ja wieder und ihr habt alle Zutaten wie ich sehe. Perfekt dann mache ich mich mal gleich ans Werk";
    #endregion previewTexts

    // Start is called before the first frame update
    void Start()
    {
        NextText.gameObject.SetActive(freshStart);
        StartNextChallenge.gameObject.SetActive(!freshStart);
        LevelCanvas.gameObject.SetActive(freshStart);
        if (freshStart)
        {
            freshStart = false;
            Dialogs.Clear();
            SetStoryDialogs();

            CompleteButton.gameObject.SetActive(false);
        }

        Controller = GetComponent<StoryControll>();
        DialogCanvas.gameObject.SetActive(true);
        QuitGameCanvas.gameObject.SetActive(false);
        CompleteButton.gameObject.SetActive(false);
        StartNextChallenge.gameObject.SetActive(false);
        if (FlutterManager != null)
        {
            flutterCommunication = FlutterManager.GetComponent<flutterCommunication>();
            if(Steps.Count > 0)
            {
                flutterCommunication.NewStepValue += NewStepValue;
            }
        }

        // for the last itteration of the story teller
        if (Dialogs.Count == 0)
        {
            StepsToWalk.gameObject.SetActive(false);
            StepsWalked.gameObject.SetActive(false);
            StartNextChallenge.gameObject.SetActive(false);
            CompleteButton.gameObject.SetActive(true);
        }
        else
        {
        DialogTextMesh.text = Dialogs.Dequeue();
        }

        if(Steps.Count != 0)
        {
            StepsToWalk.text = "Laufe " + Steps.Peek().ToString() + " Schritte";
        }
    }

    public void SetLevel1()
    {
        level = 1;
        Steps.Enqueue(30);
        Steps.Enqueue(30);
        Steps.Enqueue(30);
        Steps.Enqueue(30);
        StepsToWalk.text = "Laufe " + Steps.Peek().ToString() + " Schritte";

        LevelCanvas.gameObject.SetActive(false);
        flutterCommunication.NewStepValue += NewStepValue;
    
}
    public void SetLevel2()
    {
        level = 2;
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        StepsToWalk.text = "Laufe " + Steps.Dequeue().ToString() + " Schritte";

        LevelCanvas.gameObject.SetActive(false);
        flutterCommunication.NewStepValue += NewStepValue;
    
}
    public void SetLevel3()
    {
        level = 3;
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
        StepsToWalk.text = "Laufe " + Steps.Dequeue().ToString() + " Schritte";

        LevelCanvas.gameObject.SetActive(false);
        flutterCommunication.NewStepValue += NewStepValue;

    }

    public void StartNextChapter()
    {
        Steps.Dequeue();
        Controller.Continue();
        flutterCommunication.NewStepValue -= NewStepValue;
    }

    public void NewStepValue(string steps)
    {
        int stepsInt = int.Parse(steps);
        if (startSteps == -1)
        {
            startSteps = stepsInt;
        }
        this.steps = stepsInt - startSteps;
        StepsWalked.text = this.steps.ToString();
        if (this.steps >= Steps.Peek())
        {
            StartNextChallenge.gameObject.SetActive(true);
        }
    }

    public void QuitGameWindow()
    {
        QuitGameCanvas.gameObject.SetActive(true);
    }

    public void HideQuitGameWindow()
    {
        QuitGameCanvas.gameObject.SetActive(false);
    }
    public void Complete()
    {
        MiniGameData.CompletedFindTheCure(level);
        Steps = new Queue<int>();
        Dialogs = new Queue<string>();
        SceneManager.Load(SceneManager.Scene.chooseAction);
    }
    private void SetStoryDialogs()
    {
        Dialogs.Enqueue(Intro);
        Dialogs.Enqueue(IronOreSceneIntroText);
        Dialogs.Enqueue(SolveTheRiddeText);
        Dialogs.Enqueue(MushroomSceneIntroText);
        Dialogs.Enqueue(BackToTheWizardText);
        Dialogs.Enqueue(FinalText);
    }

    public void LoadNextText()
    {
        DialogTextMesh.text = Dialogs.Dequeue();
        NextText.gameObject.SetActive(false);
    }
}
