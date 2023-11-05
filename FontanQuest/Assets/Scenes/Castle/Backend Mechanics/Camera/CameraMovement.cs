using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 lastPosition;
    public float panSpeed = 60.0f;

    // Define your scene boundaries
    public Vector3 minBoundary = new Vector3(-50f, 0f, -50f);
    public Vector3 maxBoundary = new Vector3(50f, 0f, 50f);

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
        // Check for touch on mobile devices
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            MoveCamera(touchDeltaPosition);
        }

        // Check for mouse click and drag on desktop
        else if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastPosition;
            MoveCamera(new Vector2(delta.x, delta.y));
            lastPosition = Input.mousePosition;
        }
    }

    void MoveCamera(Vector2 deltaPosition)
    {
        // Taking the rotation of the camera into account to make the movement feel intuitive
        Vector3 moveDirection = new Vector3(
            deltaPosition.x * transform.right.z,
            0,
            deltaPosition.x * transform.right.x
        ) + new Vector3(
            -deltaPosition.y * transform.forward.z,
            0,
            -deltaPosition.y * transform.forward.x
        );

        // Calculate the new prospective position
        Vector3 newCameraPosition = transform.position + moveDirection * panSpeed * Time.deltaTime;

        // Check if the new position is within bounds
        if (IsWithinBounds(newCameraPosition))
        {
            transform.Translate(moveDirection * panSpeed * Time.deltaTime, Space.World);
        }
    }

    bool IsWithinBounds(Vector3 position)
    {
        return position.x >= minBoundary.x && position.x <= maxBoundary.x &&
               position.z >= minBoundary.z && position.z <= maxBoundary.z;
    }
}
