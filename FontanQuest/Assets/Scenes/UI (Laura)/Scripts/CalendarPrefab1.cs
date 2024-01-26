using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using System.IO; // Added for file operations
using System.Linq; // Added for Linq operations

public class CalendarPrefab : MonoBehaviour
{
    public GameObject prefab;
    public GameObject panel;
    public int numberOfInstances = 14; // 14 instances for 14 days

    private List<Vector3> prefabPositions = new List<Vector3>(); // List to store prefab positions
    private LineRenderer lineRenderer; // LineRenderer reference

    void Start()
    {
        if (prefab == null || panel == null)
        {
            Debug.LogError("Prefab or Panel is not assigned!");
            return;
        }

        // Create a new GameObject for the LineRenderer
        GameObject lineRendererObject = new GameObject("LineRendererObject");
        lineRenderer = lineRendererObject.AddComponent<LineRenderer>(); // Add LineRenderer component
        ConfigureLineRenderer(); // Configure the LineRenderer

        DateTime startDate = GetStartDateFromFile(@"C:\Users\Chris\Documents\WS23-24\FontanQuest\TodaysActivity.txt");
        int daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

        for (int i = 0; i < numberOfInstances; i++)
        {
            GameObject instance = Instantiate(prefab, panel.transform);

            // Search for the TMP_Text component within the children of the instantiated prefab
            TMP_Text textComponent = instance.GetComponentInChildren<TMP_Text>();

            if (textComponent != null)
            {
                int dayNumber = (startDate.Day + i) % daysInMonth;
                dayNumber = dayNumber == 0 ? daysInMonth : dayNumber; // Adjust for end of month
                textComponent.text = dayNumber.ToString();

                // Store the position of the prefab
                prefabPositions.Add(instance.transform.position);
            }
            else
            {
                Debug.LogError("TextMeshPro component not found within prefab's children");
            }
        }

        DrawLinesBetweenPrefabs();
    }

    void ConfigureLineRenderer()
    {
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.startColor = lineRenderer.endColor = Color.green;
        lineRenderer.startWidth = lineRenderer.endWidth = 0.05f;
        lineRenderer.useWorldSpace = true; // Optional: Set to true if you are using world positions
    }

    void DrawLinesBetweenPrefabs()
    {
        lineRenderer.positionCount = prefabPositions.Count;
        lineRenderer.SetPositions(prefabPositions.ToArray());
    }

    private DateTime GetStartDateFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                var dates = lines
                    .Select(line => ParseDateFromLine(line))
                    .Where(date => date != DateTime.MaxValue)
                    .OrderBy(date => date);

                if (dates.Any())
                {
                    return dates.First();
                }
            }
        }
        else
        {
            Debug.LogWarning("File not found or empty, using current date: " + filePath);
        }

        return DateTime.Today; // Default to today if file is not found or empty
    }

    private DateTime ParseDateFromLine(string line)
    {
        string[] parts = line.Split(',');
        if (parts.Length > 0)
        {
            string dateString = parts[0].Trim();
            if (DateTime.TryParseExact(dateString, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
        }
        return DateTime.MaxValue;
    }
}
