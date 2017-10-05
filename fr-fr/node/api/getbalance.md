# Méthode getbalance

Retourne le solde de l'actif correspondant dans le porte-feuille basé sur l'ID de l'asset

>[!Note]
> Vous allez devoir ouvrir un porte-feuille dans un noeud Neo-CLI avant d'executer cette commande.

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
  "method": "getbalance",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "id": 1
}
```

Reponse :

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
  "Balance": "1.01",
  "Confirmed": "1.01"
  }
}
```

Description de la réponse :

balance : Le solde actuelle de l'actif dans le porte-feuille.

confirmed : le montant exact de l'actif dans le porte-feuille où il y a seulement les montants confirmés qui peuvent être utilisés dans un transfert.

Les valeurs "balance" et "confirmed" peuvent ne pas être égales. Cela arrive quand il y a une transaction de sortie du porte-feuille et que l'échange n'a pas encore été confirmé. Du coup la valeur de "confirmed" peut être plus basse que celle de "balance". Une fois la transaction confirmée, les deux valeurs seront à nouveau égales.