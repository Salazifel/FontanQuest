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
    private bool inputReceived;
    
    public float xValueAut;
    public float yValueAut;

    private int tapCount = 0;
    private float lastTapTime = 0f;
    public float tapThreshold = 0.5f; // Adjust this threshold as needed
    CameraSwitcher cameraSwitcher;
    void Start()
    {   
        cameraSwitcher = GameObject.Find("Playa").GetComponent <CameraSwitcher>();
        Debug.Log(inputReceived);
        this.fixedDeltaTime = Time.fixedDeltaTime;
        animator = GetComponent<Animator>();
        parentObject = GameObject.FindGameObjectWithTag("ParentPlaya");
        inputReceived = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Animals")
        {
            Time.timeScale = 0.05f;
            Debug.Log("DANGER!!!");

            Debug.Log(inputReceived);
            cameraSwitcher.SwitchCameras();
            StartCoroutine(InputTimer());


        }
    }
IEnumerator InputTimer()
{
    float startTime = Time.realtimeSinceStartup;
    float maxTime = 20f; // Adjust the time frame here (in seconds)
    float timeLeft = maxTime;

    while (Time.realtimeSinceStartup - startTime < maxTime)
    {
        timeLeft = maxTime - (Time.realtimeSinceStartup - startTime);
        int roundedTime = Mathf.CeilToInt(timeLeft); // Round up the time left

        // Display countdown message
        Debug.Log($"You have {roundedTime} seconds!");

        if (DetectTripleTap())
        {   
            inputReceived = true;
            break; // Exit the loop if input is received
        }

        yield return null;
    }

    Debug.Log(inputReceived);
    if (!inputReceived)
    {
        Debug.Log("Gameover!");
        Time.timeScale = 0.0f; // Reset the time scale back to normal
    }
    else
    {   
        cameraSwitcher.SwitchCameras();
        Debug.Log("You avoided the obstacle perfectly, game continues...");
        float direction = (parentObject.transform.position.x < 0) ? 1f : -1f;
        StartCoroutine(SlideObject(direction));
        inputReceived = false;
    }
}



IEnumerator SlideObject(float direction)
{
    float slideDistance = 5f; // Adjust the distance to slide here
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

  bool DetectTripleTap()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                float timeSinceLastTap = Time.time - lastTapTime;

                if (timeSinceLastTap < tapThreshold)
                {
                    tapCount++;

                    if (tapCount >= 3)
                    {
                        // Reset tap count for future detections
                        tapCount = 0;
                        return true;
                    }
                }
                else
                {
                    // Reset tap count if there was a delay between taps
                    tapCount = 1;
                }

                // Record the time of the current tap
                lastTapTime = Time.time;
            }
        }

        return false;
    }

}