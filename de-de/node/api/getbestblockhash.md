# Getbestblockhash Methode

Holt den Hashwert des höchsten Blocks der Blockchain.

## Beispiel

Anfrage:

```json
{
   "jsonrpc": "2.0",
   "method": "getbestblockhash",
   "params":[],
   "id": 1
}
```

Antwort:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

Antworterläuterung:

Result: Der Hash des höchsten Blocks der Blockchain