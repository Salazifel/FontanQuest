using System.Collections;
using UnityEngine;
using NativeWebSocket;
using System;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class wsClient : MonoBehaviour
{
    WebSocket websocket;

    string apiKey = "3e807556-9d3e-4fbc-9913-60e84d664b20";
    string tenantId = "fau";


    async void Start()
    {

        websocket = new WebSocket("wss://api-02.fitrockr.com/ws/websocket");

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
            SendConnectFrame();
        };

        websocket.OnMessage += (bytes) =>
        {
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            //Debug.Log("Received message: " + message);

            DeserializeMessage(message);
            // Basic parsing to identify the CONNECTED frame.
            if (message.StartsWith("CONNECTED"))
            {
                Debug.Log("STOMP Connected successfully.");
                SendSubscribeFrame();
            }
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
        };

        await websocket.Connect();
    }

    void SendConnectFrame()
    {
        // Adjust the header names and values according to your server's authentication requirements
        string stompConnectFrame = $"CONNECT\naccept-version:1.2\nhost:api-02.fitrockr.com\nX-API-Key:{apiKey}\nX-Tenant:{tenantId}\n\n\0";
        websocket.SendText(stompConnectFrame);
        Debug.Log("Sent CONNECT frame with authentication headers");
    }


    void SendSubscribeFrame()
    {
        string stompSubscribeFrame = $"SUBSCRIBE\nid:sub-0\ndestination:/topic/live/{tenantId}\n\n\0";
        websocket.SendText(stompSubscribeFrame);
        Debug.Log("Sent SUBSCRIBE frame");
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        websocket.DispatchMessageQueue();

#endif
    }

    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }





    // ----------------------------------------------

void DeserializeMessage(string stompMessage)
{
    // Split the message on the first occurrence of a double newline, which separates STOMP headers from the body
    string[] parts = stompMessage.Split(new string[] { "\n\n" }, 2, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length < 2)
    {
        Debug.LogError("Received message does not contain a valid JSON payload.");
        return;
    }

    string jsonPayload = parts[1]; // The JSON part is after the first blank line
    //Debug.Log("JSON Payload: " + jsonPayload);

    //Debug.Log(SmartWatchData.pastHeartActivity.ToString());
    CalcPastData();

    try
    {
        LiveMessage liveMessage = JsonUtility.FromJson<LiveMessage>(jsonPayload);

        // Now you can access the data in liveMessage
        //Debug.Log($"Data Type: {liveMessage.liveData.dataType}, Value: {liveMessage.liveData.value}");
        if (liveMessage.liveData != null)
        {
            currentGarminTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(liveMessage.liveData.timestamp);
            
            switch (liveMessage.liveData.dataType)
            {
                case "HR":
                    SmartWatchData.heartRate = liveMessage.liveData.value;
                    //Debug.Log(SmartWatchData.heartRate.ToString());
                    break;

                case "STEPS":
                    SmartWatchData.steps = liveMessage.liveData.value;
                    SmartWatchData.stepTimeStamp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(liveMessage.liveData.timestamp);
                    //Debug.Log(SmartWatchData.steps.ToString());
                    break;
                
                case "accelerometer":
                    SmartWatchData.accelerometerSW.setValues(0,0,0);
                    break;
                case "INTENSITY_MINUTES":
                    SmartWatchData.intensity_minutes = liveMessage.liveData.value;
                    break;

                default:
                    //Debug.LogWarning($"Unknown data type: {liveMessage.liveData.dataType}");
                    break;
            }
        }
    }
    catch (Exception ex)
    {
        Debug.LogError("Error parsing JSON: " + ex.Message);
    }
}


// Getting the booleans of heartrate change and step count change

private Dictionary<DateTime, double> StepCountLog = new Dictionary<DateTime, double>();
private DateTime currentGarminTime = new DateTime(2040, 1,1,0,0,0, DateTimeKind.Utc);

public int monitorLastStepSeconds = 3;

void CalcPastData()
{
    DateTime tmpDateTime = currentGarminTime;
    DateTime tmpDateTime2 = currentGarminTime;

    if (SmartWatchData.stepTimeStamp >= tmpDateTime.AddSeconds(- monitorLastStepSeconds))
    {
        SmartWatchData.pastStepActivitiy = true;
    }
    else
    {
        SmartWatchData.pastStepActivitiy = false;
    }

    if (SmartWatchData.stepTimeStamp >= tmpDateTime2.AddSeconds(- (monitorLastStepSeconds * 2 )))
    {
        SmartWatchData.pastStepActivitiy6sec = true;
    }
    else
    {
        SmartWatchData.pastStepActivitiy6sec = false;
    }

    if (SmartWatchData.heartRate >= 90)
    {
        SmartWatchData.pastHeartActivity = true;
        SmartWatchData.pastHeartActivity6sec = true;
    }
    else
    {
        SmartWatchData.pastHeartActivity = false;
        SmartWatchData.pastHeartActivity6sec = false;
    }
}
 

[Serializable]
public class LiveMessage
{
    public int version;
    public string tenant;
    public string command;
    public LiveDataEvent liveData;
    public LiveDevice liveDevice;
}

[Serializable]
public class LiveDataEvent
{
    public string identifier;
    public string tenant;
    public string dataType;
    public string macAddress;
    public double value; // Can be double, boolean, etc.
    public long timestamp;
}

[Serializable]
public class LiveDevice
{
    // If liveDevice can be null as indicated by your JSON, ensure this class structure is correct
    // and consider handling cases where liveDevice is null in your code.
    public string deviceId;
    public string deviceName;
    public string trackerAddress;
    public string trackerName;
    public string userId;
    public string userName;
    public string trackerFirmware;
    public string trackerBattery;
    public bool active;
}


}
