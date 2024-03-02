using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class Settings_WeekdayPrefab : MonoBehaviour
{
    public GameObject prefab;
    public GameObject panel;
    public int numberOfInstances = 14;

    private string[] days = new string[] { "SO", "MO", "DI", "MI", "DO", "FR", "SA", "SO", "MO", "DI", "MI", "DO", "FR", "SA" };

    void Start()
    {
        if (prefab == null || panel == null)
        {
            Debug.LogError("Prefab or panel is not assigned!");
            return;
        }

        try
        {
            SaveGameObjects.GameData gameData = (SaveGameObjects.GameData)SaveGameMechanic.getSaveGameObjectByPrimaryKey("gameData", 1);
            if (gameData == null)
            {
                Debug.LogError("GameData not found!");
                return;
            }

            DateTime firstDayOfPlaying = gameData.firstDayOfPlaying;
            int firstDayIndex = (int)firstDayOfPlaying.DayOfWeek;
            string[] daysFromToday = new string[days.Length];

            // Adjust the daysFromToday array based on the firstDayIndex
            for (int i = 0; i < days.Length; i++)
            {
                int index = (firstDayIndex + i) % days.Length;
                daysFromToday[i] = days[index];
            }

            // Instantiate the prefabs with adjusted days
            for (int i = 0; i < numberOfInstances; i++)
            {
                GameObject instance = Instantiate(prefab, panel.transform);
                TextMeshProUGUI textMesh = instance.GetComponentInChildren<TextMeshProUGUI>();
                textMesh.text = daysFromToday[i];
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error: {e.Message}");
        }
    }
}
