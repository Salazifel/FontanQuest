using UnityEngine;

public class InteractiveButtons : MonoBehaviour
{
    private Camera cameraToTrack; // Set this to your GameCamera in the inspector

    void Awake()
    {
        cameraToTrack = GameObject.Find("GameCamera").GetComponent<Camera>();

        if (cameraToTrack == null)
        {
            Debug.LogError("Camera to track was not found!");
        }
    }
    void Update()
    {
        if (cameraToTrack != null)
        {
            // Calculate the direction from the plane to the camera
            Vector3 directionToCamera = cameraToTrack.transform.position - transform.position;

            // Set the directionToCamera to have a flat y component to avoid tilting the plane up or down
            directionToCamera.y = 0;

            // Create a rotation that looks in the directionToCamera with the up vector set to world up
            Quaternion lookRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);

            // Apply the rotation to the plane with a fixed x-axis rotation of 60 degrees
            transform.rotation = Quaternion.Euler(60, lookRotation.eulerAngles.y, 0);

        }
        else
        {
            Debug.LogError("CameraToTrack is not set or found");
        }

        // Check if there is at least one touch happening
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch just began
            if (touch.phase == TouchPhase.Began)
            {
                // Convert the touch position to a ray from the camera
                Ray ray = cameraToTrack.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Perform the raycast
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the raycast hit this plane
                    if (hit.transform == transform)
                    {
                        hit.transform.gameObject.SendMessage("OpenBuildWindow", null, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }
}