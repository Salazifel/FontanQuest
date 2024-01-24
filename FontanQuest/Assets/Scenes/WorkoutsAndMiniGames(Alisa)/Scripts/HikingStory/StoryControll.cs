using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryControll : MonoBehaviour
{
    public static Queue<SceneManager.Scene> StoryScenes = new Queue<SceneManager.Scene>();


    private void Start()
    {
        if(StoryScenes.Count == 0 )
        {ResetstoryScenes();
        }
    }
    private void ResetstoryScenes()
    {
        StoryScenes.Clear();
        StoryScenes.Enqueue(SceneManager.Scene.FindIronOre);
        StoryScenes.Enqueue(SceneManager.Scene.RunAway);
        StoryScenes.Enqueue(SceneManager.Scene.HikkingStoryManager);
        StoryScenes.Enqueue(SceneManager.Scene.SolveTheRiddle);

        StoryScenes.Enqueue(SceneManager.Scene.HikkingStoryManager);
        StoryScenes.Enqueue(SceneManager.Scene.FindMushroom);
        StoryScenes.Enqueue(SceneManager.Scene.HikkingStoryManager);
        StoryScenes.Enqueue(SceneManager.Scene.HikkingStoryManager);

    }

   

    public void Quit()
    {
        StoryTeller.freshStart = true;
        ResetstoryScenes();
        SceneManager.Load("Main_Castle");
    }

    public void Continue()
    {
        SceneManager.Load(StoryScenes.Dequeue());
    }
}
