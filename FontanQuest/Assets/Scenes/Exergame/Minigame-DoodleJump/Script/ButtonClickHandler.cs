using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickHandler : MonoBehaviour, IPointerClickHandler
{
    public Player player;
    public float direction;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        player.MovePlayer(direction);
    }
}
