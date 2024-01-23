using UnityEngine;
using TMPro;
using System;

public class CalendarPrefab1 : MonoBehaviour
{
    public GameObject prefab;
    public GameObject panel;
    public int numberOfInstances = 14; // 14 instances for 14 days

    void Start()
    {
        if (prefab == null || panel == null)
        {
            Debug.LogError("Prefab or Panel is not assigned!");
            return;
        }

        DateTime today = DateTime.Today;
        int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

        for (int i = 0; i < numberOfInstances; i++)
        {
            GameObject instance = Instantiate(prefab, panel.transform);

            // Search for the TMP_Text component within the children of the instantiated prefab
            TMP_Text textComponent = instance.GetComponentInChildren<TMP_Text>();

            if (textComponent != null)
            {
                int dayNumber = (today.Day + i) % daysInMonth;
                dayNumber = dayNumber == 0 ? daysInMonth : dayNumber; // Adjust for end of month
                textComponent.text = dayNumber.ToString();
            }
            else
            {
                Debug.LogError("TextMeshPro component not found within prefab's children");
            }
        }
    }
}