using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    public Slider slider;
    public GameObject collapsiblePanel; // Reference to the Collapsible Panel
    private RectTransform panelRectTransform; // RectTransform of the panel for size manipulation
    public bool isOn;

    void Start()
    {
        // Initialize the slider
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        // Initialize the RectTransform reference
        if (collapsiblePanel != null)
            panelRectTransform = collapsiblePanel.GetComponent<RectTransform>();
    }

    public void ValueChangeCheck()
    {
        // Assuming the slider goes from 0 to 1, with 0.5 as the threshold
        isOn = slider.value > 0.5f;
        Debug.Log(isOn ? "Switch is ON" : "Switch is OFF");

        if (collapsiblePanel != null)
        {
            // Toggle the panel's visibility based on the switch
            collapsiblePanel.SetActive(isOn);

            if (isOn)
            {
                // Here, you can dynamically calculate and set the size of the panel
                // depending on its content. For example:
                // panelRectTransform.sizeDelta = new Vector2(panelWidth, contentHeight);
            }
        }
    }
}