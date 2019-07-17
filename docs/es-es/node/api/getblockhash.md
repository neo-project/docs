# Método Getblockhash

Devuelve el valor hash del bloque en función del índice especificado.   

## Descripción de parámetros.

bloque: bloque especificado

## Ejemplo de llamada

Petición:

http://nodo.net:10332?jsonrpc=2.0&method=getblockhash&params=[100]&id=1

```json
{
	"jsonrpc": "2.0",
	"method": "getblockhash",
	"params": [100],
	"id": 1
}
```

Respuesta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "a1d2b1548d4a93fe9109a524602818d39718cb2a76274df91fb38a7f87429555"
}
```
