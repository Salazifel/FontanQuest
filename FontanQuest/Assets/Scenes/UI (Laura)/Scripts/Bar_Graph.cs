using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bar_Graph : MonoBehaviour
{
    [SerializeField] private Sprite barSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();

        // Sample values and time stamps
        int[] data = new int[] { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };
        // Add more data points as needed

        ShowGraph(data);
    }

    private void ShowGraph(int[] data)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = Mathf.Max(data);
        float barWidth = 40f;
        float barSpacing = 5f;

        float firstBarX = barWidth / 2;

        for (int i = 0; i < data.Length; i++)
        {
            float xPosition = firstBarX + i * (barWidth + barSpacing);
            float barHeight = (data[i] / yMaximum) * graphHeight;

            CreateBar(new Vector2(xPosition, barHeight), barWidth, barHeight);

            string timeStamp = GenerateTimeStamp(data.Length - 1 - i);
            float labelYPosition = -10f; // Position the label just below the bar
            CreateLabel(new Vector2(xPosition, labelYPosition), timeStamp);
        }
    }

    private void CreateBar(Vector2 anchoredPosition, float width, float height)
    {
        GameObject gameObject = new GameObject("bar", typeof(UnityEngine.UI.Image), typeof(RectTransform));
        gameObject.transform.SetParent(graphContainer, false);

        UnityEngine.UI.Image image = gameObject.GetComponent<UnityEngine.UI.Image>();
        image.sprite = barSprite;
        image.color = Color.blue;

        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();

        // Adjust the anchoredPosition so that the bottom edge of the bar aligns with the x-axis (y position of 0)
        // Use anchoredPosition.y - height / 2 to align the bottom of the bar
        rectTransform.anchoredPosition = new Vector2(anchoredPosition.x, anchoredPosition.y - height / 2);
        rectTransform.sizeDelta = new Vector2(width, height);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
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
        rectTransform.anchoredPosition = new Vector2(anchoredPosition.x, anchoredPosition.y);
        rectTransform.sizeDelta = new Vector2(50f, 20f);

        // Match the anchor presets of the bars
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return label;
    }

    private string GenerateTimeStamp(int index)
    {
        DateTime currentDate = DateTime.Now.Date;
        DateTime timeStamp = currentDate.AddDays(-index);
        return timeStamp.ToString("dd.MM.", System.Globalization.CultureInfo.InvariantCulture);
    }
}
