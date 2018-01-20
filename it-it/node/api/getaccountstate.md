# Metodo getaccountstate

Interroga l'account sulle informazioni degli asset, in base all'indirizzo dell'account.

## Descrizione del Parametro

Indirizzo dell'account: Una stringa lunga 34-bit che inizia con A, come AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz.

## Esempio

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "getaccountstate",
  "params": ["AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz"],
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
        "script_hash": "1179716da2e9523d153a35fb3ad10c561b1e5b1a",
        "frozen": false,
        "votes": [],
        "balances": [
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "94"
            }
        ]
    }
}
```

Descrizione della Risposta:

Script_hash: Scipt hash del contratto; Tutti gli account in NEO sono account di contratto

Frozen: Determina se l'account è congelato

Votes: Interroga la quantità di NEO usati per votare su quell'indirizzo

Balances: Saldo degli asset in quell'indirizzo

Asset: ID dell'asset

Value: Quantità di Asset
