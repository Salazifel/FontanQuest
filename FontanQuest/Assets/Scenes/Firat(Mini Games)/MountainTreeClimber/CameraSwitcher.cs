using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera; // Reference to the first camera
    public Camera camera1; // Reference to the second camera
    public Camera camera2; // Reference to the second camera
    public Camera camera3; // Reference to the second camera


    void Start()
    {
        // Ensure that the cameras are initially in the desired state
        camera.enabled = true;  // Enable the first camera
        camera1.enabled = false; // Disable the second camera
        camera2.enabled = false; // Disable the second camera
        camera3.enabled = false; // Disable the second camera
    
    }


    public void SwitchCameras()
    {
        // Toggle the enabled state of the cameras
        camera.enabled = !camera.enabled;
        camera1.enabled = !camera1.enabled;
    }
}
