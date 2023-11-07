using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 lastPosition;
    private float panSpeed = 8.0f;
    private float zoomSpeed = 4.0f;

    // Define your scene boundaries
    public Vector3 minBoundary = new Vector3(-50f, 0f, -50f);
    public Vector3 maxBoundary = new Vector3(50f, 0f, 50f);

    private Vector3 startPos;

    void Awake()
    {
        // Set the boundaries using in-scene objects
        GameObject minBoundObj = GameObject.Find("CameraBoundMin");
        GameObject maxBoundObj = GameObject.Find("CameraBoundMax");

        if (minBoundObj && maxBoundObj)
        {
            minBoundary = minBoundObj.transform.position;
            maxBoundary = maxBoundObj.transform.position;
        }
        else
        {
            Debug.LogError("Boundary objects not found!");
        }
    }

    void Update()
    {
        // MOVING THE CAMERA AROUND 
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDelta = Input.GetTouch(0).deltaPosition;

            // Reverse the movement
            touchDelta = -touchDelta;

            // Calculate the new position based on input
            Quaternion yRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
            Vector3 forwardMovement = yRotation * Vector3.forward * touchDelta.y * panSpeed * Time.deltaTime;
            Vector3 rightMovement = yRotation * Vector3.right * touchDelta.x * panSpeed * Time.deltaTime;
            Vector3 newPosition = transform.position + forwardMovement + rightMovement;

            // Clamp the new position to the bounds
            newPosition.x = Mathf.Clamp(newPosition.x, minBoundary.x, maxBoundary.x);
            newPosition.z = Mathf.Clamp(newPosition.z, minBoundary.z, maxBoundary.z);

            // Y position could be clamped as well if needed
            // newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

            // Apply the clamped position to the camera
            transform.position = newPosition;
        }

        // ZOOMING
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (Camera.main.orthographic)
            {
                // ... change the orthographic size based on the change in distance between the touches.
                Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
                // Clamp the orthographic size to ensure it's between the min and max zoom levels.
                Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minBoundary.y, maxBoundary.y);
            }
            else // If the camera uses a perspective view...
            {
                // ... change the position based on the change in distance between the touches.
                Vector3 newPosition = transform.position;
                newPosition.y -= deltaMagnitudeDiff * zoomSpeed * Time.deltaTime;
                newPosition.y = Mathf.Clamp(newPosition.y, minBoundary.y, maxBoundary.y);

                // Clamp the new position to ensure the camera stays within the x and z bounds as well
                newPosition.x = Mathf.Clamp(newPosition.x, minBoundary.x, maxBoundary.x);
                newPosition.z = Mathf.Clamp(newPosition.z, minBoundary.z, maxBoundary.z);

                transform.position = newPosition;
            }
        }
    }
}
