import requests

resp = requests.get('https://localhost:44378/api/v1/advertisements', verify=False)
data = resp.json()
print(data)

