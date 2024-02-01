import requests

url = "https://api-02.fitrockr.com/v1/live/control/ping HTTP/1.1"
headers = {
    "Content-Type": "application/json",
    "X-Tenant": "fau",
    "X-API-Key": "3e807556-9d3e-4fbc-9913-60e84d664b20",
    "Host": "localhost:8080"
}

response = requests.get(url, headers=headers)

if response.status_code == 200:
    print(response.text)
else:
    print(f"Request failed with status code {response.status_code}")