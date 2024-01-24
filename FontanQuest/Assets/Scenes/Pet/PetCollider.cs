using UnityEngine;

public class PetCollider : MonoBehaviour
{
    // Called when the collider enters another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Obstacle" tag
        if (other.CompareTag("Obstacles"))
        {
            // Do something when the Pet collides with an obstacle
            // For example, print a message to the console
            Debug.Log("Pet collided with an obstacle!");

            // You can add more actions or call other methods here
            // For example, you might want to decrease the health of the Pet
            // or play a sound effect.
        }
        else{
            Debug.Log("It collided but with WHAT?");
        }
    }
}
