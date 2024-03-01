using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExpandableText : MonoBehaviour
{
    public TMP_Text myText; // Reference to your TextMeshPro UI component
    public Button expandButton; // Reference to your button to toggle text expansion
    private bool isTextExpanded = false; // Track whether the text is currently expanded
    private string fullText; // Store the full version of the text
    private string previewText; // Store the shortened version of the text

    void Start()
    {
        // Assuming you've assigned the full text in the inspector or elsewhere in your code
        fullText = myText.text;

        // Check if the text exceeds 50 characters
        if (fullText.Length > 50)
        {
            // If so, prepare a shortened version with an ellipsis
            previewText = fullText.Substring(0, 50);
            myText.text = previewText;

            // Make sure the button is active because the text is longer than 50 characters
            expandButton.gameObject.SetActive(true);
        }
        else
        {
            // If the text is 50 characters or shorter, use the full text
            // and disable or hide the expand button since it's not needed
            previewText = fullText;
            myText.text = previewText;
            expandButton.gameObject.SetActive(false); // This hides the button
        }

        // Set up the button click listener only if the button is active
        if (expandButton.gameObject.activeSelf)
        {
            expandButton.onClick.AddListener(ToggleText);
        }
    }

    void ToggleText()
    {
        // Toggle the isTextExpanded flag
        isTextExpanded = !isTextExpanded;

        // Update the displayed text based on the current state
        myText.text = isTextExpanded ? fullText : previewText;

        // Hide the button if the text is expanded
        if (isTextExpanded)
        {
            expandButton.gameObject.SetActive(false); // This hides the button
        }

        // Optionally, adjust your UI layout here if necessary
        AdjustUILayout();
    }

    void AdjustUILayout()
    {
        // Direct use of 'myText' since it's already a TMP_Text component.
        TMP_Text textComponent = myText;

        // Ensure TMP_Text updates its layout immediately to get an accurate size.
        textComponent.ForceMeshUpdate();

        // Access the RectTransform of the TMP_Text to adjust its size.
        RectTransform textRectTransform = textComponent.rectTransform;

        // Calculate the height needed for the text. TMP_Text's preferredHeight gives us this information.
        float requiredHeight = textComponent.preferredHeight;

        // Optionally add some padding to the height.
        float padding = 10f; // Adjust this value based on your needs.

        // Set the size of the RectTransform to match the text's height plus any padding.
        // Here, we're only adjusting the height, so the width remains unchanged.
        textRectTransform.sizeDelta = new Vector2(textRectTransform.sizeDelta.x, requiredHeight + padding);

        // No need to manually force a layout rebuild on the parent since we're directly adjusting the size of the text container.
    }

}
