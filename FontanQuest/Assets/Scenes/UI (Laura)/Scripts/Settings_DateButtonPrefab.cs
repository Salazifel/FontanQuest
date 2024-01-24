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

    void Start()
    {
        if (dateButtonPrefab == null || panel == null || activityPanel == null)
        {
            Debug.LogError("Required components are not assigned!");
            return;
        }

        string filePath = @"C:\Users\Chris\Documents\WS23-24\FontanQuest\FirstDayTest.txt";
        DateTime startDate = DateTime.Now; // Default to today

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
                button.onClick.AddListener(() => activityPanel.LoadActivitiesForDate(buttonDate));
            }
        }
    }
}
