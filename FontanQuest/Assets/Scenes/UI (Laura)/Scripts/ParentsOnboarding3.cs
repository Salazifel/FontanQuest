using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParentsOnboarding3 : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;

    void Start()
    {

        SaveGameObjects.ParentsOnboarding parentsOnboarding = SaveGameMechanic.getSaveGameObjectByPrimaryKey("ParentsOnboarding", 1) as SaveGameObjects.ParentsOnboarding;
        if (parentsOnboarding != null)
        {
            nameLabel.text = "Wunderbar! " +
                "Wir freuen uns auf " + parentsOnboarding.nameChild + ".";
        }
        else
        {
            nameLabel.text = "Wunderbar!";
        }
    }
}
