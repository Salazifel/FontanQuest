using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessBoxingUI : MonoBehaviour
{

    public Canvas StoryCanvas;
    public Canvas GameCanvas;
    public Canvas FinishCanvas;
    SaveGameObjects.FitnessBoxingSavingGame fitnessBoxingSavingGame;

    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

        fitnessBoxingSavingGame = (SaveGameObjects.FitnessBoxingSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey(
            new SaveGameObjects.FitnessBoxingSavingGame(0), "FitnessBoxingSavingGame", 1);

        if (fitnessBoxingSavingGame == null)
        {
            // If no saved data is found, create a new instance
            fitnessBoxingSavingGame = new SaveGameObjects.FitnessBoxingSavingGame(0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToGame()
    {
        StoryCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(true);
        FinishCanvas.gameObject.SetActive(false);
    }

    public void ChangeToComplete()
    {
        StoryCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(true);
    }

    public void SaveFitnessBoxingData()
    {
        // Save Asian Monk game data
        SaveGameMechanic.saveSaveGameObject(fitnessBoxingSavingGame, "AsianMonkSavingGame", fitnessBoxingSavingGame.primaryKey);
    }
}
