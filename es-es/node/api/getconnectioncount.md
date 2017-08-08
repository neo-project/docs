# Método Getconnectioncount

Devuelve el número de conexiones del nodo. 

## Ejemplo de llamada

Petición

http://nodo.net:10332?jsonrpc=2.0&method=getconnectioncount&params=[]&id=1

```json
{
	"jsonrpc": "2.0",
	"method": "getconnectioncount",
	"params":[],
	"id": 1
}
```

Respuesta:

```json
{
	"jsonrpc": "2.0",
	"id": 1,
	"result": 10
}
```
