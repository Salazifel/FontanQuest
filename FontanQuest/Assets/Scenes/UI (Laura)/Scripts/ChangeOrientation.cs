using UnityEngine;

public class ChangeOrientation : MonoBehaviour
{
    void Start()
    {
        // Set the desired orientation for the parent's section
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void OnDestroy()
    {
        // Optional: Reset the orientation when the scene is destroyed or when moving to another scene
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
