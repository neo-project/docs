# Método Gettxout

Devuelve la información de la correspondiente transacción en función del valor hash de la transacción y del índice especificado.

## Descripción de parametros

Txid: id. de transación. <br>
N: El índice de la transación a obtener dentro de la transación. (empieza en 0)

## Ejemplo de llamada

Llamada:

```json
{
	"jsonrpc": "2.0",
	"method": "gettxout",
	"params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657", 0],
	"id": 1
}
```

Petición:

```json
{
	"jsonrpc": "2.0",
	"id": 1,
	"result": {
		"N": 0,
		"Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
		"Value": "2950",
		"Address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
	}
}
```
