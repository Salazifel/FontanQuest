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
        if (other.gameObject.tag == "Animals")
        {
            Time.timeScale = 0.4f;
            Debug.Log("DANGER!!!");

            StartCoroutine(InputTimer());
        }
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
            Time.timeScale = 0.0f; // Reset the time scale back to normal
            Debug.Log("Gameover");
        }
        else
        {
            Debug.Log("Input received! Game continues...");
            float direction = (parentObject.transform.position.x < 0) ? 1f : -1f;
            StartCoroutine(SlideObject(direction));
        }
    }

IEnumerator SlideObject(float direction)
{
    float slideDistance = 6f; // Adjust the distance to slide here
    float slideSpeed = 0.1f; // Adjust the speed of sliding

    float initialX = parentObject.transform.position.x;
    float targetX = initialX + (slideDistance * direction);

    float startTime = Time.time;
    while (Time.time < startTime + slideSpeed)
    {
        float t = (Time.time - startTime) / slideSpeed;
        float newX = Mathf.Lerp(initialX, targetX, t);
        parentObject.transform.position = new Vector3(newX, parentObject.transform.position.y, parentObject.transform.position.z);
        yield return null;
    }

    parentObject.transform.position = new Vector3(targetX, parentObject.transform.position.y, parentObject.transform.position.z);
    Time.timeScale = 1.0f; // Reset the time scale back to normal
}



}