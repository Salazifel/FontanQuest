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
            { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 },
            // Add more rows as needed
        };

        ShowGraph(data);
    }

    private void ShowGraph(int[,] data)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 50f;
        float xSize = 100f;
        float labelXPosition = -350f; // Fixed starting X position for the labels

        // Limit to the most recent 7 data points
        int numberOfPointsToShow = 7;
        int dataLength = data.GetLength(1);
        int startIndex = Mathf.Max(dataLength - numberOfPointsToShow, 0);

        // Calculate the total width of the graph for 7 data points or less
        float graphWidth = xSize * Math.Min(numberOfPointsToShow, dataLength);

        // Adjustments for scaling and positioning
        if (graphWidth > graphContainer.sizeDelta.x)
        {
            float scaleRatio = graphContainer.sizeDelta.x / graphWidth;
            graphWidth *= scaleRatio;
            xSize *= scaleRatio;
        }

        float distanceToBorder = (graphContainer.sizeDelta.x - graphWidth) / 2f;
        float firstCircleX = distanceToBorder;
        float lastCircleX = graphContainer.sizeDelta.x - distanceToBorder;

        // Adjust the even spacing calculation for the actual number of points to display
        float evenSpacing = (lastCircleX - firstCircleX) / (Math.Min(numberOfPointsToShow, dataLength) - 1);

        GameObject lastCircleGameObject = null;

        // Adjust loop to start from startIndex and ensure it only iterates through the last 7 data points
        // Inside the for loop that iterates over the data points
        for (int i = startIndex; i < dataLength; i++)
        {
            float xPosition = firstCircleX + (i - startIndex) * evenSpacing;

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

            // Use xPosition for placing the label directly below the corresponding dot
            string timeStamp = GenerateTimeStamp(dataLength - 1 - i);

            // Adjust the yPosition as needed to place the label below the graph dots
            CreateLabel(new Vector2(xPosition, -20f), timeStamp); // No longer using labelXPosition, directly using xPosition
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
        rectTransform.sizeDelta = new Vector2(12, 12);
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
        labelText.fontSize = 18;
        labelText.alignment = TextAnchor.MiddleCenter;
        labelText.color = Color.white;

        RectTransform rectTransform = label.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(70f, 25f);
        // Set the anchor and pivot to bottom-left
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0, 0); // This sets the pivot to the bottom-left

        return label;
    }


    private string GenerateTimeStamp(int index)
    {
        DateTime currentDate = DateTime.Now.Date;
        DateTime timeStamp = currentDate.AddDays(-index);
        return timeStamp.ToString("dd.MM.", System.Globalization.CultureInfo.InvariantCulture);
    }
}