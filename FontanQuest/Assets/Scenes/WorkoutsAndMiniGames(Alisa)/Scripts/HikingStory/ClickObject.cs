using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
    public GameObject fab;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = mainCamera.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("here");
                Instantiate(fab, hit.transform);
                    //hit.transform
                if (hit.collider.gameObject.name.Equals("tree-spruce"))
                {
                    
                    Debug.Log("hit");
                }
            }
        }
        
    }
}
