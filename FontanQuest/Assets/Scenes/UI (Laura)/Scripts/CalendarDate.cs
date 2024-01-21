using System;
using UnityEngine;
using TMPro; // Make sure to include this for TextMeshPro elements

public class CalendarDate : MonoBehaviour
{
    public GameObject datePanel; // Assign your DatePanel GameObject in the inspector
    private DateTime startDate; // Set this date to your program's start date

    void Start()
    {
        // Example start date - set this to your program's actual start date
        startDate = new DateTime(2024, 1, 21); // YYYY, MM, DD format

        UpdateDatePanel();
    }

    private void UpdateDatePanel()
    {
        if (datePanel != null)
        {
            TMP_Text[] dateTexts = datePanel.GetComponentsInChildren<TMP_Text>();
            DateTime currentDate = startDate;

            for (int i = 0; i < 7; i++)
            {
                if (i < dateTexts.Length)
                {
                    dateTexts[i].text = currentDate.DayOfWeek.ToString().Substring(0, 3).ToUpper(); // Sets text to MON, TUE, etc.
                    currentDate = currentDate.AddDays(1); // Move to the next day
                }
            }
        }
        else
        {
            Debug.LogError("DatePanel GameObject is not assigned.");
        }
    }
}