using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinks : MonoBehaviour
{
    private static string SuperMarioWorkout = "https://www.youtube.com/watch?v=2CXG02qzWcM";
    private static string DisneyDanceWorkout = "https://www.youtube.com/watch?v=FhmtR3YzBmQ";

    public void SuperMarioWorkoutKlick()
    {
         Application.OpenURL(SuperMarioWorkout);
    }

    public void DanceWorkoutKlick()
    {
        Application.OpenURL(DisneyDanceWorkout);
    }

    public void LoadChoppingGame()
    {
        SceneManager.Load(SceneManager.Scene.WoodChopping);
    }

    public void LoadGameSelection()
    {
        SceneManager.Load(SceneManager.Scene.chooseAction);
    }

    public void LoadStoneMiningGame()
    {
        SceneManager.Load(SceneManager.Scene.StoneCrushing);
    }
    
    public void LoadHikkingStory()
    {
        SceneManager.Load(SceneManager.Scene.HikkingStoryManager);
    }

    public void LoadVillage()
    {
        SceneManager.Load(SceneManager.Scene.SampleScene);
    }

    public void LoadMenueScene()
    {
        SceneManager.Load("Main Screen");
    }

    public void LoadMedalScene()
    {
        SceneManager.Load(SceneManager.Scene.MedalOverview);
    }
}
