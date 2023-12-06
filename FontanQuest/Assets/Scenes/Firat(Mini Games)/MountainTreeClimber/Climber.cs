using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{   

    // private Animator animator;
    private Animator animator;
    [SerializeField] int speedVar = 5;
    Vector3 RespawnPosition;
    Vector3 TriggerPosition;
    float zValue = 0.0f;
    float increm = 0.1f;
    float yValue = 0.0f;
    float counter = 0.0f;
    GameObject FirstTile;
    GameObject LastTile;
    GameObject PlayaObject;

    // public TextMeshProUGUI highScoreText; // Reference to the TextMeshPro text component


    // Start is called before the first frame update
    void Start()
    {   

        PlayaObject = GameObject.Find("Playa");
        FirstTile = GameObject.Find("First_Tile");
        LastTile = GameObject.Find("Last_Tile");
        //GET SCREEN SIZE TO MAKE GAME MORE ADAPTIVE AND RESPONSIVE.(This may not be necessary right now, but keep it as a placeholder in case it is needed)
        RespawnPosition = FirstTile.transform.position; //Store the top objects position to respawn all of them
        TriggerPosition = LastTile.transform.position; //Store the last objects position to trigger respawn
        // animator = GetComponent<Animator>();
        counter = 0.0f;
        if (gameObject.name == "Playa"){
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // MovePlayer();

        Climb();
        
        // if screen size has been passed then move the block over the upper limit of the screen where the other block has end: getting the screen size is crucial and all the blocks should be proportional to this size and adapt for different devices as well. 

        // zValue += increm * Time.deltaTime;
        // transform.Translate(new Vector3(0, 0, zValue));
        // counter = Mathf.Abs(transform.position.z - initialPosition.z);
        // Debug.Log(RespawnPosition);
        // Debug.Log(TriggerPosition);
        // Debug.Log(transform.position.z);
    }

   void Climb()
    {   
        if (gameObject.name != "Playa")
        {

        
        yValue = Input.GetAxis("Jump") * Time.deltaTime * speedVar;
        zValue = Input.GetAxis("Jump") * Time.deltaTime * speedVar;
        transform.Translate(0, 0, -zValue);

        if (Vector3.Distance(transform.position, TriggerPosition) < 0.1f && gameObject.name != "Last_Tile")
        {
            transform.position = RespawnPosition;

        }
        else
        {
            LastTile.SetActive(false);

        }
        }
        else{
        if (Input.GetAxis("Jump") > 0.1f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        }
    }

    // void UpdateHighScoreText()
    // {
    //     // Update the high score text component with the counter value
    //     if (highScoreText != null)
    //     {
    //         highScoreText.text = "High Score: " + counter.ToString("F1"); // Display counter value as text
    //     }
    // }

}
