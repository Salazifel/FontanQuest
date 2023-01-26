using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroductionMessageDisplay : MonoBehaviour
{
    public GameObject IntroductionPrefab;
 void Start()
    {
        if (GameData.FirstVisit)
        {
            GameData.FirstVisit = false;
        }
        else
        {
            Destroy(IntroductionPrefab);
        }
                   }

    public void CloseIntroduction()
    {
       Destroy(IntroductionPrefab);
    }

}
