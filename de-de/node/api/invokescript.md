# Invokescript Methode

Gibt das Ergebnis aus, nachdem ein Script durch die VM gelaufen ist.

**Note: Diese Methode lässt Sie Ihre VM Scripte unter Real-Bedingungen testen. Der RPC Call beeinflusst die Blockchain nicht.**

## Parameter Beschreibung

script: Ein Script, das von der VM ausgeführt wird. Dieses Script wird auch durch "InvocationTransaction" übertragen.

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "invokescript",
  "params": ["00046e616d656711c4d1f4fba619f2628870d36e3a9773e874705b"],
  "id": 3
}
```

Antwort:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.125",
        "stack": [
            {
                "type": "ByteArray",
                "value": "5265642050756c736520546f6b656e20332e312e34"
            }
        ]
    }
}
```