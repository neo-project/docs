# Metodo Getrawmempool

Ottiene l'elenco delle transazioni non confermate in memoria.

## Esempio

Testo della richiesta:

```json
{
   "jsonrpc": "2.0",
   "method": "getrawmempool",
   "params":[],
   "id": 1
}
```

Testo della risposta:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": [
     "B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
   ]
}
```

Queste sono le transazioni non confermate ricevute dai nodi, cioè transazioni con zero conferme.
