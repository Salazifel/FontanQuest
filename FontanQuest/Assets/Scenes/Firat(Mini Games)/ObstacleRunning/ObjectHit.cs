using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{   
    Vector3 initialPosition;
    private Animator animator;
    void Start()
    {
        initialPosition = transform.position; // Store the initial position
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision other) 
    {   
        if (other.gameObject.name == "carrot (1)")
        {
            Debug.Log("You win!");
            ExitGame();
        }
        else
        {
        Debug.Log("Bumped");
        animator.SetTrigger("Collision");
        Invoke("DelayedAction", 2.0f);
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
        // // Unload the current scene asynchronously
        // SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        // Load the next scene by its name or index
        Application.LoadLevel("ObstacleRunning_2");
    }

}
