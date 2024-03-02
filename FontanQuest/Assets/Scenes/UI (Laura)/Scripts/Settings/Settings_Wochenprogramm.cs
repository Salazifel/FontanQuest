using UnityEngine;
using TMPro;
using System;
using System.IO;

public class Settings_Wochenprogramm : MonoBehaviour
{
    public TextMeshProUGUI activity1Text;
    public TextMeshProUGUI activity2Text;
    public TextMeshProUGUI dayProgressText; // To display the total activity time
    private DateTime programStartDate = new DateTime(2024, 1, 1); // Example start date
    private DateTime programEndDate = new DateTime(2024, 1, 14); // Example end date

    private void Start()
    {
        DateTime today = DateTime.Now;
        if (IsDateWithinProgram(today))
        {
            LoadActivitiesForDate(today);
        }
        else
        {
            Debug.Log("Today is not part of the 2 weeks program.");
        }
    }

    private bool IsDateWithinProgram(DateTime date)
    {
        return date >= programStartDate && date <= programEndDate;
    }

    public void LoadActivitiesForDate(DateTime date)
    {
        string filePath = @"C:\Users\Chris\Documents\WS23-24\FontanQuest\TodaysActivity.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int totalMinutes = 0;
            bool activity1Found = false;
            bool activity2Found = false;
            string selectedDate = date.ToString("dd.MM.yyyy");
            int activitiesFound = 0; // Track the number of activities found

            foreach (string line in lines)
            {
                if (line.StartsWith(selectedDate))
                {
                    if (line.Contains("Activity1 = "))
                    {
                        totalMinutes += UpdateTMPText(line, activity1Found || activity2Found ? activity2Text : activity1Text);
                        activity1Found = true;
                        activitiesFound++;
                    }
                    else if (line.Contains("Activity2 = "))
                    {
                        totalMinutes += UpdateTMPText(line, activity1Found ? activity2Text : activity1Text);
                        activity2Found = true;
                        activitiesFound++;
                    }
                }
            }

            // Adjust text based on the number of activities found
            if (activitiesFound == 0)
            {
                activity1Text.text = "Kein Programm für diesen Tag";
                activity2Text.text = "";
            }
            else if (activitiesFound == 1)
            {
                // If only one activity was found, ensure the second activity text is cleared
                activity2Text.text = "";
            }
            else
            {
                // If both activities are found, no change is needed here
                if (!activity1Found)
                {
                    activity1Text.text = "";
                }

                if (!activity2Found)
                {
                    activity2Text.text = "";
                }
            }

            // Update DayProgress text only if the date is not in the future
            dayProgressText.text = date.Date <= DateTime.Now.Date ? $"Aufgezeichnete Aktivitätszeit: {totalMinutes} Minuten" : "";
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            activity1Text.text = "Kein Programm für diesen Tag";
            activity2Text.text = "";
            dayProgressText.text = "";
        }
    }

    private int UpdateTMPText(string line, TextMeshProUGUI textMesh)
    {
        string[] parts = line.Split(new string[] { ", " }, StringSplitOptions.None);
        if (parts.Length > 2)
        {
            string activityDetails = parts[1].Trim();
            string activityName = parts[2].Trim();

            string[] details = activityDetails.Split('=');
            if (details.Length > 1)
            {
                string[] times = details[1].Trim().Split('/');
                if (times.Length > 1)
                {
                    textMesh.text = $"{times[1].Trim()} Minuten {activityName}";
                    return int.TryParse(times[0].Trim(), out int minutesSpent) ? minutesSpent : 0;
                }
            }
        }
        return 0;
    }
}
