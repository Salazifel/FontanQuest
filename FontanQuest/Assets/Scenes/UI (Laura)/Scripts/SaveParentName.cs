using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveParentName : MonoBehaviour
{
    public TMP_InputField parentNameInputField;

    public void SaveData()
    {
        string parentName = parentNameInputField.text;

        // Retrieve or create ParentsOnboarding data
        SaveGameObjects.ParentsOnboarding parentsOnboarding = SaveGameMechanic.getSaveGameObjectByPrimaryKey("ParentsOnboarding", 1) as SaveGameObjects.ParentsOnboarding;
        if (parentsOnboarding == null)
        {
            Debug.Log("ParentsOnboarding is null. Creating new ParentsOnboarding object.");
            // Adjust here to pass the required parameters to the constructor
            parentsOnboarding = new SaveGameObjects.ParentsOnboarding(parentName, ""); // Assuming the second parameter is for the child's name and can be empty or a placeholder
        }
        else
        {
            Debug.Log("ParentsOnboarding retrieved successfully.");
        }

        // Update parent's name in case the object already existed
        parentsOnboarding.nameParent = parentName;

        // Save the updated object using SaveGameMechanic
        SaveGameMechanic.saveSaveGameObject(parentsOnboarding, "ParentsOnboarding", parentsOnboarding.primaryKey);
    }
}
