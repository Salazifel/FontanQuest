using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class CalendarPrefab1 : MonoBehaviour
{
    public GameObject prefab;
    public GameObject panel;
    public int numberOfInstances = 14; // 14 instances for 14 days
    public Sprite completedDayImage; // Image to display when all activities are completed

    private List<Vector3> prefabPositions = new List<Vector3>();
    private LineRenderer lineRenderer;

    void Start()
    {
        if (prefab == null || panel == null || completedDayImage == null)
        {
            Debug.LogError("Prefab, Panel, or Completed Day Image is not assigned!");
            return;
        }

        GameObject lineRendererObject = new GameObject("LineRendererObject");
        lineRenderer = lineRendererObject.AddComponent<LineRenderer>();
        ConfigureLineRenderer();

        DateTime startDate = GetStartDateFromFile(@"C:\Users\Chris\Documents\WS23-24\FontanQuest\TodaysActivity.txt");
        int daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
        Dictionary<DateTime, bool> dayCompletionStatus = GetDayCompletionStatus();

        for (int i = 0; i < numberOfInstances; i++)
        {
            GameObject instance = Instantiate(prefab, panel.transform);
            TMP_Text textComponent = instance.GetComponentInChildren<TMP_Text>();
            Image imageComponent = instance.AddComponent<Image>(); // Add Image component to prefab

            if (textComponent != null)
            {
                DateTime currentDate = startDate.AddDays(i);
                int dayNumber = currentDate.Day;
                textComponent.text = dayNumber.ToString();

                // Check if all activities for this day are completed
                if (dayCompletionStatus.TryGetValue(currentDate, out bool isCompleted) && isCompleted)
                {
                    imageComponent.sprite = completedDayImage; // Set the completed day image
                }

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
        lineRenderer.useWorldSpace = true;
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

    private Dictionary<DateTime, bool> GetDayCompletionStatus()
    {
        Dictionary<DateTime, List<bool>> dailyActivities = new Dictionary<DateTime, List<bool>>();

        string[] lines = File.ReadAllLines(@"C:\Users\Chris\Documents\WS23-24\FontanQuest\TodaysActivity.txt");
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length > 1 && DateTime.TryParseExact(parts[0].Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                string activityPart = parts[1].Trim();
                string[] activityDetails = activityPart.Split('=');
                if (activityDetails.Length > 1)
                {
                    string[] progress = activityDetails[1].Trim().Split('/');
                    if (progress.Length == 2 && progress[0].Trim() == progress[1].Trim())
                    {
                        if (!dailyActivities.ContainsKey(date))
                        {
                            dailyActivities[date] = new List<bool>();
                        }
                        dailyActivities[date].Add(true);
                    }
                }
            }
        }

        // Calculate completion status for each day
        Dictionary<DateTime, bool> dayCompletionStatus = new Dictionary<DateTime, bool>();
        foreach (var kvp in dailyActivities)
        {
            dayCompletionStatus[kvp.Key] = kvp.Value.All(completed => completed);
        }

        return dayCompletionStatus;
    }
}
