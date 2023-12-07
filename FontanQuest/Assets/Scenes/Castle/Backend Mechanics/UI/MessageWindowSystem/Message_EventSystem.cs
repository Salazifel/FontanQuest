using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_EventSystem : MonoBehaviour
{
    public delegate void MessageEventHandler(MessageObjectBlueprint.messageObject messageObject);
    public static event MessageEventHandler OnMessageReceived;
    public static void SendMessage(MessageObjectBlueprint.messageObject messageObject)
    {
        OnMessageReceived?.Invoke(messageObject);
    }
}