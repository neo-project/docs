# Méthode gettxout

Retourne l'information de sortie de la transaction correspondante basé sur la valeur de hashage spécifiée et sur son index.

## Paramètres de la méthode

txid : ID de la transaction.

n: L'index de la sortie de la transaction pour être obtenu dans la transaction (commence à 0).

## Exemple

Requète :

```json
{
   "jsonrpc": "2.0",
   "method": "gettxout",
   "params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657", 0],
   "id": 1
}
```

Réponse :

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": {
     "N": 0,
     "Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
     "Value": "2950",
     "Address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
   }
}