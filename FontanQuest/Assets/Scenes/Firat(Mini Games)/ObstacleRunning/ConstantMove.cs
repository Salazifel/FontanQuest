using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    public float speedVar = 0.3f;
    public float xValue = 0;
    public float increm = 1.05f;

    public float distance = 200.0f;
    Vector3 initialPosition;
    Vector3 initialPositionHare;
    GameObject playerHare;

    bool isEnabled = true; // Renamed to avoid conflict with Unity's enabled property

    void Start()
    {   
        isEnabled = true;
        playerHare = GameObject.Find("Player_Hare");
        initialPosition = transform.position; // Store the initial global position
        if (playerHare != null)
        {
            initialPositionHare = playerHare.transform.position;
        }
    }

    void Update()
    {
        if (playerHare != null)
        {
            // float distanceToPlayerX = Mathf.Abs(transform.position.x - playerHare.transform.position.x);
            // float distanceToPlayerZ = Mathf.Abs(transform.position.z - playerHare.transform.position.z);

            // if (distanceToPlayerZ <= 10.0f && distanceToPlayerX >= 200.0f)
            // {
            //     xValue = 0;
            //     isEnabled = false; // Stop the object's movement
            // }
            // else
            // {   
                if (isEnabled == true)
                {
                    Move();

                if (Mathf.Abs(transform.position.x - initialPosition.x) >= distance)
                {
                    ResetObject();
                }
                }
                else
                {
                    if (initialPositionHare == playerHare.transform.position){
                        ResetObject();
                    }
                }
            }
        }
    // }

    // Add a method to reset the object
    public void ResetObject()
    {   
        Vector3 newPosition = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
        transform.position = newPosition;
        xValue = xValue/2;
        Move();
        isEnabled = true; // Enable the script to resume movement
    }

    public void Move()
    {
        xValue += increm * speedVar * Time.deltaTime;
        transform.position += new Vector3(xValue, 0, 0);  // Use position directly
    }
}
