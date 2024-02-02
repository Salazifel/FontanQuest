using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ProductCreationManager : MonoBehaviour
{
    public InputField productNameInput;
    public InputField productPriceInput;
    public Dropdown productImageDropdown;
    public Button createProductButton;

    // Example list of image names for the dropdown
    private List<string> imageOptions = new List<string> { "Image1", "Image2", "Image3" };

    void Start()
    {
        // Initialize the dropdown options
        productImageDropdown.AddOptions(imageOptions);

        // Add listener for the create button
        createProductButton.onClick.AddListener(CreateNewProduct);
    }

    private void CreateNewProduct()
    {
        string productName = productNameInput.text;
        float productPrice = float.Parse(productPriceInput.text);
        string selectedImage = productImageDropdown.options[productImageDropdown.value].text;

        // Here, you would create a new product object or send this data where it needs to go.
        Debug.Log($"Created Product: {productName}, Price: {productPrice}, Image: {selectedImage}");

        // Optionally, reset the input fields and dropdown after creation
        productNameInput.text = "";
        productPriceInput.text = "";
        productImageDropdown.value = 0;
    }
}
