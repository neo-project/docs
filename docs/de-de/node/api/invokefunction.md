# Invokefunction Methode

Gibt das Ergebnis nach dem Aufruf eines Smart Contracts mit gegebenen Operationen und Parametern aus.

**Anmerkung: Diese Methode lässt Sie Ihre VM Scripte unter Real-Bedingungen testen. Der RPC Call beeinflusst die Blockchain nicht.**

## Parameter Beschreibung

scripthash: Smart Contract Scripthash

operation: Der Operationsname (string)

params: Die Parameter, die an den Smart Contract übergeben werden.

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "invoke",
  "params": [
"dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f",
[
  {
    "type": "String",
    "value": "name"
  },
  {
    "type":"Boolean",
    "value": false
  }
]
  ],
  "id": 1
}
```

Antwort:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "2.489",
        "stack": [
            {
                "type": "ByteArray",
                "value": "576f6f6c6f6e67"
            }
        ]
    }
}
```