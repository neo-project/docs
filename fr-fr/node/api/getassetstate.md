# Méthode getassetstate

Demande les informations d'un actif selon l'ID de cet adresse spécifiée.

## Paramètre de la méthode

asset_id : ID de l'actif (l'identifiant de l'actif) qui est l'ID de la transaction du RegistTransaction lors de l'enregistrement de l'actif.

NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

Les IDs des actifs restant peuvent être demandés via la commande `list asset` de [la liste de commandes](../cli.md) ou dans l'explorateur de la blockchain.

## Exemple

Requète :

```json
{
  "jsonrpc": "2.0",
  "method": "getassetstate",
  "params": ["c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b"],
  "id": 1
}
```

Réponse :


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