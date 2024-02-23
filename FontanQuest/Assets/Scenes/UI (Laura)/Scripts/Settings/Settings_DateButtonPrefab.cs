using UnityEngine;
using TMPro;
using System;
using System.IO;
using System.Globalization;
using UnityEngine.UI;

public class Settings_DateButtonPrefab : MonoBehaviour
{
    public GameObject dateButtonPrefab;
    public GameObject panel;
    public int numberOfInstances = 14;
    public Settings_Wochenprogramm activityPanel;
    private TextMeshProUGUI currentlySelectedText; // Track the selected TextMeshProUGUI

    void Start()
    {
        if (dateButtonPrefab == null || panel == null || activityPanel == null)
        {
            Debug.LogError("Required components are not assigned!");
            return;
        }

        DateTime startDate = DateTime.Now; // Declare startDate here

        string filePath = @"C:\Users\Chris\Documents\WS23-24\FontanQuest\FirstDayTest.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] values = line.Split('=');
                if (values[0].Trim() == "firstDayOfPlaying")
                {
                    string dateString = values[1].Trim();
                    if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime firstDayOfPlaying))
                    {
                        startDate = firstDayOfPlaying;
                        break;
                    }
                }
            }
        }

        for (int i = 0; i < numberOfInstances; i++)
        {
            DateTime buttonDate = startDate.AddDays(i);
            GameObject dateButtonInstance = Instantiate(dateButtonPrefab, panel.transform);
            TextMeshProUGUI textMesh = dateButtonInstance.GetComponentInChildren<TextMeshProUGUI>();

            if (textMesh != null)
            {
                textMesh.text = buttonDate.Day.ToString();
            }

            Button button = dateButtonInstance.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnDateButtonClicked(textMesh, buttonDate));
            }
        }
    }

    private void OnDateButtonClicked(TextMeshProUGUI clickedText, DateTime buttonDate)
    {
        if (currentlySelectedText != null)
        {
            // Reset the color of the previously selected text
            currentlySelectedText.color = Color.white; // if default color is white
        }

        Color customBlue = new Color(30 / 255f, 30 / 255f, 108 / 255f);

        // Update the color of the newly selected text
        clickedText.color = customBlue;

        // Set the clicked text as the current selection
        currentlySelectedText = clickedText;

        // Load the activities for the selected date
        activityPanel.LoadActivitiesForDate(buttonDate);
    }
}
