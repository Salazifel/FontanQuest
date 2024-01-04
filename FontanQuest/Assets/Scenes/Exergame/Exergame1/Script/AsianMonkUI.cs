using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsianMonkUI : MonoBehaviour
{
    public Canvas StoryCanvas;
    public Canvas StartMenuCanvas;
    public Canvas GameCanvas;
    public Canvas FinishCanvas;
    SaveGameObjects.AsianMonkSavingGame asianMonkSavingGame;

    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        StartMenuCanvas.gameObject.SetActive(false);
        GameCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

        // Load Asian Monk game data
        asianMonkSavingGame = (SaveGameObjects.AsianMonkSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey("AsianMonkSavingGame", 1);

        if (asianMonkSavingGame == null)
        {
            // If no saved data is found, create a new instance
            asianMonkSavingGame = (SaveGameObjects.AsianMonkSavingGame) SaveGameObjects.CreateSaveGameObject("AsianMonkSavingGame");
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
