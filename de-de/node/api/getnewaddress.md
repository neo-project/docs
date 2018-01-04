# getnewaddress Methode

Generiert eine neue Adresse

> [!Anmerkung]
> Sie müssen die Wallet im NEO-CLI öffnen, bevor Sie diesen Befehl ausführen können.

## Beispiel

Anfrage：

```json
{
  "jsonrpc": "2.0",
  "method": "getnewaddress",
  "params": [],
  "id": 1
}
```

Antwort：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AVHcdW3FGKbPWGHNhkPjgVgi4GGndiCxdo"
}
```

Antwortbeschreibung:

Gibt die neu erzeugte Adresse aus.
