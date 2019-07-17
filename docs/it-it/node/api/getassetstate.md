# Metodo getassetstate 			


Interroga le informazioni sull'asset, in base al numero di asset specificato. 

## Descrizione del parametro

Asset_id: Asset ID (identificatore dell'asset), che è l'ID della transazione di RegistTransaction quando l'asset è registrato.

Per NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

Per GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

Gli ID degli asset rimanenti possono essere interrogati tramite il comando `list asset` in [Comando CLI](../cli.md) o nel Browser della Block Chain.

## Esempio		

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "getassetstate",
  "params": ["c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b"],
  "id": 1
}
```

Corpo della risposta:

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
