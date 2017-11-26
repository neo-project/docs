# Getstorage Methode

Gibt den gespeicherten Wert entsprechend dem Contract Script Hash und dem gespeicherten Schlüssel zurück.

## Parameter Beschreibung

Script_hash: Contract Script Hash

## Beispiel

Anfrage:

```json
{
  "jsonrpc": "2.0",
  "method": "getstorage",
  "params": ["03febccf81ac85e3d795bc5cbd4e84e907812aa3", "5065746572"],
  "id": 15
}
```

Antwort:

```json
{
  "jsonrpc": "2.0",
  "id": 15,
  "result": "4c696e"
}
```

