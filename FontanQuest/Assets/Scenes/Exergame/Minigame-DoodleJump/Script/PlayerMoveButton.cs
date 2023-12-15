using UnityEngine;

public class PlayerMoveButton : MonoBehaviour
{
    public Player player;
    public float direction;

    private bool isPressed = false;

    void Update()
    {
        if (isPressed)
        {
            player.MovePlayer(direction);
        }
    }

    public void OnPointerDown()
    {
        isPressed = true;
        player.MovePlayer(direction);
    }

    public void OnPointerUp()
    {
        isPressed = false;
        player.MovePlayer(0f); // Stop movement when the button is released
    }
}
