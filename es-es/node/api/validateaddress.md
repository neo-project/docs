# Método Validateaddress

Devuelve el estado de la dirección

## Descripción de los parámetros

address: dirección, string

## Ejemplo de llamada

http://node:10332?jsonrpc=2.0&method=validateaddress&params=["AVKUw1BH2gWxjhcJRrNRSPGcSBGuXnMhe2"]&id=1

Petición:

```json

{
	"jsonrpc": "2.0",
	"method": "validateaddress",
	"params": ["AVKUw1BH2gWxjhcJRrNRSPGcSBGuXnMhe2"],
	"id": 1
}
```

Respuesta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "AVKUw1BH2gWxjhcJRrNRSPGcSBGuXnMhe2",
        "isvalid": true
    }
}
```
