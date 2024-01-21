using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerExample : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();

        // Start with the "Idle" animation state (assuming it exists in your Animator controller)
        animator.Play("Idle");
    }

    void Update()
    {
        // Example: Trigger animations based on user input or some condition
        if (Input.GetKeyDown(KeyCode.W))
        {
            // Trigger the "Walk" animation
            animator.Play("Walk");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            // Trigger the "Talk" animation
            animator.Play("Talk");
        }
    }

    // Example: You can also set parameters in the Animator controller
    public void SetJump(bool isJumping)
    {
        animator.SetBool("IsJumping", isJumping);
    }
}
