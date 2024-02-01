using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ParentsOnboarding2 : MonoBehaviour
{
    public TextMeshProUGUI nameLabel; 

    void Start()
    {
      
        SaveGameObjects.ParentsOnboarding parentsOnboarding = SaveGameMechanic.getSaveGameObjectByPrimaryKey("ParentsOnboarding", 1) as SaveGameObjects.ParentsOnboarding;
        if (parentsOnboarding != null)
        {
            nameLabel.text = "Danke, " + parentsOnboarding.nameParent; 
        }
        else
        {
            nameLabel.text = "Danke."; 
        }
    }
}
