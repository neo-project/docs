# Método Getbestblockhash

Devuelve el hash del bloque más alto de la cadena principal.

## Ejemplo de llamada:

**GET:**

http://node:10332?jsonrpc=2.0&method=getbestblockhash&params=[]&id=1

**POST:**

Petición

```json
{
	"jsonrpc": "2.0",
	"method": "getbestblockhash",
	"params":[],
	"id": 1
}
```

Respuesta:

```json
{
	"jsonrpc": "2.0",
	"id": 1,
	"result": "773dd2dae4a9c9275290f89b56e67d7363ea4826dfd4fc13cc01cf73a44b0d0e"
}
```

## Descripción de la respuesta:

Resultado: El valor hash del bloque más significativo de la cadena principal.
