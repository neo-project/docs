# Getbestblockhash Methode

Geeft de hash van het hoogste block in de hoofdketen weer. (Hoogste block = laatst geaccepteerde block)

## Voorbeeld

Request tekst:

```json
{
   "jsonrpc": "2.0",
   "method": "getbestblockhash",
   "params":[],
   "id": 1
}
```

Response tekst:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

Response Omschrijving:

Result: de hash van het hoogste block in de hoofdketen.
