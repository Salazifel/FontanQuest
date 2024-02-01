using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ClickableSlider : MonoBehaviour, IPointerDownHandler
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // This will handle the slider value change
        Vector2 localCursor;
        var rectTransform = slider.GetComponent<RectTransform>();
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, eventData.pressEventCamera, out localCursor))
        {
            float normalizedValue = Mathf.InverseLerp(rectTransform.rect.xMin, rectTransform.rect.xMax, localCursor.x);
            slider.value = normalizedValue * (slider.maxValue - slider.minValue) + slider.minValue;
            slider.onValueChanged.Invoke(slider.value);
        }
    }
}
