using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class DatePrefab_Hannes : MonoBehaviour
{
    public GameObject prefab;
    public GameObject panel;
    public int numberOfInstances = 7;

    private string[] days = new string[] { "SO", "MO", "DI", "MI", "DO", "FR", "SA" };

    void Start()
    {
        // Retrieve or create gameData
        SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("GameData", 1);
        if (gameData == null)
        {
            Debug.Log("GameData is null. Creating new GameData object.");
            gameData = (SaveGameObjects.GameData)SaveGameObjects.CreateSaveGameObject("GameData");
        }
        else
        {
            Debug.Log("GameData retrieved successfully.");
        }

        // Check prefab and panel assignments
        if (prefab == null || panel == null)
        {
            Debug.LogError("Prefab or panel is not assigned!");
            return;
        }

        string[] daysFromToday = new string[days.Length];

        // Check and use the firstDayOfPlaying property
        DateTime? firstDayOfPlaying = gameData.firstDayOfPlaying; // Assuming firstDayOfPlaying is of type DateTime?
        if (firstDayOfPlaying == null || firstDayOfPlaying == DateTime.MinValue)
        {
            Debug.Log("firstDayOfPlaying is not set or invalid. Using current date.");
            firstDayOfPlaying = DateTime.Now; // Use current date if not set
        }

        // Use firstDayOfPlaying's DayOfWeek to start the array
        int firstDayIndex = (int)firstDayOfPlaying.Value.DayOfWeek;

        // Adjust the daysFromToday array based on the firstDayIndex
        for (int i = 0; i < days.Length; i++)
        {
            int index = (firstDayIndex + i) % days.Length;
            daysFromToday[i] = days[index];
        }

        // Instantiate prefab for each day
        for (int i = 0; i < numberOfInstances; i++)
        {
            GameObject instance = Instantiate(prefab, panel.transform);
            TextMeshProUGUI textMesh = instance.GetComponentInChildren<TextMeshProUGUI>();
            if (textMesh != null)
            {
                textMesh.text = daysFromToday[i];
                Debug.Log("Instance created with text: " + daysFromToday[i]);
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found in prefab");
            }
        }
    }
}