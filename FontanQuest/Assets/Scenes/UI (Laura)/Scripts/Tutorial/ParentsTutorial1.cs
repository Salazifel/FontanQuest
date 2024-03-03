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
            text2.text = "Die Startseite zeigt auf einen Blick:" + "\n" + "� tagesaktuelle �bungen f�r " + parentsOnboarding.nameChild + "\n" + "� �bungsfortschritt" + "\n" + "� �bersicht wie konsequent " + parentsOnboarding.nameChild + " den Trainingsplan bisher eingehalten hat (Streak)" + "\n" + "� Wochen�bersicht aller Aktivit�ten";
        }
    }
}
