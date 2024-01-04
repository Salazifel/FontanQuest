using UnityEngine;

public class AsianMonkUI : MonoBehaviour
{
    public Canvas StoryCanvas;
    public Canvas StartMenuCanvas;
    public Canvas FinishCanvas;
    public Canvas[] GameCanvases;

    private SaveGameObjects.AsianMonkSavingGame asianMonkSavingGame;
    private int currentLevelIndex = 0; 

    // Start is called before the first frame update
    void Start()
    {
        StoryCanvas.gameObject.SetActive(true);
        StartMenuCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

        // Load or create Asian Monk game data
        asianMonkSavingGame = (SaveGameObjects.AsianMonkSavingGame)SaveGameMechanic.getSaveGameObjectByPrimaryKey(
            new SaveGameObjects.AsianMonkSavingGame(0), "AsianMonkSavingGame", 1);

        if (asianMonkSavingGame == null)
        {
            // If no saved data is found, create a new instance
            asianMonkSavingGame = new SaveGameObjects.AsianMonkSavingGame(0);
        }

        // Instantiate the initial game level
        LoadGameLevel(asianMonkSavingGame.currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToMenu()
    {
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(true);
        FinishCanvas.gameObject.SetActive(false);
        LoadGameLevel(asianMonkSavingGame.currentLevel); // Reload the current level when going back to the menu
    }

    public void ChangeToGame()
    {
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(false);

        // Load the next level (currentLevelIndex) without incrementing the level
        LoadGameLevel(currentLevelIndex);

        if (currentLevelIndex > 0)
        {
            asianMonkSavingGame.currentLevel++;
        }

        currentLevelIndex++;

        if (currentLevelIndex >= GameCanvases.Length)
        {
            currentLevelIndex = 0; // Reset to the first level if there are no more levels
            Debug.LogWarning("No more levels available. Resetting to the first level.");
        }
    }




    public void ChangeToComplete()
    {
        StoryCanvas.gameObject.SetActive(false);
        StartMenuCanvas.gameObject.SetActive(false);
        FinishCanvas.gameObject.SetActive(true);
        SaveAsianMonkData(); // Save the game data when completing a level

        // Make sure to load the current level AFTER displaying the FinishCanvas
        LoadGameLevel(asianMonkSavingGame.currentLevel);
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
            Debug.Log("Loaded GameCanvas: " + GameCanvases[levelIndex].name);
        }

    }

    public void SaveAsianMonkData()
    {
        // Save Asian Monk game data
        SaveGameMechanic.saveSaveGameObject(asianMonkSavingGame, "AsianMonkSavingGame", asianMonkSavingGame.primaryKey);
    }
}
