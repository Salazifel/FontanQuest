using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject hayObject;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a tag "Finish"
        if (collision.gameObject.CompareTag("Finish"))
        {   
            
            // Deactivate the collided object
            if (!hayObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
            else{
                Debug.Log("There is already hay on the feeder!");
            }
                

            // Activate the "hay" object
            if (hayObject != null)
            {
                hayObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Hay object reference not set!");
            }


        }
    }
}
  