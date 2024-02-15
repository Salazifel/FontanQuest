using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphExtended_Vo2Max : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();

        // Sample values and time stamps
        int[,] data = new int[,] {
            { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 },
            
        };

        ShowGraph(data);
    }

    private void ShowGraph(int[,] data)
    {
        float graphWidth = graphContainer.sizeDelta.x;
        float yMaximum = 100f;
        float xSize = 100f; // You might want to adjust this based on your landscape width
        float labelYPosition = -100f; // Adjusted starting Y position for the labels in landscape

        // Calculate the total height of the graph
        float graphHeight = graphContainer.sizeDelta.y;

        // Adjust for the wider graph area
        float xMaximum = data.GetLength(1) - 1;
        float ySize = graphHeight / yMaximum;

        GameObject lastCircleGameObject = null;

        for (int i = 0; i < data.GetLength(1); i++)
        {
            float normalizedXPosition = (i / xMaximum) * graphWidth;
            for (int j = 0; j < data.GetLength(0); j++)
            {
                float normalizedYPosition = (data[j, i] / yMaximum) * graphHeight;
                GameObject circleGameObject = CreateCircle(new Vector2(normalizedXPosition, normalizedYPosition));

                if (lastCircleGameObject != null)
                {
                    CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                }

                lastCircleGameObject = circleGameObject;
            }

            // Adjust label positioning for landscape orientation
            CreateLabel(new Vector2(normalizedXPosition, labelYPosition), GenerateTimeStamp(data.GetLength(1) - 1 - i));
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