# dumpprivkey Methode

Exportiert den privaten Schlüssel der angegebenen Adresse

> [!Anmerkung]
> Sie müssen die Wallet im NEO-CLI öffnen, bevor Sie diesen Befehl ausführen können.

## Parameter Beschreibung

Address: Um die Adresse eines privaten Schlüssels zu exportieren, muss es sich um die Standardadresse des Schlüssels handeln

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "dumpprivkey",
  "params": ["ASMGHQPzZqxFB2yKmzvfv82jtKVnjhp1ES"],
  "id": 1
}
```

Antwort:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "L3FdgAisCmV******************************9XM65cvjYQ1"
}
```

Antwortbeschreibung:
Gibt den privaten Schlüssel der Standardadresse aus.
