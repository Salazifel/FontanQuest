using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleMainUI : MonoBehaviour
{
    // The distance from the camera to the target point
    private float distanceToTarget = 50.0f;
    // The angle to rotate by
    private float angle = -45.0f;
    public void RotateCamera()
    {
        // Find the camera by name
        GameObject gameCameraObj = GameObject.Find("GameCamera");

        // Check if the camera is found
        if (gameCameraObj != null)
        {
            // Determine the target point the camera is looking at
            Vector3 targetPoint = gameCameraObj.transform.position + gameCameraObj.transform.forward * distanceToTarget;

            // Calculate the rotation around the target point
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);

            // Calculate the vector from the target to the camera
            Vector3 vectorToCamera = gameCameraObj.transform.position - targetPoint;

            // Rotate that vector
            Vector3 rotatedVector = rotation * vectorToCamera;

            // Set the camera's new position
            gameCameraObj.transform.position = targetPoint + rotatedVector;

            // Keep the camera oriented towards the target point.
            gameCameraObj.transform.LookAt(targetPoint);
        }
        else
        {
            Debug.LogError("GameCamera not found");
        }
    }
}
