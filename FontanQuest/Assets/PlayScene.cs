using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScene : MonoBehaviour
{  
    public void OpenQuest()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("chooseAction");
    }

    public void OpenGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main_Castle");
    }
}
