using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinks : MonoBehaviour
{
    private static string SuperMarioWorkout = "https://www.youtube.com/watch?v=2CXG02qzWcM";
    private static string DisneyDanceWorkout = "https://www.youtube.com/watch?v=FhmtR3YzBmQ";
    private static string PokemonKickBoxWorkout = "https://www.youtube.com/watch?v=F-roDdEkSHQ";
    private static string SoccerTricksBeginner = "https://www.youtube.com/watch?v=aSnGxTxJ5SQ";

    public void SuperMarioWorkoutKlick()
    {
         Application.OpenURL(SuperMarioWorkout);
    }
    public void SoccerTricksBeginnerKlick()
    {
        Application.OpenURL(SoccerTricksBeginner);
    }

    public void DanceWorkoutKlick()
    {
        Application.OpenURL(DisneyDanceWorkout);
    }
    public void PokemonKickBoxWorkoutKlick()
    {
        Application.OpenURL(PokemonKickBoxWorkout);
    }
    public void LoadChoppingGame()
    {
        SceneManager.Load(SceneManager.Scene.WoodChopping);
    }

    public void LoadGameSelection()
    {
        SceneManager.Load(SceneManager.Scene.chooseAction);
    }

    public void LoadCastleScene()
    {
        SceneManager.Load("Main_Castle");
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
