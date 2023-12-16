using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // public float speed = 1000.0f; // Adjust this to control the speed of the obstacle
    SaveGameObjects.AsianMonkSavingGame asianMonkSavingGame;

    void Start()
    {
        // Find the AsianMonkUI script in the scene and get the reference to asianMonkSavingGame
        asianMonkSavingGame = FindObjectOfType<AsianMonkUI>().asianMonkSavingGame;

        // Alternatively, you can assign the reference through inspector if it's already set there.
        // asianMonkSavingGame = GetComponent<AsianMonkUI>().asianMonkSavingGame;

        if (asianMonkSavingGame == null)
        {
            Debug.LogWarning("AsianMonkSavingGame reference not found.");
        }
    }

    void Update()
    {
        if (asianMonkSavingGame != null)
        {
            Vector3 movement = Vector3.back * asianMonkSavingGame.obstacleSpeed * Time.deltaTime * 1.2f;
            transform.Translate(movement);
        }
        else
        {
            Debug.LogWarning("AsianMonkSavingGame is not initialized.");
        }
    }
}
