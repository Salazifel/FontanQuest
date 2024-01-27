using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedThePlantUi : MonoBehaviour
{
    public Canvas StoryCanvas;
    public Canvas IntroCanvas;
    public Canvas[] GameCanvases;
    public Canvas FinishCanvas;

    private SaveGameObjects.WeedThePlantSavingGame weedThePlantSavingGame;
    private int currentLevelIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        IntroCanvas.gameObject.SetActive(false);
        // Deactivate all levels
        for (int i = 0; i < GameCanvases.Length; i++)
        {
            if (GameCanvases[i] != null)
            {
                GameCanvases[i].gameObject.SetActive(false);
            }
        }

        weedThePlantSavingGame = (SaveGameObjects.WeedThePlantSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey("WeedThePlantSavingGame", 1);

        if (weedThePlantSavingGame == null)
        {
            // If no saved data is found, create a new instance
            weedThePlantSavingGame = (SaveGameObjects.WeedThePlantSavingGame)SaveGameObjects.CreateSaveGameObject("WeedThePlantSavingGame");
        }

        FinishCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToStory()
    {
        StoryCanvas.gameObject.SetActive(true);
        IntroCanvas.gameObject.SetActive(false);
        // Deactivate all levels
        for (int i = 0; i < GameCanvases.Length; i++)
        {
            if (GameCanvases[i] != null)
            {
                GameCanvases[i].gameObject.SetActive(false);
            }
        }
        FinishCanvas.gameObject.SetActive(false);
    }

    public void ChangeToIntro()
    {
        StoryCanvas.gameObject.SetActive(false);
        IntroCanvas.gameObject.SetActive(true);
        // Deactivate all levels
        for (int i = 0; i < GameCanvases.Length; i++)
        {
            if (GameCanvases[i] != null)
            {
                GameCanvases[i].gameObject.SetActive(false);
            }
        }
        FinishCanvas.gameObject.SetActive(false);
    }

    public void ChangeToGame()
    {
        StoryCanvas.gameObject.SetActive(false);
        IntroCanvas.gameObject.SetActive(false);
        LoadGameLevel(currentLevelIndex);
        currentLevelIndex++;

        if (currentLevelIndex >= GameCanvases.Length)
        {
            currentLevelIndex = 0; // Reset to the first level if there are no more levels
            Debug.LogWarning("No more levels available. Resetting to the first level.");
        }
        FinishCanvas.gameObject.SetActive(false);
    }

    public void ChangeToFinish()
    {
        StoryCanvas.gameObject.SetActive(false);
        IntroCanvas.gameObject.SetActive(false);
        // Deactivate all levels
        for (int i = 0; i < GameCanvases.Length; i++)
        {
            if (GameCanvases[i] != null)
            {
                GameCanvases[i].gameObject.SetActive(false);
            }
        }
        FinishCanvas.gameObject.SetActive(true);
        SaveWeedThePlantData();
    }

    private void LoadGameLevel(int levelIndex)
    {
        // Deactivate all levels
        for (int i = 0; i < GameCanvases.Length; i++)
        {
            if (GameCanvases[i] != null)
            {
                GameCanvases[i].gameObject.SetActive(false);
            }
        }

        // Activate the current level
        if (levelIndex >= 0 && levelIndex < GameCanvases.Length && GameCanvases[levelIndex] != null)
        {
            GameCanvases[levelIndex].gameObject.SetActive(true);
        }

    }

    public void SaveWeedThePlantData()
    {
        // Save Asian Monk game data
        SaveGameMechanic.saveSaveGameObject(weedThePlantSavingGame, "WeedThePlantSavingGame", weedThePlantSavingGame.primaryKey);
    }
}
