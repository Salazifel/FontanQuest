using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroductionMessageDisplay : MonoBehaviour
{
    public GameObject IntroductionPrefab;
 void Start()
    {
        SaveGameData.Load();
        if (MiniGameData.FirstVisit)
        {
            MiniGameData.FirstVisit = false;
        }
        else
        {
            Destroy(IntroductionPrefab);
        }
                   }

    public void CloseIntroduction()
    {
       Destroy(IntroductionPrefab);
        SaveGameData.Save();
    }

}
