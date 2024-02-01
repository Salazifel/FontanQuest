using UnityEngine;
using TMPro;

public class SaveChildName : MonoBehaviour
{
    public TMP_InputField childNameInputField;

    public void SaveData()
    {
        string childName = childNameInputField.text;

        SaveGameObjects.ParentsOnboarding parentsOnboarding = SaveGameMechanic.getSaveGameObjectByPrimaryKey("ParentsOnboarding", 1) as SaveGameObjects.ParentsOnboarding;
        if (parentsOnboarding == null)
        {
            // If no existing data, create new with an empty parent name and child name.
            parentsOnboarding = new SaveGameObjects.ParentsOnboarding("", childName);
        }
        else
        {
            // Existing data found; only update the child's name.
            parentsOnboarding.nameChild = childName;
        }

        // Save the updated object
        SaveGameMechanic.saveSaveGameObject(parentsOnboarding, "ParentsOnboarding", parentsOnboarding.primaryKey);
    }
}
