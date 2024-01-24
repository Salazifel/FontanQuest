using System.Collections;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject hayObject;
    private GameObject pet;
    public Pet_UI_Management_GameSet gameSet;
    private bool hasHayBeenPlaced = false; // Flag to track hay placement



    private void OnCollisionEnter(Collision collision)
    {   
        gameSet = GameObject.Find("Script Controller").GetComponent <Pet_UI_Management_GameSet>();

        if (!hasHayBeenPlaced && collision.gameObject.CompareTag("Finish"))
        {
            if (!hayObject.activeSelf)
            {
                hayObject.SetActive(true);
                gameObject.SetActive(false);

                hasHayBeenPlaced = true; // Set the flag to true
                Invoke("DeactivateHayObject", 5f); // Invoke the deactivation after 5 seconds
            }
            else
            {
                Debug.Log("There is already hay on the feeder!");
                Invoke("DeactivateHayObject", 5f);
            }
        }
    }

    private void DeactivateHayObject()
    {
        if (hayObject.activeSelf)
        {
            Debug.Log("Hay deactivated!");
            hayObject.SetActive(false);
            if (gameSet.petSystem.Pet_Hunger <100)
            {
                gameSet.petSystem.Pet_Hunger = gameSet.petSystem.Pet_Hunger + 5;
            }
            else
            {   
                gameSet.petSystem.Pet_Hunger = 99;
                gameObject.SetActive(true);
                Debug.Log("Dein Tier ist nicht mehr Hungrig!");
            }

            if (pet == null)
            {
                pet = GameObject.Find("Pet");
            }

            if (pet != null)
            {
                Vector3 currentScale = pet.transform.localScale;
                if (currentScale.x < 3.26f){
                    pet.transform.localScale = new Vector3(
                    currentScale.x + 0.25f,
                    currentScale.y + 0.25f,
                    currentScale.z + 0.25f
                );
                }
                else{
                    Debug.Log("Tier ist zu groSS");
                }
                }

        }
            // gameSet.petSystem.currentScale = pet.transform.localScale;
            hasHayBeenPlaced = false; // Reset the flag
            gameSet.savePetSystem();
        
    }
}
