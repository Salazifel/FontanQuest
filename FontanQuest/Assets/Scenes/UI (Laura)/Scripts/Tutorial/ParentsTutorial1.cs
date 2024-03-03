using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParentsTutorial1 : MonoBehaviour
{
    public TextMeshProUGUI text2;

    void Start()
    {

        SaveGameObjects.ParentsOnboarding parentsOnboarding = SaveGameMechanic.getSaveGameObjectByPrimaryKey("ParentsOnboarding", 1) as SaveGameObjects.ParentsOnboarding;
        if (parentsOnboarding.nameChild != null)
        {
            text2.text = "Die Startseite zeigt auf einen Blick:" + "\n" + "• tagesaktuelle Übungen für " + parentsOnboarding.nameChild + "\n" + "• Übungsfortschritt" + "\n" + "• Übersicht wie konsequent " + parentsOnboarding.nameChild + " den Trainingsplan bisher eingehalten hat (Streak)" + "\n" + "• Wochenübersicht aller Aktivitäten";
        }
    }
}
