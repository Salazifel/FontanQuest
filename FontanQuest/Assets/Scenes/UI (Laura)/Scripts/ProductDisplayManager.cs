using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ProductDisplayManager : MonoBehaviour
{
    public GameObject productPrefab; // Prefab for displaying each product
    public Transform productListContainer; // The UI parent where products are listed

    private List<Product> products = new List<Product>(); // List to store all products

    void Start()
    {
        // Optionally, load existing products or initialize with some products
    }

    public void AddProduct(string name, float price, string imageName)
    {
        Product newProduct = new Product(name, price, imageName);
        products.Add(newProduct);
        DisplayProduct(newProduct);
    }

    private void DisplayProduct(Product product)
    {
        GameObject productItem = Instantiate(productPrefab, productListContainer);

        // Assuming the prefab has text elements for name, price, and a delete button
        productItem.transform.Find("ProductNameText").GetComponent<Text>().text = product.Name;
        productItem.transform.Find("ProductPriceText").GetComponent<Text>().text = "$" + product.Price.ToString();
        Button deleteButton = productItem.transform.Find("DeleteButton").GetComponent<Button>();

        deleteButton.onClick.AddListener(() => DeleteProduct(product, productItem));
    }

    private void DeleteProduct(Product product, GameObject productItem)
    {
        products.Remove(product);
        Destroy(productItem);
    }

    private class Product
    {
        public string Name;
        public float Price;
        public string ImageName;

        public Product(string name, float price, string imageName)
        {
            Name = name;
            Price = price;
            ImageName = imageName;
        }
    }
}
