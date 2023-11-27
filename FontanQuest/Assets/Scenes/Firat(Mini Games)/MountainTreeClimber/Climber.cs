using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    // private Animator animator;

    [SerializeField] int speedVar = 5;
    Vector3 initialPosition;
    float zValue = 0.0f;
    float increm = 0.1f;
    float yValue = 0.0f;
    float counter = 0.0f;
    // public TextMeshProUGUI highScoreText; // Reference to the TextMeshPro text component


    // Start is called before the first frame update
    void Start()
    {   
        
        //GET SCREEN SIZE TO MAKE GAME MORE ADAPTIVE AND RESPONSIVE.
        initialPosition = transform.position; // Store the initial position
        // animator = GetComponent<Animator>();
        counter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // MovePlayer();

        Climb();
        
        // if screen size has been passed then move the block over the upper limit of the screen where the other block has end: getting the screen size is crucial and all the blocks should be proportional to this size and adapt for different devices as well. 

        // zValue += increm * Time.deltaTime;
        // transform.Translate(new Vector3(0, 0, zValue));
        counter = Mathf.Abs(transform.position.z - initialPosition.z);
        // Debug.Log(counter);
    }

    void Climb()
    {
        yValue = Input.GetAxis("Jump") * Time.deltaTime * speedVar;
        zValue = Input.GetAxis("Jump") * Time.deltaTime * speedVar;
        transform.Translate(0, 0, -zValue);

        // if (Input.GetAxis("Jump") > 0.1f)
        // {
        //     animator.SetBool("IsMoving", true);
        // }
        // else
        // {
        //     animator.SetBool("IsMoving", false);
        // }
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
