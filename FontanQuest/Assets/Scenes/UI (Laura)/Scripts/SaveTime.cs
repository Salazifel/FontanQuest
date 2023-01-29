using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveTime : MonoBehaviour
{
    public TextMeshProUGUI textField;
    // Start is called before the first frame update
    void Start()
    {
      textField = GameObject.Find("TimeUpdate").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
      textField.text = ResourceContainer.time_played.ToString();
    }
}
