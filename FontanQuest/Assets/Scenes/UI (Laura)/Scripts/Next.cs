
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
       textField = GameObject.Find("Fact").GetComponent<TextMeshProUGUI>();

    }



public void PickRandomFromList()
    {
        string[] activities = new string[] { "football?",
                                               "dance sesion",
                                                "pirates"};
        //     string randomActivity = activities[Random.Range(0, activities.Length)];
        string randomActivity = activities[Random.Range(0, activities.Length)];
        textField.text = randomActivity;
        if (randomActivity == "football?")
        {
            VideoLink.gameObject.SetActive(false);
            textField.text = "Why don't we try a new sport in the park like football?";
      
        }
        else if (randomActivity == "dance sesion")
        {
            textField.text = "Why don't we do a dance session?";
            VideoLink.gameObject.SetActive(true);

        }
        else if (randomActivity == "pirates")
        {
            textField.text = "Why don't we do a pirate themed workout?";
            VideoLink.gameObject.SetActive(true);        

        }
        else
        {
            textField.text = "That is all the activities we have";
        }

    }


    public void PickFact()
    {
        string[] fact = new string[] { "Exercise training in Fontan patients is most likely safe and has positive effects on exercise capacity, cardiac function and quality of life. (Scheffers et al., 2021)",
                                                "Why don't we prepare a scavenger hunt?", "Why don't we have a dance seesion?" };
        string randomfact = fact[UnityEngine.Random.Range(0, fact.Length)];
        textField.text = randomfact;
    }



    public void changeText()
    {
        text = "hola";
        textField.text = text;
    }
}
