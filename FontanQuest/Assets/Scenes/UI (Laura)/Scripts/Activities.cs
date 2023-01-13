using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Activities : MonoBehaviour
{
    public TextMeshPro Text;

    public void SetText(string text)
    {
        Text.text = "Exercise training in Fontan patients is most likely safe and has positive effects on exercise capacity, cardiac function and quality of life. (Scheffers et al., 2021)";
    }

}
