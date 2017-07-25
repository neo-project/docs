# Método Getbestblockhash

Obtiene el valor hash del segmento más alto de la blockchain.

## Ejemplo de llamada:

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

Resultado: El valor hash el bloque más significativos de la blockchain.
