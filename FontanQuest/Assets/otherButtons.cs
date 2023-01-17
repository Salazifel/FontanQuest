using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherButtons : MonoBehaviour
{
    public void save_Game()
    {
        GameObject.Find("MasterData").GetComponent<SavingGameData>().save_Game();
    }   

    public void OpenQuestScene()
    {
        save_Game();
        UnityEngine.SceneManagement.SceneManager.LoadScene("chooseAction");
    }

    public void OpenMenuScene()
    {
        save_Game();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Screen");
    }
}
