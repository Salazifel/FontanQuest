using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindObjectToTouch1 : MonoBehaviour
{
    private Camera mainCamera;
    public TextMeshProUGUI TextMesh;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //get touch
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) // check if touch did just began
            {
                //do raycast
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hittedObject = hit.collider.gameObject;
                    if (hittedObject != null)
                    {
                        Stone stone = hittedObject.GetComponent<Stone>();
                        if (stone != null)
                        {
                            TextMesh.text = stone.TextToStone();
                        }
                        Mushroom mushroom = hittedObject.GetComponent<Mushroom>();
                        if (mushroom != null)
                        {
                            TextMesh.text = mushroom.TextToMushroomKind();
                        }
                    }
                }
            }
        }
    }
}
