# Méthode Getbestblockhash

Retourne le hash du plus grand bloc de la chaîne principale.

## Exemple

Requète :

```json
{
   "jsonrpc": "2.0",
   "method": "getbestblockhash",
   "params":[],
   "id": 1
}
```

Réponse :

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

Description de la réponse :

result : Le hash du plus grand bloc de la chaîne principale.