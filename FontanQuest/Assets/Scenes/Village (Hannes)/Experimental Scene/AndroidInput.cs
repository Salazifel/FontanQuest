using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AndroidInput : MonoBehaviour
{
    private float speed = 5.0f;

    private float house_speed = 5.0f;
    private Vector3 startPos;
    private GameObject CanvasObject;

    private bool moving_building = false;
    private GameObject prefab_to_be_moved;

    private GameObject building;

    private float minZoom = 5.0f;
    private float maxZoom = 20.0f;
    private float zoomSpeed = -10.0f;

    void Update()
    {
        // Swiping the landscape around
        if (moving_building == false)
        {
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
        }
        else
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 touchDelta = Input.GetTouch(0).deltaPosition;

                prefab_to_be_moved.transform.position = new Vector3(prefab_to_be_moved.transform.position.x - touchDelta.x * house_speed * Time.deltaTime,
                                                prefab_to_be_moved.transform.position.y,
                                                prefab_to_be_moved.transform.position.z - touchDelta.y * house_speed * Time.deltaTime);
            }
            // once the prefab is moved to the edge of the screen, the screen will move with the prefab
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
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    return;
                }
                
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("BuildingFreeZone"))
                    {
                        Debug.Log("You clicked on a building!");
                        building = hit.collider.transform.parent.gameObject;
                        if (building.name.Contains("Constr") == false)
                        {
                            CanvasObject.GetComponent<BuildButton>().assign_selected_building(building); 
                        }            
                    }
                }
            }
    }

    public void change_moving_building_status(bool status, GameObject gO)
    {
        moving_building = status;
        prefab_to_be_moved = gO;
    }

    void Awake()
    {
        CanvasObject = GameObject.Find("Canvas");
    }
}
