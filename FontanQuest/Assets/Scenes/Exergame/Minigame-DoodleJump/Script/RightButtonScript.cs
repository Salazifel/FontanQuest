using UnityEngine;
using UnityEngine.UI;

public class RightButtonScript : MonoBehaviour
{
    public Player player;  // Reference to the Player script

    void Start()
    {
        // Attach the OnClick method to the button's click event
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Notify the player to move right
        player.MovePlayer(0.3f);
    }
}
