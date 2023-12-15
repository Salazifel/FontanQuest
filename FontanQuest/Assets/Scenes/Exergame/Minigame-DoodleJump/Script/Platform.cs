using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;
    public bool isSpecialPlatform = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;

                // If the platform is special, notify the player
                if (isSpecialPlatform)
                {
                    Player player = collision.collider.GetComponent<Player>();
                    if (player != null)
                    {
                        player.OnSpecialPlatformJump();
                    }
                }
            }
        }
    }
}
