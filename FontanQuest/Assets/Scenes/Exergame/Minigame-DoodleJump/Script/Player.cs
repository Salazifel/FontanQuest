using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    [SerializeField] TextMeshProUGUI scoreText;
    int score;
    float scoreTime;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        scoreTime = 0f;
    }

    void Update()
    {
        UpdateScore();
    }

    void FixedUpdate()
    {
        // No need for keyboard input, as movement is now handled by buttons
    }

    void UpdateScore()
    {
        scoreTime += Time.deltaTime;
        if (scoreTime > 1f)
        {
            score++;
            scoreTime = 0f;
            scoreText.text = score.ToString() + " Level";
        }
    }

    // Called when the player jumps on a special platform
    public void OnSpecialPlatformJump()
    {
        // Increment the score rapidly for special platforms
        for (int i = 0; i < 10; i++)
        {
            score++;
        }

        scoreText.text = score.ToString() + " Level";
    }

    // Move the player based on input (-1 for left, 1 for right)
    public void MovePlayer(float direction)
    {
        float horizontalMovement = direction * movementSpeed;
        Vector2 velocity = rb.velocity;
        velocity.x = horizontalMovement;
        rb.velocity = velocity;
    }

}
