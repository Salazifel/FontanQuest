using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the speed of the obstacle

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.back * speed * Time.deltaTime;
        transform.Translate(movement);

    }
}

