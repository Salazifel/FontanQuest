using UnityEngine;

public class AsianMonkUI : MonoBehaviour
{
    public Canvas StoryCanvas;
    public Canvas StartMenuCanvas;
    public Canvas FinishCanvas;
    public Canvas[] GameCanvases;  // Array of GameCanvas objects for different levels
    SaveGameObjects.AsianMonkSavingGame asianMonkSavingGame;

    private int currentLevel = 0;  // Default starting level

    // Start is called before the first frame update
    void Start()
    {
        LoadLevelData(currentLevel);
        SwitchCanvas(currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        // Update logic if needed
    }

    public void ChangeToMenu()
    {
        Debug.Log("Changing to Menu");
        SaveAsianMonkData();
        LoadLevelData(currentLevel);  // Reload data when returning to the menu
        SwitchCanvas(currentLevel);
    }

    public void ChangeToGame()
    {
        SwitchCanvas(currentLevel);
    }

    public void ChangeToComplete()
    {
        currentLevel++;
        SaveAsianMonkData();
        LoadLevelData(currentLevel);
        SwitchCanvas(currentLevel);
    }

    private void SwitchCanvas(int level)
    {
        // Disable StoryCanvas, StartMenuCanvas, GameCanvases, and FinishCanvas
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(false);
        foreach (Canvas gameCanvas in GameCanvases)
        {
            gameCanvas.gameObject.SetActive(false);
        }
        FinishCanvas.gameObject.SetActive(false);

        // Enable the Canvas objects for the current level
        if (level == 0)
        {
            StoryCanvas.gameObject.SetActive(true);
        }
        else if (level % 2 == 1)
        {
            StartMenuCanvas.gameObject.SetActive(true);
        }
        else if (level <= GameCanvases.Length * 2)
        {
            int gameCanvasIndex = (level - 2) / 2;
            GameCanvases[gameCanvasIndex].gameObject.SetActive(true);
        }
        else
        {
            FinishCanvas.gameObject.SetActive(true);
        }
    }

    private void LoadLevelData(int level)
    {
        if (level == 0)
        {
            // For level 0, create a default instance with primary key 0
            asianMonkSavingGame = new SaveGameObjects.AsianMonkSavingGame(0);
        }
        else
        {
            // Load Asian Monk game data for the specified level
            asianMonkSavingGame = (SaveGameObjects.AsianMonkSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey(
                new SaveGameObjects.AsianMonkSavingGame(0), "AsianMonkSavingGame", level);

            if (asianMonkSavingGame == null)
            {
                // If no saved data is found, create a new instance for the current level
                asianMonkSavingGame = new SaveGameObjects.AsianMonkSavingGame(0);
                asianMonkSavingGame.currentLevel = level;

                // Save the newly created object with the primary key 0
                SaveAsianMonkData();
            }
        }

        // Additional setup or initialization based on the loaded data can be done here
    }

    public void SaveAsianMonkData()
    {
        // Save Asian Monk game data
        SaveGameMechanic.saveSaveGameObject(asianMonkSavingGame, "AsianMonkSavingGame", asianMonkSavingGame.primaryKey);
    }

}
