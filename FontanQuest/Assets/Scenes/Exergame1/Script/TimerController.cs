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
        //TimerContainer.SetActive(false);
        //countTimerUI.gameObject.SetActive(false);
        totalTime = 90f; // Set the total time in seconds (1 minute and 30 seconds)
        UpdateTimerUI(totalTime);
    }

    void Update()
    {

        accumTime += Time.deltaTime;

        if (accumTime > 6f)
        {
            TimerContainer.SetActive(true);
            countTimerUI.gameObject.SetActive(true);

            if (totalTime > 0f)
            {
                totalTime -= Time.deltaTime;
                UpdateTimerUI(totalTime);
            }
            else
            {
                TimerContainer.SetActive(false);
                countTimerUI.gameObject.SetActive(false);
            }
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
