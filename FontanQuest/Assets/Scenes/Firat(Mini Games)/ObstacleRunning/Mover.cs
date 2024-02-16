using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Animator animator;
    public float jumpDistance = 9.5f;
    [SerializeField] int speedVar = 15;
    private bool isJumping = false;

    private double oldStepCount;

    void Start()
    {
        animator = GetComponent<Animator>();
        PrintInstructions();
    }

    void Update()
    {
        if (!isJumping && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                StartCoroutine(Jump());
            }
        }

        if (oldStepCount != 0)
        {
            if (SmartWatchData.steps > oldStepCount)
            {
                StartCoroutine(Jump());
            }
        }

        oldStepCount = SmartWatchData.steps;
    }

    IEnumerator Jump()
    {
        isJumping = true;

        // Trigger the jump animation
        animator.SetBool("IsMoving", true);

        // Wait for a short delay to synchronize with the animation
        yield return new WaitForSeconds(0.2f);

        // Get the initial and target positions
        Vector3 initialPosition = transform.position;
        Debug.Log("jumpDistance: " + jumpDistance);

        Debug.Log("speedVar: " + speedVar);

        Vector3 targetPosition = initialPosition + transform.forward * jumpDistance;
        Debug.Log(targetPosition);

        // Calculate the time it should take to reach the target position based on the speedVar
        float duration = Vector3.Distance(initialPosition, targetPosition) / speedVar;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // Calculate the interpolation factor based on time
            float t = elapsedTime / duration;

            // Smoothly move towards the target position
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the position to the exact target position to avoid any discrepancies
        transform.position = targetPosition;

        // Reset the animator parameter
        animator.SetBool("IsMoving", false);

        isJumping = false;
    }

    void PrintInstructions()
    {
        Debug.Log("Follow the rabbit!");
        Debug.Log("Move your player with pressing space");
        Debug.Log("Try to avoid crashing into passing animals");
    }
}
