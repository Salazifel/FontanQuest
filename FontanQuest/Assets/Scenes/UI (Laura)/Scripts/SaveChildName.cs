using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveChildName : MonoBehaviour
{
    public TMP_InputField childNameInputField;

    public void SaveData()
    {
        string childName = childNameInputField.text;

        // Retrieve or create ParentsOnboarding data
        SaveGameObjects.ParentsOnboarding parentsOnboarding = SaveGameMechanic.getSaveGameObjectByPrimaryKey("ParentsOnboarding", 1) as SaveGameObjects.ParentsOnboarding;
        if (parentsOnboarding == null)
        {
            Debug.Log("ParentsOnboarding is null. Creating new ParentsOnboarding object.");
            parentsOnboarding = new SaveGameObjects.ParentsOnboarding(childName, ""); 
        }
        else
        {
            Debug.Log("ParentsOnboarding retrieved successfully.");
        }

        // Update parent's name in case the object already existed
        parentsOnboarding.nameChild = childName;

        // Save the updated object using SaveGameMechanic
        SaveGameMechanic.saveSaveGameObject(parentsOnboarding, "ParentsOnboarding", parentsOnboarding.primaryKey);
    }
}
