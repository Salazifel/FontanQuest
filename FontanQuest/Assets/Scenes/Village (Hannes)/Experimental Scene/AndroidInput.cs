using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidInput : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 startPos;

    public float minZoom = 5.0f;
    public float maxZoom = 20.0f;
    public float zoomSpeed = -10.0f;

    void Update()
    {
        // Swiping the landscape around
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startPos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 touchDelta = Input.GetTouch(0).deltaPosition;

            transform.position = new Vector3(transform.position.x + touchDelta.x * speed * Time.deltaTime,
                                             transform.position.y,
                                             transform.position.z + touchDelta.y * speed * Time.deltaTime);
        }
        /*
        // zooming in and out

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;

            transform.position += transform.forward * deltaMagDiff * zoomSpeed * Time.deltaTime;

            // Clamp the zoom level
            float distance = transform.position.magnitude;
            distance = Mathf.Clamp(distance, minZoom, maxZoom);
            transform.position = transform.forward * - distance;
        }
        */

        // check user clicking on something

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Building"))
                    {
                        Debug.Log("You clicked on a building!");
                        // Do something with the building
                        //Building building = hit.collider.gameObject.GetComponent<Building>();
                        //building.Interact();
                    }
                }
            }
    }
}
