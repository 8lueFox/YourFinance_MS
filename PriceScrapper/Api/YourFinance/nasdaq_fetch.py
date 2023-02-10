import http.client

conn = http.client.HTTPSConnection("api.nasdaq.com")

payload = ""

headers = { 'cookie': "" }

conn.request("GET", "/api/screener/stocks?tableonly=true&limit=25&offset=0&download=true", payload, headers)

res = conn.getresponse()
data = res.read()

f = open("nasdaq.txt", "a")
f.write(data.decode("utf-8"))
f.close()