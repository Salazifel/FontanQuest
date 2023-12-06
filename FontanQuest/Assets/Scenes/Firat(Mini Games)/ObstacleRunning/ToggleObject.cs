using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    // Call this function to toggle the enabled state
    public void ToggleEnableDisable(GameObject canvas)
    {
        if (canvas != null)
        {
            // Toggle the active state of the canvas GameObject
            canvas.SetActive(!canvas.activeSelf);
        }
    }
}
