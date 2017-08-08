# Método Getblockcount

Devuelve el numero de bloques de la cadena principal.

## Ejemplo de llamada

Petición

http://nodo.net:10332?jsonrpc=2.0&method=getblockcount&params=[]&id=1

```json
{
	"jsonrpc": "2.0",
	"method": "getblockcount",
	"params":[],
	"id": 1
}
```

Respuesta:

```json
{
	"jsonrpc": "2.0",
	"id": 1,
	"result": 991991
}
```
