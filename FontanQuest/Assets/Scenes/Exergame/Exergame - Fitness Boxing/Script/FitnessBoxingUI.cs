using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessBoxingUI : MonoBehaviour
{

    public Canvas StoryCanvas;
    public Canvas[] GameCanvases;
    public Canvas FinishCanvas;
    SaveGameObjects.FitnessBoxingSavingGame fitnessBoxingSavingGame;

    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        SetGameCanvasActive(0); // Show the first level canvas initially
        FinishCanvas.gameObject.SetActive(false);

        fitnessBoxingSavingGame = (SaveGameObjects.FitnessBoxingSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey("FitnessBoxingSavingGame", 1);

        if (fitnessBoxingSavingGame == null)
        {
            // If no saved data is found, create a new instance
            fitnessBoxingSavingGame = (SaveGameObjects.FitnessBoxingSavingGame)SaveGameObjects.CreateSaveGameObject("FitnessBoxingSavingGame");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetGameCanvasActive(int levelIndex)
    {
        // Deactivate all canvases
        foreach (Canvas canvas in GameCanvases)
        {
            canvas.gameObject.SetActive(false);
        }

        // Activate the specified level canvas
        if (levelIndex >= 0 && levelIndex < GameCanvases.Length)
        {
            GameCanvases[levelIndex].gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Invalid level index");
        }
    }

    public void ChangeToGame(int levelIndex)
    {
        StoryCanvas.gameObject.SetActive(false);

        // Check if the specified level index is valid
        if (levelIndex >= 0 && levelIndex < GameCanvases.Length)
        {
            // Activate the specified level canvas
            SetGameCanvasActive(levelIndex);
            FinishCanvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Invalid level index");
        }
    }


    public void ChangeToComplete()
    {
        StoryCanvas.gameObject.SetActive(false);
        SetGameCanvasActive(fitnessBoxingSavingGame.currentLevel);
        FinishCanvas.gameObject.SetActive(true);
    }

    public void CompleteLevel()
    {
        // Logic to handle level completion
        fitnessBoxingSavingGame.currentLevel++;

        // Save the updated data
        SaveGameMechanic.saveSaveGameObject(fitnessBoxingSavingGame, "FitnessBoxingSavingGame", fitnessBoxingSavingGame.primaryKey);
    }

    /*
    public void SaveFitnessBoxingData()
    {
     
        SaveGameMechanic.saveSaveGameObject(fitnessBoxingSavingGame, "AsianMonkSavingGame", fitnessBoxingSavingGame.primaryKey);
    }
    */
}
