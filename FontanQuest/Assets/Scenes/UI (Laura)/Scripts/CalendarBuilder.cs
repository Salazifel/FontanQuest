using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CalendarBuilder : MonoBehaviour
{
    public GameObject dayBoxPrefab;
    public Transform dayPanelTransform;
    private DateTime startDate;

    public Sprite checkMarkSprite; // Assign the "Checkmark" sprite in the inspector
    public Sprite xMarkSprite;     // Assign the "close" sprite in the inspector

    void Start()
    {
        startDate = DateTime.Today; // or set a specific start date
        BuildCalendar();
    }

    void BuildCalendar()
    {
        DateTime currentDate = startDate;
        for (int i = 0; i < 14; i++)
        {
            GameObject dayBox = Instantiate(dayBoxPrefab, dayPanelTransform);

            // Update the date text
            TextMeshProUGUI dateText = dayBox.GetComponentInChildren<TextMeshProUGUI>();
            dateText.text = currentDate.Day.ToString();

            // Update the image based on activity
            Image dayImage = dayBox.GetComponentInChildren<Image>();
            dayImage.sprite = IsActivityDone(currentDate) ? checkMarkSprite : xMarkSprite;

            // Prepare for the next iteration
            currentDate = currentDate.AddDays(1);
        }
    }

    bool IsActivityDone(DateTime date)
    {
        // Placeholder for your logic to determine if activity is done
        // This should be replaced with actual logic
        return UnityEngine.Random.value > 0.5; // Randomly returns true or false for demonstration
    }
}