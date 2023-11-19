using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class TimerController : MonoBehaviour
{
    [SerializeField] GameObject TimerContainer;
    [SerializeField] CountDownUI countTimerUI; // Reference to the CountDownUI component
    public float StartAt;
    float accumTime;
    float totalTime;
    // Start is called before the first frame update
    void Start()
    {
        TimerContainer.SetActive(false);
        countTimerUI.gameObject.SetActive(false);
        totalTime = 95f; // Set the total time in seconds (1 minute and 30 seconds)
        UpdateTimerUI(totalTime);
    }

    // Update is called once per frame
    void Update()
    {
        accumTime += Time.deltaTime;
        int countdownValue = Mathf.CeilToInt(5 - accumTime);
        countTimerUI.Max = Mathf.Max(0, countdownValue); // Ensure the countdown doesn't go below 0

        if (accumTime > 6f)
        {
            TimerContainer.SetActive(true);
            countTimerUI.gameObject.SetActive(true); // Disable the CountDownUI GameObject
        }
        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
            UpdateTimerUI(totalTime);
        }
        else if (!TimerContainer.activeSelf)
        {
            TimerContainer.SetActive(true);
            countTimerUI.gameObject.SetActive(true);
        }
    }

    void UpdateTimerUI(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);

        // Format the time as a string (e.g., "1:30")
        string formattedTime = string.Format("{0}:{1:00}", minutes, seconds);
        countTimerUI.UpdateCountDown(formattedTime);
    }
}
