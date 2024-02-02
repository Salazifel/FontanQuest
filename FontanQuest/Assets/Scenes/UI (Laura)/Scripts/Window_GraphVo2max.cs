using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window_GraphVo2max : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();

        // Sample values and time stamps
        int[,] data = new int[,] {
            { 40, 39, 39, 40, 40, 40, 40, 40, 40, 41, 41, 41, 41, 41, 42 },
            // Add more rows as needed
        };

        ShowGraph(data);
    }

    private void ShowGraph(int[,] data)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 100f;
        float xSize = 50f;
        float labelXPosition = -350f; // Fixed starting X position for the labels

        // Calculate the total width of the graph
        float graphWidth = xSize * data.GetLength(1);

        // Scale the graph if it exceeds the container width
        if (graphWidth > graphContainer.sizeDelta.x)
        {
            float scaleRatio = graphContainer.sizeDelta.x / graphWidth;
            graphWidth *= scaleRatio;
            xSize *= scaleRatio;
        }

        // Calculate the distance to borders
        float distanceToBorder = (graphContainer.sizeDelta.x - graphWidth) / 2f;
        float firstCircleX = distanceToBorder;
        float lastCircleX = graphContainer.sizeDelta.x - distanceToBorder;

        // Calculate the even spacing between circles
        float evenSpacing = (lastCircleX - firstCircleX) / (data.GetLength(1) - 1);

        GameObject lastCircleGameObject = null;

        for (int i = 0; i < data.GetLength(1); i++)
        {
            float xPosition = firstCircleX + i * evenSpacing;

            // Iterate through rows to create circles and connections
            for (int j = 0; j < data.GetLength(0); j++)
            {
                float yPosition = (data[j, i] / yMaximum) * graphHeight;
                GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));

                if (lastCircleGameObject != null)
                {
                    CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                }

                lastCircleGameObject = circleGameObject;
            }

            // Calculate the timestamp date by subtracting days from the current date
            string timeStamp = GenerateTimeStamp(data.GetLength(1) - 1 - i);

            // CreateLabel with the adjusted labelXPosition
            CreateLabel(new Vector2(labelXPosition, -20f), timeStamp);

            // Increment labelXPosition for the next label
            labelXPosition += evenSpacing;
        }
    }

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(UnityEngine.UI.Image), typeof(RectTransform));
        gameObject.transform.SetParent(graphContainer, false);

        UnityEngine.UI.Image image = gameObject.GetComponent<UnityEngine.UI.Image>();
        image.sprite = circleSprite;
        image.color = Color.white;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return gameObject;
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(UnityEngine.UI.Image), typeof(RectTransform));
        gameObject.transform.SetParent(graphContainer, false);

        UnityEngine.UI.Image image = gameObject.GetComponent<UnityEngine.UI.Image>();
        image.color = Color.white;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            Vector2 dir = (dotPositionB - dotPositionA).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            float distance = Vector2.Distance(dotPositionA, dotPositionB);

            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(0, 0);
            rectTransform.sizeDelta = new Vector2(distance, 3f);
            rectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f;
            rectTransform.localEulerAngles = new Vector3(0, 0, angle);
        }
        else
        {
            Debug.LogError("RectTransform is null on the 'dotConnection' GameObject.");
        }
    }

    private GameObject CreateLabel(Vector2 anchoredPosition, string text)
    {
        GameObject label = new GameObject("label", typeof(Text), typeof(RectTransform));
        label.transform.SetParent(graphContainer, false);

        Text labelText = label.GetComponent<Text>();
        labelText.text = text;
        labelText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        labelText.fontSize = 10;
        labelText.alignment = TextAnchor.MiddleCenter;
        labelText.color = Color.white;

        RectTransform rectTransform = label.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(50f, 20f);
        rectTransform.anchorMin = new Vector2(0.5f, 0);
        rectTransform.anchorMax = new Vector2(0.5f, 0);

        return label;
    }

    private string GenerateTimeStamp(int index)
    {
        DateTime currentDate = DateTime.Now.Date;
        DateTime timeStamp = currentDate.AddDays(-index);
        return timeStamp.ToString("dd.MM.", System.Globalization.CultureInfo.InvariantCulture);
    }
}