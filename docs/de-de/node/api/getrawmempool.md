# Getrawmempool Methode

Holt die Liste der noch nicht bestätigten Transaktionen aus dem Speicher.

## Beispiel

Anfrage:

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
   "id": 1
}
```

Antwort:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

Dies sind die noch nicht bestätigten Transaktionen, die die Node empfangen hat.
