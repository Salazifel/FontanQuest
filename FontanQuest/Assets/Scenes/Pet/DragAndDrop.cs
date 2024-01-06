using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    public float minY = 0f; // Define minimum Y position
    public float maxY = 3f; // Define maximum Y position
    public float minZ = -20f; // Define minimum Z position
    public float maxZ = 20f; // Define maximum Z position
    private float zPosition;

    private void Start(){
        zPosition = gameObject.transform.position.z;
    }
    private void OnMouseDown()
    {   
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = GetMouseWorldPosition() + offset;
        newPosition.z = zPosition; // Maintain the Z position
        // Clamp the Y and Z positions within specified bounds
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10; // Distance of the GameObject from the camera
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
