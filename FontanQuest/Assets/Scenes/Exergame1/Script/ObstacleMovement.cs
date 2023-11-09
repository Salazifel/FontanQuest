using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to control the speed of the obstacle

    void Update()
    {
        Vector3 movement = Vector3.back * speed * Time.deltaTime;
        transform.Translate(movement);
        Debug.Log(gameObject.name + " transform position: " + transform.position);
    }
}
