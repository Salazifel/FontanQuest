using UnityEngine;
using TMPro;
using System;
using System.IO;

public class Settings_Wochenprogramm : MonoBehaviour
{
    public TextMeshProUGUI activity1Text;
    public TextMeshProUGUI activity2Text;
    public TextMeshProUGUI dayProgressText; // To display the total activity time

    private void Start()
    {
        // Optionally, you can call LoadActivitiesForDate(DateTime.Now) here 
        // to load activities for the current day when the panel is first opened.
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

            foreach (string line in lines)
            {
                if (line.StartsWith(selectedDate))
                {
                    if (line.Contains("Activity1 = "))
                    {
                        totalMinutes += UpdateTMPText(line, activity1Text);
                        activity1Found = true;
                    }
                    else if (line.Contains("Activity2 = "))
                    {
                        totalMinutes += UpdateTMPText(line, activity2Text);
                        activity2Found = true;
                    }
                }
            }

            if (!activity1Found && !activity2Found)
            {
                activity1Text.text = "Kein Programm f�r diesen Tag";
                activity2Text.text = "";
            }
            else
            {
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
            dayProgressText.text = date.Date <= DateTime.Now.Date ? $"Aufgezeichnete Aktivit�tszeit: {totalMinutes} Minuten" : "";
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            activity1Text.text = "Kein Programm f�r diesen Tag";
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