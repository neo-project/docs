# validateaddress Methode

Verifiziert, dass die angegebene Adresse eine gültige NEO-Adresse ist.

## Parameter Beschreibung

address: Addresse.

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i"],
  "id": 1
}
```

Antwort:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i",
        "isvalid": true
    }
}
```

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["152f1muMCNa7goXYhYAQC61hxEgGacmncB"],
  "id": 1
}
```

Antwort:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "152f1muMCNa7goXYhYAQC61hxEgGacmncB",
        "isvalid": false
    }
}
```



