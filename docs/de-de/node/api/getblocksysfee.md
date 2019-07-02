# getblocksysfee Methode

Gibt die Systemgebühren eines Blocks aus, basierend auf dem Index des Blocks

## Parameter Beschreibung

index： Block Index

## Beispiel

Anfrage：

```json
{
  "jsonrpc": "2.0",
  "method": "getblocksysfee",
  "params": [1005434],
  "id": 1
}
```

Antwort:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "195500"
}
```

Antwortbeschreibung：

Die Systemgebühren des Blocks in GAS