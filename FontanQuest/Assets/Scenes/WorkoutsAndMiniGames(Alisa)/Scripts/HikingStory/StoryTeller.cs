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
    public const string Intro = "Heiler: Heute morgen sind viele der Dorfbewohner krank geworden. Ich glaube es war der böse Zauberer. Ich kenne ein Rezept für ein Heilmittel aber mir fehlen die Zutaten. Ich brauche eure Hilfe die Zutaten im Verwunschenen Wald zu finden!";
    public const string IronOreSceneIntroText = "Die erste Zutat ist Eisenerz vielleicht finden wir welches im Bären Teritorium";
    public const string SolveTheRiddeText = "Ok die erste Zutat haben wir. Als nächstes steht ein Drachenzahn auf der Liste. Ich habe von einem merkwürdigen alten Mann im Wald gehört der solche Sachen sammelt, wir sollten versuchen ihn zu finden.";
    public const string MushroomSceneIntroText = "Was ein komischer alter Kauz aber naja jetzt fehlt nur noch eine Zutat. Irgend so ein Komischer Pilz, ich wette wir finden einen auf der Lichtung.";
    public const string BackToTheWizardText = "Super wir haben alles zusammen! Nichts wie zurück zum Heiler damit er das Heilmittel zubereiten kann. Ich kriege langsam echt Hunger.";
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
        DialogTextMesh.text = Dialogs.Dequeue();

        // for the last itteration of the story teller
        if (Dialogs.Count == 0)
        {
            StartNextChallenge.gameObject.SetActive(false);
            CompleteButton.gameObject.SetActive(true);
        }
    }

    public void SetLevel1()
    {
        level = 1;
        Steps.Enqueue(500);
        Steps.Enqueue(500);
        Steps.Enqueue(500);
        Steps.Enqueue(500);
        StepsToWalk.text = "Walk " + Steps.Dequeue().ToString() + " Steps";

        LevelCanvas.gameObject.SetActive(false);
    }
    public void SetLevel2()
    {
        level = 2;
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        StepsToWalk.text = "Walk " + Steps.Dequeue().ToString() + " Steps";

        LevelCanvas.gameObject.SetActive(false);
    }
    public void SetLevel3()
    {
        level = 3;
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
        StepsToWalk.text = "Walk " + Steps.Dequeue().ToString() + " Steps";

        LevelCanvas.gameObject.SetActive(false);

    }

    public void StartNextChapter()
    {
        Controller.Continue();
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
        StartNextChallenge.gameObject.SetActive(true);
    }
}
