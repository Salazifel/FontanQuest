using UnityEngine;
using UnityEngine.UI;

public class ScrollSync : MonoBehaviour
{
    public ScrollRect scrollRect1;
    public ScrollRect scrollRect2;

    private bool isSyncing = false;

    void Start()
    {
        if (scrollRect1 != null && scrollRect2 != null)
        {
            // Add listeners to the scroll events
            scrollRect1.onValueChanged.AddListener(OnScrollRect1ValueChanged);
            scrollRect2.onValueChanged.AddListener(OnScrollRect2ValueChanged);
        }
    }

    private void OnScrollRect1ValueChanged(Vector2 value)
    {
        if (!isSyncing)
        {
            isSyncing = true;
            scrollRect2.verticalNormalizedPosition = value.y;
            scrollRect2.horizontalNormalizedPosition = value.x;
            isSyncing = false;
        }
    }

    private void OnScrollRect2ValueChanged(Vector2 value)
    {
        if (!isSyncing)
        {
            isSyncing = true;
            scrollRect1.verticalNormalizedPosition = value.y;
            scrollRect1.horizontalNormalizedPosition = value.x;
            isSyncing = false;
        }
    }
}