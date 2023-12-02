using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    void Start()
    {
        DeactivateAllAnimals();
        GameObject pet = GameObject.Find("Pet");
        AnimalManager animalManager = pet.GetComponent<AnimalManager>();
        animalManager.ActivateAnimal("Bear_Cub_8");   
    }

    void DeactivateAllAnimals()
    {
        DeactivateChildrenRecursively(transform);
    }

    void DeactivateChildrenRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(false);
            DeactivateChildrenRecursively(child);
        }
    }

    public void ActivateAnimal(string animalName)
    {
        Debug.Log("Activating " + animalName);
        DeactivateAllAnimals(); // First, deactivate all animals

        if (ActivateAnimalRecursively(transform, animalName))
        {
            // If the animal is found and activated, activate its parent hierarchy
            ActivateParentHierarchy(transform, animalName);
        }
    }

    bool ActivateAnimalRecursively(Transform parent, string animalName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == animalName)
            {
                child.gameObject.SetActive(true);
                return true; // Animal found and activated
            }

            if (ActivateAnimalRecursively(child, animalName))
            {
                return true; // Animal found in sub-children
            }
        }
        return false; // Animal not found in this branch
    }

    void ActivateParentHierarchy(Transform parent, string animalName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == animalName)
            {
                // Activate all parents up to the root
                Transform currentParent = child.parent;
                while (currentParent != null)
                {
                    currentParent.gameObject.SetActive(true);
                    currentParent = currentParent.parent;
                }
                break;
            }
            ActivateParentHierarchy(child, animalName); // Check sub-children
        }
    }
}
