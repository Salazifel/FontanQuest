
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Next : MonoBehaviour
{
    public TextMeshProUGUI textField;
    public string text;
    public Button VideoLink;
   

    void Start()
    {
       textField = GameObject.Find("Fact (TMP)").GetComponent<TextMeshProUGUI>();
       VideoLink.gameObject.SetActive(false);

    }



public void PickRandomFromList()
    {
        string[] activities = new string[] { "football?",
                                               "dance sesion",
                                                "pirates", "act4", "act5", "sonic"};
        //     string randomActivity = activities[Random.Range(0, activities.Length)];
        string randomActivity = activities[Random.Range(0, activities.Length)];
        textField.text = randomActivity;
        if (randomActivity == "football?")
        {
            VideoLink.gameObject.SetActive(false);
            textField.text = "Wollen wir nicht im Park mal Fussbal spielen?";
      
        }
        else if (randomActivity == "dance sesion")
        {
            textField.text = "Warum tanzen wir nicht einbisschen mit Elsa, der Eiskonigin?";
            VideoLink.gameObject.SetActive(true);

        }
        else if (randomActivity == "pirates")
        {
            textField.text = "Lass uns ein Workout mit Piraten machen!";
            VideoLink.gameObject.SetActive(true);        

        }
        else if (randomActivity == "act4")
        {
            textField.text = "Wollen wir ins Schwimmbad gehen?";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "act5")
        {
            textField.text = "Wollen wir draussen Frisbee spielen?";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "sonic")
        {
            textField.text = "Lass uns einbisschen Yoga mit Sonic the Hedgehog machen!";
            VideoLink.gameObject.SetActive(true);

        }
        else
        {
            textField.text = "That is all the activities we have";
        }

    }


    public void PickFact()
    {

        string[] activities = new string[] { "football?",
                                               "dance sesion",
                                                "pirates", "act4", "act5", "sonic"};
        //     string randomActivity = activities[Random.Range(0, activities.Length)];
        string randomActivity = activities[Random.Range(0, activities.Length)];
        textField.text = randomActivity;
        if (randomActivity == "football?")
        {
            VideoLink.gameObject.SetActive(false);
            textField.text = "Bewegungstraining bei Fontan-Patienten ist höchstwahrscheinlich sicher und hat positive Auswirkungen auf die körperliche Leistungsfähigkeit, die Herzfunktion und die Lebensqualität. (Scheffers et al., 2021)";

        }
        else if (randomActivity == "dance sesion")
        {
            textField.text = "In 16 Studien mit 264 Patienten wurden in keiner der Studien negative Ergebnisse im Zusammenhang mit dem Trainingsprogramm ermittelt. (Scheffers et al., 2021)";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "pirates")
        {
            textField.text = "Eine frühzeitige Bewegungsförderung in der Kindheit führt zu einem aktiveren Lebensstil im Erwachsenenalter, da in der Kindheit angelegte Gewohnheiten eher beibehalten werden, als wenn erst in höherem Alter mit Sport begonnen wird. (De Cocker et al., 2011).";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "act4")
        {
            textField.text = "Die Ergebnisse der über 200 Fontan-Teilnehmer zeigen überzeugend, dass die kardiale Rehabilitation bei dieser Gruppe sicher ist und dass sie von der Teilnahme an einem Trainingsprogramm mit verbesserter Belastungstoleranz, Muskelkraft, Aktivitätsniveau und Lebensqualität stark profitieren. (N. Sutherland, Jones, & d'Udekem, 2015)";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "act5")
        {
            textField.text = "Mehr gewohnheitsmäßige körperliche Aktivität sollte bei Fontan-Patienten zu einer besseren Bewegungstoleranz führen. (McCrindle et al., 2007)";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "sonic")
        {
            textField.text = "Laut einer Studie von McCrindle aus dem Jahr 2007 waren der VO2-Spitzenwert und die maximale Herzfrequenz bei Fontan-Patienten, die körperlich aktiv waren, signifikant höher als bei denen, die nicht aktiv waren. (McCrindle et al., 2007)";
            VideoLink.gameObject.SetActive(false);

        }
        else
        {
            textField.text = "Klicken Sie auf \"Weiter\", um weitere Fakten zu sehen, oder auf \"Zurück\", um zum Menü \"Eltern\" zu gelangen.";
        }

    }
}
