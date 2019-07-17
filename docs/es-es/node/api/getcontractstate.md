# Método Getcontractstate

Devuelve el estado del contrato.

## Descripción de los parámetros

script hash: el hash del script del contrato.

## Ejemplo de llamada

http://node:10332?jsonrpc=2.0&method=getcontractstate&params=["42d94fc9e85552cde166c4c1b838374c3b776492"]&id=1

Petición:

```json
{
	"jsonrpc": "2.0",
	"method": "getcontractstate",
	"params": ["42d94fc9e85552cde166c4c1b838374c3b776492"],
	"id": 1
}
```


Respuesta:

``` json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "code": {
            "hash": "98f56b5dc40650da5c1ead5894979e0c2fe4bcd6",
            "script": "00c56b616168164e656f2e53746f726167652e476574436f6e746578740548656c6c6f05576f726c64615272680f4e656f2e53746f726167652e50757461616c7566",
            "parameters": [],
            "returntype": "Void"
        },
        "storage": true,
        "name": "SmartContract",
        "code_version": "2.0",
        "author": "SmartContract",
        "email": "smartcontract@smartcontract.org",
        "description": "SmartContract - Hello World!"
    }
}

```
