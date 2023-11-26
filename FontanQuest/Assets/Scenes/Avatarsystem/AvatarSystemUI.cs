using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSystemUI : MonoBehaviour
{
    GameObject playerCharacterObject;

    GameObject[] PlayerCharacters;
    private int currentArrayPosition;
    void Awake()
    {
        playerCharacterObject = GameObject.Find("PlayerCharacter");
        PlayerCharacters = new GameObject[12];
        PlayerCharacters[0] = GameObject.Find("Character_Female_Druid");
        PlayerCharacters[1] = GameObject.Find("Character_Female_Gypsy");
        PlayerCharacters[2] = GameObject.Find("Character_Female_Peasant_01");
        PlayerCharacters[3] = GameObject.Find("Character_Female_Peasant_02");
        PlayerCharacters[4] = GameObject.Find("Character_Female_Queen");
        PlayerCharacters[5] = GameObject.Find("Character_Female_Witch");
        PlayerCharacters[6] = GameObject.Find("Character_Male_Baird");
        PlayerCharacters[7] = GameObject.Find("Character_Male_King");
        PlayerCharacters[8] = GameObject.Find("Character_Male_Peasant_01");
        PlayerCharacters[9] = GameObject.Find("Character_Male_Rouge_01");
        PlayerCharacters[10] = GameObject.Find("Character_Male_Sorcerer");
        PlayerCharacters[11] = GameObject.Find("Character_Male_Wizard");
        disableAllCharacters();
        setCharacterModel(0);
    }

    public void NextCharacterButtonClick()
    {
        currentArrayPosition++;
        setCharacterModel(currentArrayPosition);
    }

    public void PreviousCharacterButtonClick()
    {
        currentArrayPosition--;
        setCharacterModel(currentArrayPosition);
    }

    public void disableAllCharacters() {
        foreach (GameObject character in PlayerCharacters)
        {
            character.SetActive(false);
        }
    }

    public void setCharacterModel(int arrayPosition)
    {
        disableAllCharacters();
        if (arrayPosition >= PlayerCharacters.Length) {
            arrayPosition = 0;
            currentArrayPosition = 0;
        }
        if (arrayPosition < 0) {
            arrayPosition = PlayerCharacters.Length -1;
            currentArrayPosition = PlayerCharacters.Length -1;
        }
        PlayerCharacters[arrayPosition].SetActive(true);
    }

    public int getCurrentCharacterModelArrayPosition()
    {
        return currentArrayPosition;
    }
}
