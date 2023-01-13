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
    public const string Intro = "This morning many villagers start to feel ill. I think the evil wizard has cursed our island. Maybe I can make a cure but I need some rare ingridients, can you go and get them? Here is a list, now go, hurry!";
    public const string MushroomSceneIntroText = "Alright one ingridient left. The last one is some rare mushroom. I just know the right place to find it. The Mushroom meadow! Let's go!!";
    public const string IronOreSceneIntroText = "The first ingridient is iron ore. Maybe we can find some in the bear teretory.";
    public const string BackToTheWizardText = "Perfect we have all ingridients, lets go back to the village so that we can make the cure";
    public const string SolveTheRiddeText = "Ok one done, two left. The next on the list is a dragon tooth. I heard of a strange old man in the forest how collects a lot of weird stuff. Maybe he has one.";
    #endregion previewTexts

    // Start is called before the first frame update
    void Start()
    {
        if (freshStart)
        {
            LevelCanvas.gameObject.SetActive(true);
            freshStart = false;
            Dialogs.Clear();
            SetStoryDialogs();
            NextText.gameObject.SetActive(true);
        }
        Controller = GetComponent<StoryControll>(); 
        CompleteButton.gameObject.SetActive(false);
        DialogCanvas.gameObject.SetActive(true);
        QuitGameCanvas.gameObject.SetActive(false);
        DialogTextMesh.text = Dialogs.Dequeue();
        if(Dialogs.Count == 0)
        {
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
        LevelCanvas.gameObject.SetActive(false);
    }
    public void SetLevel2()
    {
        level = 2;
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        Steps.Enqueue(1000);
        LevelCanvas.gameObject.SetActive(false);
    }
    public void SetLevel3()
    {
        level = 3;
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
        Steps.Enqueue(2000);
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

    }
    private void SetStoryDialogs()
    {
        Debug.Log("Set story");
        Dialogs.Enqueue(Intro);
        Dialogs.Enqueue(IronOreSceneIntroText);
        Dialogs.Enqueue(SolveTheRiddeText);
        Dialogs.Enqueue(MushroomSceneIntroText);
        Dialogs.Enqueue(BackToTheWizardText);
    }

    public void LoadNextText()
    {
        DialogTextMesh.text = Dialogs.Dequeue();
        NextText.gameObject.SetActive(false);
    }

}
