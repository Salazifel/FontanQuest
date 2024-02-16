using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PetRunner : MonoBehaviour
{
    public Pet_UI_Management_GameSet gameSet;
    // private Animator animator;
    public float speedVar = 10.0f;
    private Vector3 RespawnPosition;
    private Vector3 InitialPosition;
    private Vector3 TriggerPosition;
    float zValue = 0.0f;
    public float tiltSpeed = 1.0f;
    float xValue = 0.0f;
    public float Max_xValue = 12.0f;
    
    [SerializeField] TextMeshProUGUI scoreText;
    // float Min_xValue = -2.1f;
    GameObject FirstTile;
    GameObject LastTile;
    GameObject PetObject;

    private float score = 0.0f;

    void Start()
    {   
        gameSet = GameObject.Find("Script Controller").GetComponent <Pet_UI_Management_GameSet>();
        score = 0.0f;
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

        if (Mathf.Round(score) % 10 == 0 && Mathf.Round(score) != 0)
        {
            // Increase speedVar by 10% of the initial value
            speedVar += speedVar * 0.01f ;
            Debug.Log(speedVar);
            Debug.Log(zValue);
            tiltSpeed += tiltSpeed * 0.01f;
            Debug.Log("Speed increased to: " + speedVar);
        }
            Run();
            UpdateScore();



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
    //     if (gameObject.name == "Pet")
    // {
    //     float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speedVar;

    //     // Check if the PetObject's X position exceeds Max_xValue or -Max_xValue
    //     if (Mathf.Abs(PetObject.transform.position.x) > Max_xValue)
    //     {
    //         // Stop the movement if it exceeds the limit
    //         if ((PetObject.transform.position.x > 0 && Input.GetAxis("Horizontal") < 0) ||
    //             (PetObject.transform.position.x < 0 && Input.GetAxis("Horizontal") > 0))
    //         {
    //             // Allow movement in the opposite direction if input changes
    //             transform.Translate(xValue, 0, 0);
    //         }
    //         else
    //         {
    //             // Stop movement if within limit and input direction is the same
    //             xValue = 0f;
    //         }
    //     }
    //     else
    //     {
    //         // Move normally within the limits
    //         transform.Translate(xValue, 0, 0);
    //     }
    // }
    else
    {
        // Use accelerometer for tilt input
        float xTilt = Input.acceleration.x;
        float xValue = xTilt * tiltSpeed * Time.deltaTime;

        // Check if the PetObject's X position exceeds Max_xValue or -Max_xValue
        if (Mathf.Abs(PetObject.transform.position.x) > Max_xValue)
        {
            // Stop the movement if it exceeds the limit
            if ((PetObject.transform.position.x > 0 && xTilt < 0) ||
                (PetObject.transform.position.x < 0 && xTilt > 0))
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

        void UpdateScore()
    {
        score += Time.deltaTime; // Increment the score steadily
        scoreText.text = "Score: " + Mathf.Round(score).ToString(); // Update the score display on the canvas
        if(gameSet.petSystem.score_running < score){
            gameSet.petSystem.score_running = score;
            gameSet.savePetSystem();
        }

    }
}

