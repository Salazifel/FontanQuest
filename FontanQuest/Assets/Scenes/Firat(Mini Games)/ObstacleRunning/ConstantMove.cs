using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    [SerializeField] float speedVar = 0.3f;
    public float xValue = 0;
    public float increm = 1.05f;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position; // Store the initial position
    }

    void Update()
    {
        xValue += -increm * speedVar * Time.deltaTime;
        transform.Translate(new Vector3(xValue, 0, 0));

        if (Mathf.Abs(transform.position.x - initialPosition.x) >= 80.0f) // Change the threshold as needed
        {
            if (initialPosition.x >= -2.0f) 
            {
                initialPosition.x = -25.0f;
            }
            // Reset the object to its initial position
            initialPosition.x = -30.0f + initialPosition.x;
            transform.position = initialPosition;
            xValue = xValue * 0.30f;
            initialPosition.x = +30.0f + initialPosition.x;
        }

        // if (Physics.Raycast(transform.position, Vector3.right * increm, 1.0f))
        // {
        //     increm = -increm;
        //     GetComponent<MeshRenderer>().material.color = Color.red;
        // }
    }
}
