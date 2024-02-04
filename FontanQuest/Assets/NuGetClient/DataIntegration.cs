using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataIntegration : MonoBehaviour
{
    private string fitrockrApiKey = "3e807556-9d3e-4fbc-9913-60e84d664b20";
    private string tenantId = "fau"; 
    private string fitrockrApiUrl = "https://api.fitrockr.com"; 
    private void Start()
    {
        StartCoroutine(GetFitrockrData());
    }

    IEnumerator GetFitrockrData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(fitrockrApiUrl))
        {
            // Add X-Tenant header
            request.SetRequestHeader("X-Tenant", tenantId);

            // Add X-API-Key header
            request.SetRequestHeader("X-API-Key", fitrockrApiKey);

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                // Parse JSON response using JsonUtility or a JSON library
                string jsonResponse = request.downloadHandler.text;
                FitrockrData fitrockrData = JsonUtility.FromJson<FitrockrData>(jsonResponse);

                // Use fitrockrData in your game
                Debug.Log("Fitrockr Data: " + fitrockrData);
            }
            else
            {
                Debug.LogError("Fitrockr API request failed: " + request.error);
            }
        }
    }

    // Add data model class for FitrockrData if needed
    [System.Serializable]
    private class FitrockrData
    {
        // Define fields based on Fitrockr API response
        // Example: public string someField;
    }
}
