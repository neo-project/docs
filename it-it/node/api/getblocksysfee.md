# Metodo getblocksysfee

Restituisce le commissioni di sistema del blocco, in base all'indice specificato.

## Descrizione del Parametro

index：Indice del Blocco

## Esempio

Corpo della richiesta：

```json
{
  "jsonrpc": "2.0",
  "method": "getblocksysfee",
  "params": [1005434],
  "id": 1
}
```

Corpo della Risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "195500"
}
```

Descrizione della risposta：

result：Le commissioni di sistema del blocco, in unità NeoGas.
