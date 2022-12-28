using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HikkingStoryControll : MonoBehaviour
{
    public List<HikkingStoryPart> StoryPart;
    public List<int> StepsToUnlockScene= new List<int> { 3,3,3,3};
    public Button StartNextChallengeButton;
    public TextMeshProUGUI StepsText;
    public TextMeshProUGUI StepsToUnlockSceneText;
    public TextMeshProUGUI Title =
    public static int currentIndex = 0;
    
        // Start is called before the first frame update
    void Start()
    {
        StartNextChallengeButton.gameObject.SetActive(false);
        StepsToUnlockSceneText.text = "Walk " + StepsToUnlockScene[currentIndex].ToString() + "Steps: ";
        StepsText.text = "0";
        Title.text =  "Cure the villagers";
    }


    void LoadNextScene()
    {
        StartNextChallengeButton?.gameObject.SetActive(false);
        currentIndex++;
    }

    void Leave()
    {

    }

    void UpdateSteps(int steps)
    {
        if (steps > StepsToUnlockScene[currentIndex])
        {
            StartNextChallengeButton?.gameObject.SetActive(true);
            StepsText.text = steps.ToString();
        }
    }
}

public class HikkingStoryPart
{
    public string SceneName;
    public string PreviewText;

    #region previewTexts
    public static string MushroomSceneIntroText = "The first ingridient is some rare mushroom. I just know the right place to find it. The Mushroom meadow! Let's go!!";
    public static string IronOreSceneIntroText = "Ok one done, two left. The next on the list is iron ore. Maybe we can find some in the bear teretory.";
    public static string FindTheButterflyText = "Alright one ingridient left. Its a special butterfly. I heart that there are many butterflys in the clearing in the woods.";
    public static string BackToTheWizardText = "Perfect we have all ingridients, lets go back to the village so that we can make the cure";
    #endregion previewTexts

    public HikkingStoryPart(string sceneName, string previewText)
    {
        SceneName = sceneName;
        PreviewText = previewText;
    }
}
