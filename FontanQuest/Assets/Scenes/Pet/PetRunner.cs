using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetRunner : MonoBehaviour
{
   
    // private Animator animator;
    public float speedVar = 5.0f;
    private Vector3 RespawnPosition;
    private Vector3 InitialPosition;
    private Vector3 TriggerPosition;
    float zValue = 0.0f;

    float xValue = 0.0f;
    public float Max_xValue = 10.0f;
    
    float Min_xValue = -2.1f;
    GameObject FirstTile;
    GameObject LastTile;
    GameObject PetObject;

    void Start()
    {   
        PetObject = GameObject.Find("Pet");
        FirstTile = GameObject.Find("First_Tile");
        if (FirstTile == null){
            Debug.Log("First tile couldn't find");
        }
        LastTile = GameObject.Find("Last_Tile");
        if (LastTile == null){
            Debug.Log("Last tile couldn't find");
        }
        InitialPosition = transform.position;
        RespawnPosition = FirstTile.transform.position;
        TriggerPosition = LastTile.transform.position;

        zValue = 0.0f;
    }

    void Update()
    {

            Run();




    }

    void Run()
    {   
        if (gameObject.name != "Pet")
        {
            zValue =+ 1.0f * Time.deltaTime * speedVar;
            if(gameObject.name == "Last_Tile"){
                gameObject.SetActive(false);
            }
            transform.Translate(xValue, 0, -zValue); // Move at a constant speed
            // if (gameObject.tag == "Obstacles")
            // {
            //     if (Mathf.Abs(transform.position.z - TriggerPosition.z) < 0.1f){
            //         transform.position = RespawnPosition;
            //     }
            // }
            if  (gameObject.tag =="Tiles"){
                if ((transform.position.z - TriggerPosition.z) < 0.1f && gameObject.name != "Last_Tile")
            {
                transform.position = RespawnPosition;
            }
            }
        }
        if (gameObject.name == "Pet")
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speedVar;

        // Check if the PetObject's X position exceeds Max_xValue or -Max_xValue
        if (Mathf.Abs(PetObject.transform.position.x) > Max_xValue)
        {
            // Stop the movement if it exceeds the limit
            if ((PetObject.transform.position.x > 0 && Input.GetAxis("Horizontal") < 0) ||
                (PetObject.transform.position.x < 0 && Input.GetAxis("Horizontal") > 0))
            {
                // Allow movement in the opposite direction if input changes
                transform.Translate(xValue, 0, 0);
            }
            else
            {
                // Stop movement if within limit and input direction is the same
                xValue = 0f;
            }
        }
        else
        {
            // Move normally within the limits
            transform.Translate(xValue, 0, 0);
        }
    }

    }
}

