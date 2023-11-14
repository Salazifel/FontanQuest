using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleMainUI : MonoBehaviour
{
    GameObject UI_Elements;
    GameObject MessageWindow;
    GameObject RotateButton;
    GameObject CharacterDisplayRawImage;

    void Start()
    {
        MessageWindow = GameObject.Find("UI_Elements/MessageWindow");
        RotateButton = GameObject.Find("UI_Elements/RotateButton");
        CharacterDisplayRawImage = GameObject.Find("UI_Elements/CharacterDisplayRawImage");
        UI_Elements = GameObject.Find("UI_Elements");

        DeactivateUIElements();

        RotateButton.SetActive(true);
    }

    void DeactivateUIElements() {
        MessageWindow.SetActive(false);
        RotateButton.SetActive(false);
        CharacterDisplayRawImage.SetActive(false);
    }

    public void DeactivateMessageWindow()
    {
        MessageWindow.SetActive(false);
    }

    public GameObject GetMessageWindow()
    {
        return MessageWindow;
    }





        // ------------------------------ ROTATION OF CAMERA ----------------------------------------
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
