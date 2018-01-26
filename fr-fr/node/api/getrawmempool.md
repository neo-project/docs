# Méthode getrawmempool

Obtient le nombre de transaction non-confirmée en mémoire.

## Exemple

Requète :

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
   "id": 1
}
```

Réponse :

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

On retrouve les transactions non-confirmées reçues par les noeuds, par exemple, les transactions avec zéro confirmations.