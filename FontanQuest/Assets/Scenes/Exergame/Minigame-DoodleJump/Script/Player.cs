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
    float movement = 0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        scoreTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        UpdateScore();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    void UpdateScore()
    {
        scoreTime += Time.deltaTime;
        if(scoreTime>1f)
        {
            score++;
            scoreTime = 0f;
            scoreText.text = score.ToString() + " Level";
        }
    }
}
