using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public GameObject MainMenuPanel;

    public void OpenHomeParent()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeParentSection");
    }

    public void OpenEinstellungenParent()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EinstellungenParentSection");
    }

    public void OpenStatistikParent()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StatistikParentSection");
    }

    public void OpenErkundenParent()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ErkundenParentSection");
    }

    public void OpenMainMenuPanel()
    {
        if (MainMenuPanel != null)
        {
            MainMenuPanel.SetActive(true);
        }
    }

    public void CloseMainMenuPanel()
    {
        if (MainMenuPanel != null)
        {
            MainMenuPanel.SetActive(false);
        }
    }

    public void OpenSerialized(string serializedSceneName)
    {
        // Check if the scene name is valid or not
        if (!string.IsNullOrEmpty(serializedSceneName))
        {
            // Load the scene with the given name
            UnityEngine.SceneManagement.SceneManager.LoadScene(serializedSceneName);
        }
        else
        {
            Debug.LogError("Serialized scene name is null or empty.");
        }
    }
}