using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HikkingStoryControll : MonoBehaviour
{
    public enum Storys
    {
        FindTheCure
    }

    public Storys HikkingStory;
    public Button StartNextChallengeButton;
    public Button CompletedStoryButton;
    public TextMeshProUGUI StepsText;
    public TextMeshProUGUI StoryPartText;
    public TextMeshProUGUI StepsToUnlockSceneText;
    public Canvas SetLevelCanvas;
    public static int currentIndex = 0;
    public static Story Story;


    #region Find the cure - set up level and scenes
    private static List<int> level1Steps = new List<int>() { 500, 500, 500, 500 };
    private static List<int> level2Steps = new List<int>() { 1000, 1000, 1000, 1000 };
    private static List<int> level3Steps = new List<int>() { 2000, 2000, 1500, 1500 };
    private static Level level1 = new Level(level1Steps, new Reward(Reward.kind.Gold, 1), new Reward(Reward.kind.EP, 200));
    private static Level level2 = new Level(level2Steps, new Reward(Reward.kind.Gold, 2), new Reward(Reward.kind.EP, 500));
    private static Level level3 = new Level(level3Steps, new Reward(Reward.kind.Gold, 4), new Reward(Reward.kind.EP, 1000));
    private static StoryPart FindTheIronOre = new StoryPart(SceneManager.Scene.FindIronOre.ToString(), StoryPart.IronOreSceneIntroText);
    private static StoryPart FindTheVioleteMushroom = new StoryPart(SceneManager.Scene.FindMushroom.ToString(), StoryPart.MushroomSceneIntroText);
    // private static StoryPart FindTheButterFly = new StoryPart(SceneManager.Scene.FindTheButterFly.ToString(), StoryPart.FindTheButterflyText);
    private static StoryPart SolveTheRiddle = new StoryPart(SceneManager.Scene.SolveTheRiddle.ToString(), StoryPart.SolveTheRiddeText);
    private static string completedText = "Healer: Oh thank you so much for gathering the ingridients. I will start to make the cure imeadiatly!!";
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        StartNextChallengeButton.gameObject.SetActive(true);
        CompletedStoryButton.gameObject.SetActive(false);
        Debug.Log(currentIndex);
        // start a new story
        if (currentIndex == 0)
        {
            SetStory();
            SetLevelCanvas.gameObject.SetActive(true);
        }
        else
        {        // load the next scene in the story

            if (currentIndex < Story.Parts.Count && currentIndex != 0)
            {
                SetLevelCanvas.gameObject.SetActive(false);
                StepsToUnlockSceneText.text = "Walk " + Story.Steps[currentIndex].ToString() + " Steps: ";
                StoryPartText.text = Story.Parts[currentIndex].PreviewText;
                StepsText.text = "0";
                CompletedStoryButton.gameObject.SetActive(false);
            }
            // show the completed text in the HikkingStoryManager scene
            else
            {
                Debug.Log("final scene");
                StoryPartText.text = completedText;
                StepsText.gameObject.SetActive(false);
                StartNextChallengeButton.gameObject.SetActive(false);
                StepsToUnlockSceneText.gameObject.SetActive(false);
                CompletedStoryButton.gameObject.SetActive(true);
            }
        }
    }

    public void CompleteStory()
    {
        currentIndex = 0;
        int goldReward = Story.Reward1.Amount;
        ResourceContainer.changeRes(gold: goldReward);
        SceneManager.Load(SceneManager.Scene.chooseAction);
    }

    public void SetLevel1()
    {
        SetLevel(1);
    }

    public void SetLevel2()
    {
        SetLevel(2);
    }

    public void SetLevel3()
    {
        SetLevel(3);
    }

    private void SetLevel(int level)
    {
        Story.Level(level);
        SetLevelCanvas.gameObject.SetActive(false);
        StepsToUnlockSceneText.text = "Walk " + Story.Steps[currentIndex].ToString() + " Steps: ";
    }


    public static void CompletedChapter()
    {
        currentIndex++;
    }

    public void QuitGame()
    {
        currentIndex = 0;
        Story = null;
        OpenLinks links = GetComponent<OpenLinks>();
        if (links == null)
        {
            links = this.gameObject.AddComponent<OpenLinks>();
        }
        links.LoadGameSelection();
    }

    public void LoadNextScene()
    {
        if (currentIndex < Story.Parts.Count)
        {
            StartNextChallengeButton?.gameObject.SetActive(false);
            SceneManager.Load(Story.Parts[currentIndex].SceneName);
        }
        else
        {
            SceneManager.Load(SceneManager.Scene.HikkingStoryManager);
        }
    }

    private void SetStory()
    {
        switch (this.HikkingStory)
        {
            case Storys.FindTheCure:
                var storyParts = new List<StoryPart>() { FindTheVioleteMushroom, SolveTheRiddle, FindTheIronOre };
                Story = new Story(Storys.FindTheCure.ToString(), storyParts, level1, level2, level3);
                break;
            default:
                Story = null;
                break;
        }
    }
    void UpdateSteps(int steps)
    {
        if (steps > Story.Steps[currentIndex])
        {
            StartNextChallengeButton?.gameObject.SetActive(true);
            StepsText.text = steps.ToString();
        }
    }
}
public class Level
{
    public List<int> Steps { get; private set; }
    public Reward Reward1 { get; private set; }
    public Reward Reward2 { get; private set; }

    public Level(List<int> steps, Reward reward1, Reward reward2)
    {
        Steps = steps;
        Reward1 = reward1;
        Reward2 = reward2;
    }
}
public class Story
{
    public List<StoryPart> Parts;
    public string Title;
    public List<int> Steps;
    private Level _level1;
    private Level _level2;
    private Level _level3;
    public Reward Reward1;
    public Reward Reward2;

    public Story(string title, List<StoryPart> storyParts, Level level1, Level level2, Level level3)
    {
        Title = title;
        Parts = storyParts;
        _level1 = level1;
        _level2 = level2;
        _level3 = level3;

    }

    public void Level(int level)
    {
        switch (level)
        {
            case 1:
                Steps = _level1.Steps;
                Reward1 = _level1.Reward1;
                Reward2 = _level1.Reward2;
                return;
            case 2:
                Steps = _level2.Steps;
                Reward1 = _level2.Reward1;
                Reward2 = _level2.Reward2;
                return;
            case 3:
                Steps = _level3.Steps;
                Reward1 = _level3.Reward1;
                Reward2 = _level3.Reward2;
                return;
        }
    }
}
public class StoryPart
{
    public string SceneName;
    public string PreviewText;

    #region previewTexts
    public const string MushroomSceneIntroText = "The first ingridient is some rare mushroom. I just know the right place to find it. The Mushroom meadow! Let's go!!";
    public const string IronOreSceneIntroText = "Alright one ingridient left. The last one is iron ore. Maybe we can find some in the bear teretory.";
    public const string FindTheButterflyText = "Alright one ingridient left. Its a special butterfly. I heart that there are many butterflys in the clearing in the woods.";
    public const string BackToTheWizardText = "Perfect we have all ingridients, lets go back to the village so that we can make the cure";
    public const string SolveTheRiddeText = "Ok one done, two left. The next on the list is a dragon tooth. I heard of a strange old man in the forest how collects a lot of weird stuff. Maybe he has one.";
    #endregion previewTexts

    public StoryPart(string sceneName, string previewText)
    {
        SceneName = sceneName;
        PreviewText = previewText;
    }
}
