using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignObjects : MonoBehaviour
{
    public float maxDetectionDistance = 25f; // Maximum distance to detect objects
    public string rockTag = "Rock_Positions"; // Tag for the objects to align

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, maxDetectionDistance);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag(rockTag))
            {
                AlignXPosition(col.transform);
            }
        }
    }

    void AlignXPosition(Transform objectToAlign)
    {
        // Check if the object is ahead (has a higher Z value) of the middle object
        if (objectToAlign.position.z > transform.position.z)
        {
            // Align X position of the object with the middle object's X position
            objectToAlign.position = new Vector3(transform.position.x + 3.0f, objectToAlign.position.y, objectToAlign.position.z);
        }
    }
}


