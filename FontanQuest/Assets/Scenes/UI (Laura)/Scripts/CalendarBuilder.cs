using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CalendarBuilder : MonoBehaviour
{
    public GameObject prefab;
    public GameObject panel;
    public int numberOfInstances = 14;
    public Sprite checkmarkImage; // Reference to the Checkmark2 sprite
    public Sprite closeImage;     // Reference to the Close sprite
    public Color checkmarkColor = new Color(0.611f, 0.761f, 0.369f); // Color for Checkmark2 (9CC35E)
    public Color closeColor = Color.black; // Color for Close (000000)

    void Start()
    {
        if (prefab == null || panel == null || checkmarkImage == null || closeImage == null)
        {
            Debug.LogError("Prefab, Panel, or Images are not assigned!");
            return;
        }

        DateTime today = DateTime.Today;
        int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);

        for (int i = 0; i < numberOfInstances; i++)
        {
            GameObject instance = Instantiate(prefab, panel.transform);

            TMP_Text textComponent = instance.GetComponentInChildren<TMP_Text>();
            Image imageComponent = instance.GetComponentInChildren<Image>();

            if (textComponent != null && imageComponent != null)
            {
                int dayNumber = today.Day + i;
                if (dayNumber > daysInMonth)
                {
                    dayNumber -= daysInMonth; // Adjust for month rollover
                }
                textComponent.text = dayNumber.ToString();

                // Randomly select an image
                if (UnityEngine.Random.value > 0.5f)
                {
                    imageComponent.sprite = checkmarkImage;
                    //imageComponent.color = checkmarkColor; // Uncomment if color issue is resolved
                }
                else
                {
                    imageComponent.sprite = closeImage;
                    //imageComponent.color = closeColor; // Uncomment if color issue is resolved
                }
            }
            else
            {
                Debug.LogError("TextMeshPro or Image component not found within prefab's children");
            }
        }
    }
}