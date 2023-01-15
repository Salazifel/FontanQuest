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
        UnityEngine.SceneManagement.SceneManager.LoadScene("chooseAction");
    }
}
