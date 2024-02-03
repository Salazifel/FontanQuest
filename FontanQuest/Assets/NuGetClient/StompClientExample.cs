using UnityEngine;

public class StompClientExample : MonoBehaviour
{
    private StompClient stompClient;

    void Start()
    {
        // Initialize Stomp client
        stompClient = new StompClient("ws://localhost:3000");
        Debug.Log("Stomp client initialized.");

        // Connect to Stomp server
        stompClient.Connect();
        Debug.Log("Stomp client connecting...");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar pressed. Sending Stomp message.");

            // Check WebSocket state
            if (stompClient.webSocket != null)
            {
                Debug.Log($"WebSocket state: {stompClient.webSocket.ReadyState}");
            }

            // Example: Sending a Stomp message
            stompClient.SendMessage("/topic/live-event-stream", "Hello Stomp!");
        }
    }

    void OnDestroy()
    {
        // Disconnect from Stomp server when the script is destroyed
        stompClient.Disconnect();
        Debug.Log("Stomp client disconnected.");
    }
}
