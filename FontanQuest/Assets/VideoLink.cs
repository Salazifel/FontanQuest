using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class VideoLink : MonoBehaviour
{
    public TextMeshProUGUI textField;
    
    private void Start() { textField = GameObject.Find("Fact").GetComponent<TextMeshProUGUI>(); }
    public void OpenVideo()
    {
        
        if (textField.text == "Why don't we do a pirate themed workout?") { Application.OpenURL("https://youtu.be/FRWEMBe2BCg"); }
            
        else if (textField.text == "Why don't we do a dance session?")
    {
      Application.OpenURL("https://www.youtube.com/watch?v=xlg052EKMtk&ab_channel=CosmicKidsYoga");
    }
    }
           

    
    
}
