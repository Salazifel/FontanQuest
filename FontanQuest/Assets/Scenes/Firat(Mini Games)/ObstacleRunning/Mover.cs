using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Mover : MonoBehaviour
{   
    private Animator animator;

    [SerializeField] int speedVar = 5;
    Vector3 initialPosition;
    float zValue = 0.0f;
    float increm = 0.1f;
    float yValue;
    float counter = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position; // Store the initial position
        animator = GetComponent<Animator>();
        PrintInstructions();
        counter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {   
        // MovePlayer();

        Jump();
        // zValue += increm * Time.deltaTime;
        // transform.Translate(new Vector3(0, 0, zValue));
        counter = Mathf.Abs(transform.position.z - initialPosition.z);
        Debug.Log(counter);
    }

    void PrintInstructions()
    {
        Debug.Log("Follow the rabbit!");
        Debug.Log("Move your player with pressing space");
        Debug.Log("Try to avoid crashing to passing animals");
    }

    // void MovePlayer()
    // {
    //     float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speedVar;
    //     float zValue = Input.GetAxis("Vertical") * Time.deltaTime * speedVar;
    //     transform.Translate(xValue, 0, zValue);
    // }

    void Jump()
    {
        yValue = Input.GetAxis("Jump") * Time.deltaTime * speedVar;
        zValue = Input.GetAxis("Jump") * Time.deltaTime * speedVar;
        transform.Translate(0, 0, zValue);

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
