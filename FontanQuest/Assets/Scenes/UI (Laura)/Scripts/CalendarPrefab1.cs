using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class CalendarPrefab1 : MonoBehaviour
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
}
