using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnabledDisabled : MonoBehaviour
{
    public GameObject MainMenuPanel;

    public void MenuTrigger()
    {
        if(MainMenuPanel.activeInHierarchy == false)
        {
            MainMenuPanel.SetActive(true);
        }
        else
        {
            MainMenuPanel.SetActive(false);
        }
    }
}
