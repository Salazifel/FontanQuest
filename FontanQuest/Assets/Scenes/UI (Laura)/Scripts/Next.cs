
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
            textField.text = "Exercise training in Fontan patients is most likely safe and has positive effects on exercise capacity, cardiac function and quality of life. (Scheffers et al., 2021)";

        }
        else if (randomActivity == "dance sesion")
        {
            textField.text = "From 16 studies with 264 patients, none of the studies reported negative outcome measures related to the exercise programme.";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "pirates")
        {
            textField.text = "Early promotion of movement during childhood leads to a more active lifestyle as an adult, since habits founded during childhood are more likely to be kept, than if sports are commenced at a higher age. (De Cocker et al., 2011).";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "act4")
        {
            textField.text = "The results in the over 200 Fontan participants in the literature convincingly demonstrates that cardiac rehabilitation is safe in this population and further, they deeply benefit from participation in an exercise program with improved exercise tolerance, muscle strength, activity levels and quality of life. ";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "act5")
        {
            textField.text = "More habitual physical activity should lead to a better exercise tolerance for Fontan Patients. (McCrindle et al., 2007)";
            VideoLink.gameObject.SetActive(false);

        }
        else if (randomActivity == "sonic")
        {
            textField.text = "According to the study made by McCrindle in 2007, VO2 peak and maximum HR were significantly higher in Fontan patients who had been physically active compared to those who had been inactive. (McCrindle et al., 2007)";
            VideoLink.gameObject.SetActive(false);

        }
        else
        {
            textField.text = "That is all the facts we have";
        }

    }



    public void changeText()
    {
        text = "hola";
        textField.text = text;
    }
}
