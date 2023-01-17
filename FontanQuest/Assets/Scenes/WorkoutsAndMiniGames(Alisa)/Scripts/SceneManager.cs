using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManager
{
    public enum Scene
    {
        chooseAction,

        // Game Scenes 
        StoneCrushing,
        WoodChopping,

        // Hikking Story Scenes
        HikkingStoryManager,
        FindIronOre,
        FindMushroom,
        FindTheButterFly,
        SolveTheRiddle,
        RunAway,
        SampleScene
    }

    /// <summary>
    /// !!! Attention !!!
    /// Befor you can load a scene with this class, the scene has to be introduced
    /// to the application. Follow these steps:
    /// --> open your Unity project in unity
    /// --> File 
    /// --> Build Settings 
    /// --> drag and drop the scene into the "Scenes In Build" window
    /// </summary>
    /// <param name="scene"></param>
    public static void Load(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }

    /// <summary>
    /// Opens the scene with the name scene.
    /// !!! Attention 1: the scene name has to be correct !!!
    /// 
    /// !!! Attention 2:
    /// Befor you can load a scene with this class, the scene has to be introduced
    /// to the application. Follow these steps:
    /// --> open your Unity project in unity
    /// --> File 
    /// --> Build Settings 
    /// --> drag and drop the scene into the "Scenes In Build" window
    /// </summary>
    /// <param name="scene"></param>
    public static void Load(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
