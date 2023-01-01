using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class CountDownUI : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private int _max;
    public int Max
    {
        get { return _max; }
        set
        {
            _max = value;
            if (textMesh != null)
            {
                textMesh.text = _max.ToString();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateCountDown(string seconds)
    {
        if (textMesh != null)
        {
            textMesh.text = seconds;
        }
    }
}
