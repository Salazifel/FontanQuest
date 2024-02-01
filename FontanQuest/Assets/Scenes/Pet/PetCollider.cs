using UnityEngine;
using UnityEngine.SceneManagement; // Add this line for scene management

public class PetCollider : MonoBehaviour
{
    // Called when the collider enters another collider with physical impact
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Pet collided with an obstacle!");

        // Stop the game
        Time.timeScale = 0f;

        // You can add additional code here if needed, such as displaying a game over screen.
        Debug.Log("Invoking RestartGame");
        // Restart the game after a delay (e.g., 3 seconds)
        RestartGame();
    }

    // Function to restart the game
    private void RestartGame()
    {   
        Debug.Log("Restarting");
        // Reset the time scale
        Time.timeScale = 1f;

        
        // Reload the current scene (you may need to adjust the scene name or index)
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}

