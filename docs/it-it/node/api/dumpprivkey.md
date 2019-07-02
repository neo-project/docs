# Metodo dumpprivkey 

Esporta la chiave privata dell'indirizzo specificato.

> [!Nota]
> Aprire il wallet nel nodo NEO-CLI prima di eseguire questo comando.

## Descrizione del parametro

Indirizzo: Per esportare la chiave privata dall'indirizzo, l'indirizzo è richiesto come indirizzo standard.

## Esempio

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "dumpprivkey",
  "params": ["ASMGHQPzZqxFB2yKmzvfv82jtKVnjhp1ES"],
  "id": 1
}
```

Corpo della risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "L3FdgAisCmV******************************9XM65cvjYQ1"
}
```

Descrizione della risposta:

Restituisce la chiave privata dell'indirizzo standard.
