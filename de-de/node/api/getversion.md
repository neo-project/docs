# Getversion Methode

Gibt die Versionsinformationen der abgefragten Node aus.

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 3
}
```

Antwort:

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