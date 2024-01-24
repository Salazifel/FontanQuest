using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{      

    GameObject gameMenuObject;
    // public ToggleObject toggleObject; // Reference to the ToggleObject script
    bool buttonClicked = false; // Flag to track button click
    Vector3 initialPosition;
    private Animator animator;
    void Start()
    {   
        gameMenuObject = GameObject.FindGameObjectWithTag("Game_Menus");
        initialPosition = transform.position; // Store the initial position
        animator = GetComponent<Animator>();
        // toggleObject = GetComponent<ToggleObject>(); // Get reference to the ToggleObject script
            if (gameMenuObject != null)
        {
            gameMenuObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other) 
    {   
        if (other.gameObject.name == "carrot (1)")
        {   
            Time.timeScale = 0.0f; // Freeze time

            Debug.Log("You win!");
            ShowGameMenu(); // Show the game menu on collision
            WaitForButtonClick(); // Wait for button click
            // ExitGame();
        }
        else
        {
        Time.timeScale = 0.2f;
        Debug.Log("Bumped");
        animator.SetTrigger("Collision");
        Invoke("DelayedAction", 1.0f);
        Time.timeScale = 1.0f;
        }




    }
        void DelayedAction()
    {   
        animator.SetTrigger("Reset");
        transform.position = initialPosition;

    //     // constantMoveScript.increm = 0.01f; // Reset the value to its initial state

    }
public void ExitGame()
{
    // Get the current scene's name
    string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

    // Extract the number from the scene name
    int sceneNumber = ExtractSceneNumber(currentSceneName);

    // Increment the scene number
    sceneNumber++;

    // Create the new scene name with the incremented number
    string nextSceneName = $"ObstacleRunning_{sceneNumber}";

    // Check if the scene exists before loading it
    if (SceneExists(nextSceneName))
    {   

        // Load the next scene by name
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        Time.timeScale = 1.0f;// Unfreeze the scene set speed back to normal        
    }
    else
    {
        // TODO: Handle the case where the next scene doesn't exist
        Debug.LogError("Next scene does not exist!");
    }
}

// Function to check if a scene exists by name
bool SceneExists(string sceneName)
{
    for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
    {
        string scenePath = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
        string name = System.IO.Path.GetFileNameWithoutExtension(scenePath);

        if (name.Equals(sceneName))
        {
            return true;
        }
    }
    return false;
}
// Function to extract the number from the scene name
int ExtractSceneNumber(string sceneName)
{
    int number = 0;
    string[] splitName = sceneName.Split('_');

    if (splitName.Length > 1 && int.TryParse(splitName[splitName.Length - 1], out number))
    {
        return number;
    }

    return 0; // Default value if the number extraction fails
}
void ShowGameMenu()
{
    if (gameMenuObject != null)
    {
        gameMenuObject.SetActive(true); // Show the game menu
    }
}

void WaitForButtonClick()
{
    StartCoroutine(WaitForInputOrTime());
}

IEnumerator WaitForInputOrTime()
{
    float timer = 0f;
    const float maxTime = 3.0f; // Maximum time to wait before exiting

    while (!buttonClicked && timer < maxTime)
    {
        if (Input.GetButtonDown("Jump")) // Check if the jump input is received
        {
            ExitGame(); // Exit the game if jump input is received
            yield break; // Exit the coroutine
        }

        timer += Time.deltaTime;
        yield return null;
    }

}


}
