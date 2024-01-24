using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButtonScript : MonoBehaviour
{
    public void closeCurrentMiniGame()
    {
        SceneManager.Load("Main_Castle");
    }
}
