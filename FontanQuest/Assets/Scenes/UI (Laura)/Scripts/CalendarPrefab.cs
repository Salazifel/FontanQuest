using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
    
    public class CalendarPrefab : MonoBehaviour
{
    public GameObject prefab;
    public GameObject panel;
    public int numberOfInstances = 14; // 14 instances for 14 days

    public Sprite checkmarkImage; // Reference to the Checkmark2 sprite
    public Sprite closeImage;     // Reference to the Close sprite

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
            Image imageComponent = instance.GetComponentInChildren<Image>(); // For the image component

            if (textComponent != null && imageComponent != null)
            {
                int dayNumber = (today.Day + i) % daysInMonth;
                dayNumber = dayNumber == 0 ? daysInMonth : dayNumber;
                textComponent.text = dayNumber.ToString();

                // Randomly select an image
                if (UnityEngine.Random.value > 0.5f)
                {
                    imageComponent.sprite = checkmarkImage;
                }
                else
                {
                    imageComponent.sprite = closeImage;
                }
            }
            else
            {
                Debug.LogError("TextMeshPro or Image component not found within prefab's children");
            }
        }
    }
}
