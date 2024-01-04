using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsianMonkUI : MonoBehaviour
{
    public Canvas StoryCanvas;
    public Canvas StartMenuCanvas;
    public Canvas FinishCanvas;
    SaveGameObjects.AsianMonkSavingGame asianMonkSavingGame;

    public Canvas[] GameCanvases;
    private int currentLevelIndex = 0; // Index of the current level

    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        StartMenuCanvas.gameObject.SetActive(false);
        GameCanvases[currentLevelIndex].gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

        // Load Asian Monk game data
        asianMonkSavingGame = (SaveGameObjects.AsianMonkSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey(
            new SaveGameObjects.AsianMonkSavingGame(0), "AsianMonkSavingGame", 1);

        if (asianMonkSavingGame == null)
        {
            // If no saved data is found, create a new instance
            asianMonkSavingGame = new SaveGameObjects.AsianMonkSavingGame(0);
        }

        // Instantiate the initial game level (e.g., Level 1)
        LoadGameLevel(currentLevelIndex);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToMenu()
    {
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(true);
        GameCanvases[currentLevelIndex].gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

    }

    public void ChangeToGame()
    {
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(false);
        GameCanvases[currentLevelIndex].gameObject.SetActive(true);
        FinishCanvas.gameObject.SetActive(false);

        currentLevelIndex++;
        if (currentLevelIndex < GameCanvases.Length)
        {
            LoadGameLevel(currentLevelIndex);
        }
        else
        {
            Debug.LogWarning("No more levels available.");
        }
    }

    public void ChangeToComplete()
    {
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(false);
        GameCanvases[currentLevelIndex].gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(true);
    }

    private void LoadGameLevel(int levelIndex)
    {
        // Clear the current game level if exists
        if (levelIndex >= 0 && levelIndex < GameCanvases.Length && GameCanvases[levelIndex] != null)
        {
            GameCanvases[levelIndex].gameObject.SetActive(true);
        }

        // Deactivate previous level(s)
        for (int i = 0; i < GameCanvases.Length; i++)
        {
            if (i != levelIndex && i >= 0 && i < GameCanvases.Length && GameCanvases[i] != null)
            {
                GameCanvases[i].gameObject.SetActive(false);
            }
        }

        // Additional setup or initialization for the game level can be done here
    }

    public void SaveAsianMonkData()
    {
        // Save Asian Monk game data
        SaveGameMechanic.saveSaveGameObject(asianMonkSavingGame, "AsianMonkSavingGame", asianMonkSavingGame.primaryKey);
    }

}

