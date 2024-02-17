using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public GameObject shrubFlowers;
    public GameObject bucketMilk;
    public GameObject pet;

    public GameObject bubble1;
    public GameObject bubble2;

    private bool shrubFlowersTouchedBucket = false;
    private bool shrubFlowersTouchedPet = false;

    private bool prevShrubFlowersTouchedPet = false;

    private float bubbleTimer = 0f;
    private float bubbleDuration = 5f; // Duration for bubbles to be active (in seconds)

    private Pet_UI_Management_GameSet gameSet;

    private void Start()
    {
        gameSet = GameObject.Find("Script Controller").GetComponent<Pet_UI_Management_GameSet>();

        // Check if any of the GameObjects are not found
        if (shrubFlowers == null || bucketMilk == null || pet == null || bubble1 == null || bubble2 == null)
        {
            Debug.LogError("One or more GameObjects not found!");
        }
    }

    private void Update()
    {
        // Check if all GameObjects are active
        if (shrubFlowers.activeSelf && bucketMilk.activeSelf && pet.activeSelf)
        {
            // Check if shrub-flowers is touching bucket-milk
            if (Mathf.Abs(shrubFlowers.transform.position.x - bucketMilk.transform.position.x) < 0.5f)
            {
                shrubFlowersTouchedBucket = true;
                bubble1.SetActive(true);
                bubbleTimer = Time.time; // Start the timer
            }

            // Check if shrub-flowers has touched pet
            if (shrubFlowersTouchedBucket && Mathf.Abs(shrubFlowers.transform.position.x - pet.transform.position.x) < 0.5f)
            {
                shrubFlowersTouchedPet = true;

                // Execute only if the previous state of shrubFlowersTouchedPet was false
                if (!prevShrubFlowersTouchedPet)
                {
                    DoSomethingWithPet();
                }
            }

            // Check if the timer has exceeded the bubble duration
            if (Time.time - bubbleTimer > bubbleDuration)
            {
                // Deactivate bubbles and reset flags
                bubble1.SetActive(false);
                bubble2.SetActive(false);
                shrubFlowersTouchedBucket = false;
                shrubFlowersTouchedPet = false;
                prevShrubFlowersTouchedPet = false;
            }
        }
    }

    private void DoSomethingWithPet()
    {
        bubble2.SetActive(true);

        // Increase pet cleanliness only if it hasn't been increased before
        if (gameSet.petSystem.Pet_Cleanliness < 100)
        {
            gameSet.petSystem.Pet_Cleanliness += 5;
            prevShrubFlowersTouchedPet = true; // Set the flag to true to prevent repeated increase
        }

        Debug.Log("Shrub-flowers touched the pet!");
    }
}
