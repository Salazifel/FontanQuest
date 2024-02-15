using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToStoryButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToStory_AsianMonk()
    {
        SceneManager.Load("AM-2D-Game");
    }
    public void BackToStory_FitnessBoxing()
    {
        SceneManager.Load("FitnessBoxing");
    }
    public void BackToStory_DoodleJump()
    {
        SceneManager.Load("DoodleJumpStoryScene");
    }
    public void BackToStory_WeedThePlant()
    {
        SceneManager.Load("WeedThePlant");
    }

}
