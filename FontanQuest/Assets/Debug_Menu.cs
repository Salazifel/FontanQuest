using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Menu : MonoBehaviour
{
    private GameObject Reset_Button;
    private GameObject Give_Resources_Button;
    private GameObject Debug_Menu_Button;

    private bool menu_active = false;
    public void reset_game()
    {
        GameObject.Find("MasterData").GetComponent<SavingGameData>().delete_SaveFile();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Screen");
    }

    public void give_Resources()
    {
        ResourceContainer.changeRes(10, 10, 10, 1);
    }

    public void Start()
    {
        Reset_Button = GameObject.Find("Reset");
        Give_Resources_Button = GameObject.Find("Give_Resources");
        Debug_Menu_Button = GameObject.Find("Open_Menu");

        hide_debug_menu();
    }

    public void debug_menu_click()
    {
        if (menu_active == false)
        {
            show_debug_menu();
            menu_active = true;
        }
        else
        {
            hide_debug_menu();
            menu_active = false;
        }
    }

    public void show_debug_menu()
    {
        Reset_Button.SetActive(true);
        Give_Resources_Button.SetActive(true);
    }

    public void hide_debug_menu()
    {
        Reset_Button.SetActive(false);
        Give_Resources_Button.SetActive(false);
    }
}
