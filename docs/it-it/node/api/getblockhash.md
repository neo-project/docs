# Metodo getblockhash

Restituisce il valore hash del blocco corrispondente in base all'indice specificato.

## Descrizione del Parametro

Index: Indice del Blocco (altezza del blocco)

## Esempio

Corpo della richiesta:

```json
{
   "jsonrpc": "2.0",
   "method": "getblockhash",
   "params": [10000],
   "id": 1
}
```

Corpo della risposta:

```json
{
   "jsonrpc": "2.0",
   "id": 1,
   "result": "4c1e879872344349067c3b1a30781eeb4f9040d3795db7922f513f6f9660b9b2"
}
```
