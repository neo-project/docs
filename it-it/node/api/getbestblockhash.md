# Metodo getbestblockhash

Restituisce l'hash del blocco più alto nella chain principale.

## Esempio

Corpo della richiesta:

```json
{
   "jsonrpc": "2.0",
   "method": "getbestblockhash",
   "params":[],
   "id": 1
}
```

Corpo della risposta:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

Descrizione della risposta:

Result: L'hash del blocco più alto nella chain principale.
