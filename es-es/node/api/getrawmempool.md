# Método Getrawmempool 

Obtiene una lista de transacciones no reconocidas en memoria.

## Ejemplo de llamada

Petición

```json
{
	"jsonrpc": "2.0",
	"method": "getrawmempool",
	"params":[],
	"id": 1
}
```

Respuesta:

```json
{
	"jsonrpc": "2.0",
	"id": 1,
	"result": [
		"B4534f6d4c17cda008a76a1968b7fa6256cd90ca448739eae8e828698ccc44e7"
	]
}
```

Éstas son las transacciones indeterminadas recibidas por el nodo, es decir, transacciones cero-confirmadas.
