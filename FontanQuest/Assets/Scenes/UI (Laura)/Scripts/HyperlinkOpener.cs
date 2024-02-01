using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HyperlinkOpener : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public TMP_Text textMeshPro;
    private Color32 originalColor;
    private Color32 hoverColor = new Color32(255, 0, 0, 255); // Red for hover effect

    private void Awake()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TMP_Text>();

        originalColor = textMeshPro.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, null);
        if (linkIndex != -1)
        {
            // Change text color on hover
            textMeshPro.color = hoverColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Revert to the original color
        textMeshPro.color = originalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, null);
        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = textMeshPro.textInfo.linkInfo[linkIndex];

            // Open the link
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}
