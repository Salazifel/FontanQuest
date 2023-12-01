using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    void Start()
    {
        // Deactivate all individual animals under "Pet"
        DeactivateAllAnimals();
    }

    void DeactivateAllAnimals()
    {
        foreach (Transform child in transform) // For each group like "Wolves", "Deers"
        {
            foreach (Transform animal in child) // For each animal in the group
            {
                animal.gameObject.SetActive(false);
                Debug.Log(animal.gameObject.name);
            }
        }
    }

    // Function to activate a specific animal
    public void ActivateAnimal(string animalName)
    {
        Debug.Log("Activating " + animalName);
        //DeactivateAllAnimals(); // First, deactivate all animals

        foreach (Transform child in transform)
        {
            foreach (Transform animal in child)
            {
                if (animal.name == animalName)
                {
                    animal.gameObject.SetActive(true);
                    return; // Exit the function once the animal is found and activated
                }
            }
        }
    }
}
       
