using System;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DailyActivityPanel : MonoBehaviour
{
    public TextMeshProUGUI activity1Text;
    public TextMeshProUGUI activity2Text;
    public TextMeshProUGUI dayProgressText;
    public TextMeshProUGUI dayRequirementText;
    public Slider progressSlider;
    public TextMeshProUGUI percentageText;

    private void Start()
    {
        UpdateActivityText();
    }

    private void UpdateActivityText()
    {
        string filePath = @"C:\Users\Chris\Documents\WS23-24\FontanQuest\TodaysActivity.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int totalMinutes = 0;
            int totalRequirement = 0;
            string today = DateTime.Now.ToString("dd.MM.yyyy");

            foreach (string line in lines)
            {
                // Check if line contains today's date
                if (line.StartsWith(today))
                {
                    // For Activity1
                    if (line.Contains("Activity1 = "))
                    {
                        totalMinutes += UpdateTMPText(line, activity1Text, ref totalRequirement);
                    }
                    // For Activity2
                    else if (line.Contains("Activity2 = "))
                    {
                        totalMinutes += UpdateTMPText(line, activity2Text, ref totalRequirement);
                    }
                }
            }

            // Calculate and update progress on the slider
            if (totalRequirement > 0)
            {
                float progress = (float)totalMinutes / totalRequirement;
                progressSlider.value = progress;
                int percentage = Mathf.RoundToInt(progress * 100);
                percentageText.text = percentage + " %";
            }
            else
            {
                progressSlider.value = 0;
                percentageText.text = "0 %";
            }

            // Update DayProgress and DayRequirement
            dayProgressText.text = $"{totalMinutes}";
            dayRequirementText.text = $"/{totalRequirement} Minuten";
        }
        else
        {
            Debug.LogError("File not found: " + filePath);
        }
    }

    private int UpdateTMPText(string line, TextMeshProUGUI textMesh, ref int totalRequirement)
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
                    totalRequirement += int.TryParse(times[1].Trim(), out int requirement) ? requirement : 0;
                    return int.TryParse(times[0].Trim(), out int minutesSpent) ? minutesSpent : 0;
                }
            }
        }
        return 0;
    }
}
