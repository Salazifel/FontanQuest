using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnablePanel : MonoBehaviour
{
    public Button InsertData;
    // Start is called before the first frame update

    // Update is called once per frame
    public void Enable()
    {
        InsertData.gameObject.SetActive(true);
    }
}
