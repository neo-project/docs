# Metodo getversion

Restituisce le informazioni sulla versione del nodo interrogato.

## Esempio

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 3
}
```

Corpo della risposta:

```json
{
  "jsonrpc": "2.0",
  "id": 3,
  "result": {
      "port": 0,
      "nonce": 156443862,
      "useragent": "/NEO:2.3.5/"
  }
}
```
