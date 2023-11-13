using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public float speedVar = 0.3f;
    public float xValue = 0;
    public float increm = 1.05f;

    public float distance = 200.0f;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // Store the initial global position
    }

    void Update()
    {
        xValue += increm * speedVar * Time.deltaTime;
        transform.position += new Vector3(xValue, 0, 0);  // Use position directly

        float distanceToPlayerZ = 0;  // Declare the variable outside the block
        float distanceToPlayerX = 0;   // Declare the variable outside the block
        GameObject playerHare = GameObject.Find("Player_Hare");
        if (playerHare != null)
        {   
            distanceToPlayerX = Mathf.Abs(transform.position.x - playerHare.transform.position.x);
            // Debug.Log(distanceToPlayerZ);
            distanceToPlayerZ = Mathf.Abs(transform.position.z - playerHare.transform.position.z);
            // Debug.Log(distanceToPlayerZ);

            if (distanceToPlayerZ <= 1.0f && distanceToPlayerX >= 80.0f)
            {
                xValue = 0;
                // Stop the object's movement
                enabled = false;
            }
            else
            {
                if (Mathf.Abs(transform.position.x - initialPosition.x) >= distance)
                {
                    // Reset the object to its initial position if it's not stopped
                    ResetObject();
                }
            }
        }
    }

    // Add a method to reset the object
    public void ResetObject()
    {
        // Reset the object to its initial position
        initialPosition.x = -100.0f + initialPosition.x;
        transform.position = initialPosition;
        xValue = xValue/2;
        enabled = true; // Enable the script to resume movement
        initialPosition.x = +100.0f + initialPosition.x;
    }
}
