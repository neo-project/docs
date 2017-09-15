# Método Getblocksysfee

Devuelve la tarifa del bloque.

## Descripción de los parámetros

uint: bloque, entero unsigned.

## Ejemplo de llamada

http://node:10332?jsonrpc=2.0&method=getblocksysfee&params=[1000]&id=1


Petición:

```json
{
	"jsonrpc": "2.0",
	"method": "getblocksysfee",
	"params": [1000],
	"id": 1
}
```


Respuesta:

``` json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "5"
}
```
