using UnityEngine;
using UnityEngine.UI;

public class Infobox : MonoBehaviour
{
    public GameObject infoPanel;

    private void Start()
    {
        // Ensure the infoPanel is initially hidden
        infoPanel.SetActive(false);
    }

    // Called when the button is clicked
    public void ToggleInfoPanel()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
}