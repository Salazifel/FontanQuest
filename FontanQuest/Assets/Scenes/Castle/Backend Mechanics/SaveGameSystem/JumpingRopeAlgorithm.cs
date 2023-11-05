using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpingRopeAlgorithm : MonoBehaviour
{
    void Start()
    {
        SaveGameObjects.JumpingTheRopeSavingGame jumpingTheRopeSavingGame = new SaveGameObjects.JumpingTheRopeSavingGame();
        jumpingTheRopeSavingGame.howmanyjumps = 3;
        jumpingTheRopeSavingGame.glee = 1000;

        SaveGameMechanic.saveSaveGameObject(jumpingTheRopeSavingGame, "exergames", 1);
    }

    public void LoadJumpingGame() 
    {
        SaveGameObjects.JumpingTheRopeSavingGame jumpingTheRopeSavingGame = (SaveGameObjects.JumpingTheRopeSavingGame)SaveGameMechanic.getAllSaveGameObjectsOfType(new SaveGameObjects.JumpingTheRopeSavingGame(), "exergames")[0];
        jumpingTheRopeSavingGame.glee = 6;

        SaveGameMechanic.saveSaveGameObject(jumpingTheRopeSavingGame, "exergames", 1);
    }
}