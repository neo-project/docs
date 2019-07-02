# Metodo validateaddress

Verifica che l'indirizzo sia un indirizzo NEO corretto.

## Descrizione del parametro

address: indirizzo.

## Esempio

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i"],
  "id": 1
}
```

Corpo della risposta:

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

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["152f1muMCNa7goXYhYAQC61hxEgGacmncB"],
  "id": 1
}
```

Corpo della risposta:

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
