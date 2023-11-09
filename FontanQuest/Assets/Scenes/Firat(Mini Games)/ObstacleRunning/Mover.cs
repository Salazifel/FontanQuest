using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{   
    [SerializeField] int speedVar = 5;
    Vector3 initialPosition;
    float zValue = 0.0f;
    float increm = 0.1f;
    float yValue;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; // Store the initial position
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {   
        // MovePlayer();
        Jump();
        // zValue += increm * Time.deltaTime;
        // transform.Translate(new Vector3(0, 0, zValue));
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the hell!");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't touch the walls or any other shape");
    }

    // void MovePlayer()
    // {
    //     float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speedVar;
    //     float zValue = Input.GetAxis("Vertical") * Time.deltaTime * speedVar;
    //     transform.Translate(xValue, 0, zValue);
    // }

    void Jump()
    {
        float yValue = Input.GetAxis("Jump") * Time.deltaTime * speedVar;
        float zValue = Input.GetAxis("Jump") * Time.deltaTime * speedVar;
        transform.Translate(0, 0, zValue);

        if (yValue != 0) // Check if the "Jump" input is pressed
        {
            // Reset to the initial position after a delay (e.g., 1 second)
            yValue = 0;
        }
    }

}
