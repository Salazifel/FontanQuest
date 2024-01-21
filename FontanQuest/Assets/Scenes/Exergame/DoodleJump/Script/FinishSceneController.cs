using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishSceneController : MonoBehaviour
{
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DoodleJumpStoryScene");
    }
}

