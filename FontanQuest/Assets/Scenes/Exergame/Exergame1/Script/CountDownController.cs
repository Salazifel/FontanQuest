using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class CountDownController : MonoBehaviour
{
    [SerializeField] GameObject GetReady;
    [SerializeField] GameObject CountDown;
    [SerializeField] CountDownUI countDownUI; // Reference to the CountDownUI component
    public float StartAt;
    float accumTime;
    // Start is called before the first frame update
    void Start()
    {
        GetReady.SetActive(true);
        CountDown.SetActive(true);
        countDownUI.Max = 5; // Set the initial countdown value
    }

    // Update is called once per frame
    void Update()
    {
        accumTime += Time.deltaTime;
        int countdownValue = Mathf.CeilToInt(5 - accumTime);
        countDownUI.Max = Mathf.Max(0, countdownValue); // Ensure the countdown doesn't go below 0

        if (accumTime > 5f)
        {
            GetReady.SetActive(false);
            CountDown.SetActive(false);
            countDownUI.gameObject.SetActive(false); // Disable the CountDownUI GameObject
        }
    }
}
