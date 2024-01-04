using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalManager : MonoBehaviour
{
    void Start()
    {
        DeactivateAllAnimals();
        GameObject pet = GameObject.Find("Pet");
        AnimalManager animalManager = pet.GetComponent<AnimalManager>();
        animalManager.ActivateAnimal("Bear_Cub_8");
        int petSystem_Key = SaveGameMechanic.saveSaveGameObject(new SaveGameObjects.PetSystem(false,false), "petSystem", 1);
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


    // -------------------- animal selection
    public enum DefaultCubsToSelect
    {
        Bear_Cub_1,
        Deer_stag_1,
        LowPoly_Boar_cub_1,
        Fox_cub_1,
        LowPoly_Hare_cub_1,
        Wolf_cub_01
    }
    DefaultCubsToSelect defaultCubsToSelect;
    int currentArrayPosition = 0;

    public void nextPet()
    {
        currentArrayPosition++;
        setCubByArray(currentArrayPosition);
    }

    public void previousPet()
    {
        currentArrayPosition--;
        setCubByArray(currentArrayPosition);
    }

    public void setPet()
    {
        SaveGameObjects.PetSystem petSystem = (SaveGameObjects.PetSystem) SaveGameMechanic.getSaveGameObjectByPrimaryKey("PetSystem", 1);
        var enumValues = (DefaultCubsToSelect[])Enum.GetValues(typeof(DefaultCubsToSelect));
        Debug.Log(enumValues[currentArrayPosition]);
        petSystem.selectedAnimal = enumValues[currentArrayPosition].ToString();
        Debug.Log(petSystem.selectedAnimal);
        petSystem.animalSelected = true;
        SaveGameMechanic.getSaveGameObjectByPrimaryKey("PetSytem", 1);

        // new let's deactivate the buttons
        
    }

    public void setCubByArray(int arrayPosition)
    {
        DeactivateAllAnimals();
        // Get all values of DefaultCubsToSelect as an array
        var enumValues = (DefaultCubsToSelect[])Enum.GetValues(typeof(DefaultCubsToSelect));

        // cycle through the array if top or min is reached
        if (arrayPosition >= enumValues.Length)
        {
            arrayPosition = 0;
            currentArrayPosition = 0;
        }
        if (arrayPosition < 0)
        {
            arrayPosition = enumValues.Length - 1;
            currentArrayPosition = enumValues.Length - 1;
        }
        // actually changing the array
        ActivateAnimal(enumValues[arrayPosition].ToString());
    }
}
