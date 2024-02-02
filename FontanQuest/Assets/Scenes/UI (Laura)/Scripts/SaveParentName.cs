using UnityEngine;
using TMPro;

public class SaveParentName : MonoBehaviour
{
    public TMP_InputField parentNameInputField;

    public void SaveData()
    {
        string parentName = parentNameInputField.text;

        SaveGameObjects.ParentsOnboarding parentsOnboarding = SaveGameMechanic.getSaveGameObjectByPrimaryKey("ParentsOnboarding", 1) as SaveGameObjects.ParentsOnboarding;
        if (parentsOnboarding == null)
        {
            // If no existing data, create new with parent name and an empty child name.
            parentsOnboarding = new SaveGameObjects.ParentsOnboarding(parentName, "");
        }
        else
        {
            // Existing data found; only update the parent's name.
            parentsOnboarding.nameParent = parentName;
        }

        // Save the updated object
        SaveGameMechanic.saveSaveGameObject(parentsOnboarding, "ParentsOnboarding", parentsOnboarding.primaryKey);
    }
}
