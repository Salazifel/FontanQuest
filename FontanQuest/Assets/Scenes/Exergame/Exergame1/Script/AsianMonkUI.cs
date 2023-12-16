using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsianMonkUI : MonoBehaviour
{
    public Canvas StoryCanvas;
    public Canvas StartMenuCanvas;
    public Canvas GameCanvas;
    public Canvas FinishCanvas;
    public SaveGameObjects.AsianMonkSavingGame asianMonkSavingGame { get; private set; }



    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        StartMenuCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);


        // Load Asian Monk game data
        asianMonkSavingGame = (SaveGameObjects.AsianMonkSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey(
            new SaveGameObjects.AsianMonkSavingGame(0, 3000f), "AsianMonkSavingGame", 1);

        if (asianMonkSavingGame == null)
        {
            // If no saved data is found, create a new instance
            asianMonkSavingGame = new SaveGameObjects.AsianMonkSavingGame(0, 3000f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToMenu()
    {
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(true);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

    }

    public void ChangeToGame()
    {
        // Increase level and adjust speed
        asianMonkSavingGame.currentLevel++;
        asianMonkSavingGame.obstacleSpeed += 20.0f; // Adjust this value based on your preference

        // Save Asian Monk game data
        SaveGameMechanic.saveSaveGameObject(asianMonkSavingGame, "AsianMonkSavingGame", asianMonkSavingGame.primaryKey);

        // Do not create a new instance here
        // asianMonkSavingGame = new SaveGameObjects.AsianMonkSavingGame(asianMonkSavingGame.currentLevel, asianMonkSavingGame.obstacleSpeed);

        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(true);
        FinishCanvas.gameObject.SetActive(false);
    }



    public void ChangeToComplete()
    {
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(true);
    }

    public void SaveAsianMonkData()
    {
        // Save Asian Monk game data
        SaveGameMechanic.saveSaveGameObject(asianMonkSavingGame, "AsianMonkSavingGame", asianMonkSavingGame.primaryKey);
    }

}
