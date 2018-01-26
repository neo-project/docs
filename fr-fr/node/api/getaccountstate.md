# Méthode getaccountstate

Demande les informations sur les actifs d'un compte selon l'adresse du compte indiquée.

## Paramètres de la méthode

address : un string de 34 bit de longueur commençant par A telle que AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz.

## Exemple

Requète :

```json
{
  "jsonrpc": "2.0",
  "method": "getaccountstate",
  "params": ["AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz"],
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

Description de la réponse :

script_hash : Hash du script de contrat; Tous les comptes NEO sont aussi des comptes de contrat.

frozen : Détermine si le compte est gelé.

votes : Demande le montant de NEO sur cette adresse utilisé pour voter.

balances : Solde des actifs sur cette adresse.

asset : ID de l'actif.

value : nombre d'actifs.