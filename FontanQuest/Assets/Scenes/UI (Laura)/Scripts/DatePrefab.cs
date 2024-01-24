using UnityEngine;
using TMPro;
using System;
using System.IO;
using System.Globalization;

public class DatePrefab : MonoBehaviour
{
    public GameObject prefab;
    public GameObject panel;
    public int numberOfInstances = 7;

    private string[] days = new string[] { "SO", "MO", "DI", "MI", "DO", "FR", "SA" };

    void Start()
    {
        
        if (prefab == null || panel == null)
        {
            Debug.LogError("Prefab or panel is not assigned!");
            return;
        }

        int todayIndex = (int)DateTime.Now.DayOfWeek;
        string[] daysFromToday = new string[days.Length];

        try
        {
            string filePath = @"C:\Users\Chris\Documents\WS23-24\FontanQuest\FirstDayTest.txt";
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split('=');
                if (values[0].Trim() == "firstDayOfPlaying")
                {
                    string dateString = values[1].Trim();
                    DateTime firstDayOfPlaying;

                    if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out firstDayOfPlaying))
                    {
                        // Use firstDayOfPlaying's DayOfWeek to start the array
                        int firstDayIndex = (int)firstDayOfPlaying.DayOfWeek;

                        // Adjust the daysFromToday array based on the firstDayIndex
                        for (int i = 0; i < days.Length; i++)
                        {
                            int index = (firstDayIndex + i) % days.Length;
                            daysFromToday[i] = days[index];
                        }
                    }
                }
            }

            for (int i = 0; i < numberOfInstances; i++)
            {
                GameObject instance = Instantiate(prefab, panel.transform);
                TextMeshProUGUI textMesh = instance.GetComponentInChildren<TextMeshProUGUI>();
                textMesh.text = daysFromToday[i];
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
