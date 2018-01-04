# Getaccountstate Methode

Fragt die Assetinformationen einer Adresse ab.

## Parameter Beschreibung

Account Addresse: Ein 34-bit langer String, der mit A beginnt, z.B. AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz.

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "getaccountstate",
  "params": ["AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz"],
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

Beschreibung der Antwort:

Script_hash: Contract Script Hash; Alle Accounts in NEO sind Contract Accounts.

Frozen: Bestimmt, ob der Account eingefroren ist. 

Votes: Fragt den Gesamtbetrag der vorhandenen NEO auf der Adresse die zum wählen benutzt worden ist ab.

Balance: Menge der Assets der Adresse

Asset: Asset ID

Value: Anzahl der Assets

