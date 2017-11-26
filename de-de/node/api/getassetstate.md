# Getassetstate Methode			

Fragt die Assetinformationen zu einer bestimmten Assetnummer ab.

## Parameter Beschreibung

Asset_id: Die Asset-ID (asset identifier), ist die Transaktions-ID der RegistTransaction mit der das Asset registriert wurde.

Für NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

Für GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

Die übrigen Asset-IDs können über den `list asset` Befehl in [CLI Command](../cli.md) oder über einen Blockchainbrowser abgefragt werden.

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "getassetstate",
  "params": ["c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b"],
  "id": 1
}
```

Antwort:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "id": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
        "type": "SystemShare",
        "name": [
            {
                "lang": "zh-CN",
                "name": "NEO"
            },
            {
                "lang": "en",
                "name": "NEO"
            }
        ],
        "amount": "100000000",
        "available": "100000000",
        "precision": 0,
        "owner": "00",
        "admin": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
        "issuer": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt",
        "expiration": 2000000,
        "frozen": false
    }
}
```

