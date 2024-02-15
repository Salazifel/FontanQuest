using System;
using StompSharp;
 
class Program
{
    static void Main()
    {
        // Set the STOMP broker URL
        string brokerUri = "ws://your-stomp-broker-url";
 
        // Create a new StompClient
        var stompClient = new StompClient(brokerUri);
 
        // Connect to the STOMP broker
        stompClient.Connected += (sender, e) =>
        {
            Console.WriteLine("Connected to STOMP broker");
 
            // Send a STOMP message to a specific destination (e.g., a topic)
            string destination = "/topic/example";
            string messageBody = "Hello, STOMP!";
            stompClient.Send(destination, messageBody);
        };
 
        // Handle received STOMP messages
        stompClient.MessageReceived += (sender, e) =>
        {
            Console.WriteLine($"Received message: {e.Message.Body}");
        };
 
        // Connect to the STOMP broker
        stompClient.Connect();
 
        // Keep the console application running
        Console.ReadLine();
 
        // Disconnect from the STOMP broker when done
        stompClient.Disconnect();
    }
}