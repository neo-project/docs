# Getrawmempool Methode

Geeft de lijst van nog niet bevestigde transacties in de memory pool.

## Voorbeeld

Request tekst:

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
   "id": 1
}
```

Response tekst:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

Dit zijn de nog niet bevestigde transacties die zijn ontvangen door nodes, zoals transacties met nog nul bevestigingen.
