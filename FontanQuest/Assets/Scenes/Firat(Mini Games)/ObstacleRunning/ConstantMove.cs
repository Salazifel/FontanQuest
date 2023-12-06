using UnityEngine;
public class ConstantMove : MonoBehaviour
{
    public float speedVar = 0.5f;
    public float xValue = 0;
    public float increm = 0.1f;

    public float resetXPosition = 65f; // Define the X position for reset

    Vector3 initialPosition;
    GameObject playerHare;

    bool isEnabled = true;

    void Start()
    {   
        isEnabled = true;
        playerHare = GameObject.Find("Player_Hare");
        initialPosition = transform.position; // Store the initial global position
    }

    void Update()
    {
        if (playerHare != null)
        {
            if (isEnabled)
            {
                Move();

                if (transform.position.x >= resetXPosition) // Check X position for reset
                {
                    ResetObject();
                }
            }
            else
            {
                if (Vector3.Distance(initialPosition, transform.position) < 0.1f)
                {
                    ResetObject();
                }
            }
        }
    }

    public void ResetObject()
    {   
        transform.position = initialPosition; // Reset the position
        xValue = xValue / 2;
        isEnabled = true; // Enable the script to resume movement
    }

    public void Move()
    {
        xValue += increm * speedVar * Time.deltaTime;
        transform.position += new Vector3(xValue, 0, 0);
    }
}
