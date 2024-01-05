using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PunchManager : MonoBehaviour
{
    [SerializeField] GameObject[] PunchPrefabs;
    [SerializeField] TextMeshProUGUI scoreText;
    public FitnessBoxingUI fitnessBoxingUI;
    // int score = 0;
    // float NewScore = 0f;
    private static float NewScore = 0f;
    public void SpawnPunch1()
    {
        int r = Random.Range(0, PunchPrefabs.Length);
        GameObject Punch = Instantiate(PunchPrefabs[r], transform);
        Punch.transform.localPosition = new Vector3(-149, Random.Range(-240, -358), 0);
        // x = - 149, y = -240 ~ -358
        // Set BoxCollider2D as trigger
        BoxCollider2D punchCollider = Punch.GetComponent<BoxCollider2D>();
        if (punchCollider != null)
        {
            punchCollider.isTrigger = true;
        }
    }

    public void SpawnPunch2()
    {
        int r = Random.Range(0, PunchPrefabs.Length);
        GameObject Punch = Instantiate(PunchPrefabs[r], transform);
        Punch.transform.localPosition = new Vector3(153, Random.Range(-240, -358), 0);
        // x = 153, y = -240 ~ -358
        // Set BoxCollider2D as trigger
        BoxCollider2D punchCollider = Punch.GetComponent<BoxCollider2D>();
        if (punchCollider != null)
        {
            punchCollider.isTrigger = true;
        }
    }

    public void UpdateScore(float points)
    {
        NewScore += points;
        scoreText.text = "Score:  " + NewScore.ToString();
        if (NewScore > 1000)
        {
            FinishGame();
            NewScore = 0;
        }
    }

    public void FinishGame()
    {
        fitnessBoxingUI.ChangeToComplete();
        fitnessBoxingUI.CompleteLevel();
        // fitnessBoxingUI.SaveFitnessBoxingData();
    }
}
