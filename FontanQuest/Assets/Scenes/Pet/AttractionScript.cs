using UnityEngine;
using System.Collections;
public class AttractionScript : MonoBehaviour
{
    public string targetObjectName = "soccer-ball"; // The name of the target object
    public float attractionForce = 5f; // Adjust the strength of attraction
    public float desiredDistance = 3f; // The desired distance between objects when stationary
    public float distanceMultiplier = 0.1f; // Adjust how fast the distance decreases when stationary
    private GameObject targetObject;
    private Rigidbody rb; // Assuming the object has a Rigidbody component

    private Pet_UI_Management_GameSet pet_UI_Management;
    private Coroutine statChangesCoroutine;

    private void Start()
    {
        pet_UI_Management = GameObject.Find("Script Controller").GetComponent<Pet_UI_Management_GameSet>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Find the target object by name
        targetObject = GameObject.Find(targetObjectName);

        if (targetObject == null)
        {
            Debug.LogError("Target object not found!");
            return;
        }

        // Check if the object is being dragged (moving)
        if (IsBeingDragged())
        {
            // Calculate direction towards the target object
            Vector3 direction = targetObject.transform.position - transform.position;

            // Apply force to attract the object towards the target
            rb.AddForce(direction.normalized * attractionForce);

            // Rotate the object to face the target
            RotateTowardsTarget(targetObject.transform.position);

                Debug.Log("Pet is Having Fun, but Also getting dirtier!");

                // Check if the coroutine is already running before starting a new one
                if (statChangesCoroutine == null)
                {
                    statChangesCoroutine = StartCoroutine(StatChangesCoroutine());
                }
            }
            else
            {
                // If the condition is not satisfied, stop the coroutine
                StopStatChangesCoroutine();
            }

            // If the distance is less than 1.0f, stop the object
            if (Vector3.Distance(targetObject.transform.position, transform.position) < 1.0f)
            {
                rb.velocity = Vector3.zero;

        }
        else
        {
            // If the object is stationary, adjust the distance towards the desired distance
            AdjustDistance(targetObject.transform);
        }
    }

    private bool IsBeingDragged()
    {
        // Implement your logic to check if the object is being dragged
        return Vector3.Distance(targetObject.transform.position, transform.position) > 0.2f;
    }

    private void AdjustDistance(Transform targetTransform)
    {
        // Calculate current distance between objects
        float currentDistance = Vector3.Distance(transform.position, targetTransform.position);

        // Calculate the difference between current distance and desired distance
        float distanceDifference = currentDistance - desiredDistance;

        // If the difference is greater than zero, move the object closer
        if (distanceDifference > 0)
        {
            // Calculate force to move closer with a multiplier
            Vector3 direction = targetTransform.position - transform.position;
            float forceMagnitude = distanceDifference * distanceMultiplier;
            rb.AddForce(direction.normalized * forceMagnitude);
        }
    }

    private void RotateTowardsTarget(Vector3 targetPosition)
    {
        // Calculate the rotation needed to face the target position
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }

    private IEnumerator StatChangesCoroutine()
    {
        while (Vector3.Distance(targetObject.transform.position, transform.position) < 1.0f)
        {
            pet_UI_Management.petSystem.Pet_Happiness += 5;
            pet_UI_Management.petSystem.Pet_Cleanliness -= 5;
            Debug.Log(pet_UI_Management.petSystem.Pet_Happiness);
            Debug.Log(pet_UI_Management.petSystem.Pet_Cleanliness);

            // Wait for 20 seconds before the next iteration
            yield return new WaitForSeconds(20f);
        }

        // Coroutine finished, set it to null
        statChangesCoroutine = null;
    }

    private void StopStatChangesCoroutine()
    {
        if (statChangesCoroutine != null)
        {
            StopCoroutine(statChangesCoroutine);
            statChangesCoroutine = null;
        }
    }
}
