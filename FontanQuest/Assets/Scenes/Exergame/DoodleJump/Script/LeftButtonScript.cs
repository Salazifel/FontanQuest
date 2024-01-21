using UnityEngine;
using UnityEngine.UI;

public class LeftButtonScript : MonoBehaviour
{
    public Player player;  // Reference to the Player script

    void Start()
    {
        // Attach the OnClick method to the button's click event
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Notify the player to move left
        player.MovePlayer(-0.3f);
    }
}
