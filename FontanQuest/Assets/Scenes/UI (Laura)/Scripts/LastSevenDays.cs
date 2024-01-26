using System;
using System.IO;
using UnityEngine;
using TMPro;

public class LastSevenDays : MonoBehaviour
{
    public TextMeshProUGUI lastSevenDaysText;

    private void Start()
    {
        UpdateLastSevenDaysActivity();
    }

    private void UpdateLastSevenDaysActivity()
    {
        string filePath = @"C:\Users\Chris\Documents\WS23-24\FontanQuest\TodaysActivity.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int totalMinutesLastSevenDays = 0;

            DateTime today = DateTime.Now;
            DateTime sevenDaysAgo = today.AddDays(-7);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { ", " }, StringSplitOptions.None);
                if (parts.Length > 2)
                {
                    if (DateTime.TryParseExact(parts[0].Trim(), "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime lineDate))
                    {
                        if (lineDate >= sevenDaysAgo && lineDate <= today)
                        {
                            string[] details = parts[1].Trim().Split('=');
                            if (details.Length > 1)
                            {
                                string[] times = details[1].Trim().Split('/');
                                if (times.Length > 1)
                                {
                                    totalMinutesLastSevenDays += int.TryParse(times[0].Trim(), out int minutesSpent) ? minutesSpent : 0;
                                }
                            }
                        }
                    }
                }
            }

            // Update the TextMeshProUGUI element with the total minutes from the last seven days
            lastSevenDaysText.text = $"{totalMinutesLastSevenDays} min";
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
            lastSevenDaysText.text = "Keine Daten verfügbar";
        }
    }
}
