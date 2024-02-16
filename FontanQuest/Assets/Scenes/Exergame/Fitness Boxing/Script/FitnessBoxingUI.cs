using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessBoxingUI : MonoBehaviour
{
    public Canvas StoryCanvas;
    public Canvas[] GameCanvases;
    public Canvas FinishCanvas;
    public Canvas FailCanvas;
    SaveGameObjects.FitnessBoxingSavingGame fitnessBoxingSavingGame;
    private double oldStepCount;

    private int currentLevel = 0; // Track the current level

    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);

        // Initially, set all game canvases to inactive
        foreach (Canvas gameCanvas in GameCanvases)
        {
            gameCanvas.gameObject.SetActive(false);
        }
        FailCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

        fitnessBoxingSavingGame = (SaveGameObjects.FitnessBoxingSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey("FitnessBoxingSavingGame", 1);

        if (fitnessBoxingSavingGame == null)
        {
            // If no saved data is found, create a new instance
            fitnessBoxingSavingGame = (SaveGameObjects.FitnessBoxingSavingGame)SaveGameObjects.CreateSaveGameObject("FitnessBoxingSavingGame");
        }
    }

    void SetGameCanvasActive(int level)
    {
        // Deactivate all canvases
        foreach (Canvas canvas in GameCanvases)
        {
            canvas.gameObject.SetActive(false);
        }

        // Activate the specified level canvas
        if (level >= 0 && level < GameCanvases.Length)
        {
            GameCanvases[level].gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Invalid level index");
        }
    }

    public void ChangeToGame()
    {
        // Deactivate all canvases
        foreach (Canvas canvas in GameCanvases)
        {
            canvas.gameObject.SetActive(false);
        }

        if (currentLevel >= 0 && currentLevel < GameCanvases.Length)
        {
            
            // Activate the specified level canvas
            SetGameCanvasActive(currentLevel);

            StoryCanvas.gameObject.SetActive(false);
            FinishCanvas.gameObject.SetActive(false);
            FailCanvas.gameObject.SetActive(false);

            // Increment the current level after setting up the game canvas
            currentLevel++;

            
        }
        else
        {
            Debug.LogError("Invalid level index");
        }
    }

    public void ChangeToComplete()
    {
        StoryCanvas.gameObject.SetActive(false);
        foreach (Canvas gameCanvas in GameCanvases)
        {
            gameCanvas.gameObject.SetActive(false);
        }
        if (oldStepCount != 0)
        {
            if ((SmartWatchData.pastHeartActivity == true) || (SmartWatchData.pastStepActivitiy == true))
            {
                FailCanvas.gameObject.SetActive(false);
                FinishCanvas.gameObject.SetActive(true);
            }
            else
            {
                FailCanvas.gameObject.SetActive(true);
                FinishCanvas.gameObject.SetActive(false);
            }
        }

        oldStepCount = SmartWatchData.steps;
    }

    public void ChangeToStory()
    {
        StoryCanvas.gameObject.SetActive(true);
        foreach (Canvas gameCanvas in GameCanvases)
        {
            gameCanvas.gameObject.SetActive(false);
        }
        FailCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);
    }

    public void CompleteLevel()
    {
        // Logic to handle level completion
        fitnessBoxingSavingGame.currentLevel++;

        // Save the updated data
        SaveGameMechanic.saveSaveGameObject(fitnessBoxingSavingGame, "FitnessBoxingSavingGame", fitnessBoxingSavingGame.primaryKey);
    }
}
