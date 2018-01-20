# Metodo getnewaddress

Crea un nuovo indirizzo.

> [!Nota]
> È necessario aprire il wallet nel nodo NEO-CLI prima di eseguire questo comando.

## Esempio

Corpo della richiesta：

```json
{
  "jsonrpc": "2.0",
  "method": "getnewaddress",
  "params": [],
  "id": 1
}
```

Corpo della risposta：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AVHcdW3FGKbPWGHNhkPjgVgi4GGndiCxdo"
}
```

Descrizione della risposta:

Restituisce l'indirizzo appena creato.
