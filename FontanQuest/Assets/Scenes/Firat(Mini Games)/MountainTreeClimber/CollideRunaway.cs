using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro.Examples;


public class CollideRunaway : MonoBehaviour
{   
    GameObject parentObject;
    [SerializeField] int speedVar = 5;
    private float fixedDeltaTime;
    private Animator animator;
    private bool inputReceived = false;

    public float xValueAut;
    public float yValueAut;

    void Start()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
        animator = GetComponent<Animator>();
        parentObject = GameObject.FindGameObjectWithTag("ParentPlaya");
    }

    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.tag == "Animals")
        // {
            Time.timeScale = 0.2f;
            Debug.Log("DANGER!!!");

            StartCoroutine(InputTimer());
        // }
    }

    IEnumerator InputTimer()
    {
        float timer = 0f;
        float maxTime = 2f; // Adjust the time frame here (in seconds)

        while (timer < maxTime)
        {
            if (Input.GetAxis("Vertical") > 0.1f)
            {
                inputReceived = true;
                break; // Exit the loop if input is received
            }

            timer += Time.deltaTime;
            yield return null;
        }

        if (!inputReceived)
        {
            Debug.Log("No input received within the time frame");
            Debug.Log("Died!");
            Time.timeScale = 0.0f; // Reset the time scale back to normal
        }
        else
        {
            Debug.Log("Input received! Game continues...");
            float direction = (parentObject.transform.position.x < 0) ? 1f : -1f;
            StartCoroutine(SlideObject(direction));
            Debug.Log(direction);
        }
    }

    IEnumerator SlideObject(float direction)
    {
        float slideDistance = 3f; // Adjust the distance to slide here
        float slideSpeed = 1f; // Adjust the speed of sliding
        float targetX = parentObject.transform.position.x + (slideDistance * direction);
        float startTime = Time.time;


        while (Time.time < startTime + slideSpeed)
        {
            float t = (Time.time - startTime) / slideSpeed;
            float newX = Mathf.Lerp(transform.position.x, targetX, t);
            Debug.Log(newX);
            parentObject.transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            yield return null;
        }

        Time.timeScale = 1.0f; // Reset the time scale back to normal
    }
}