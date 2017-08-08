# Método Getrawtransaction

Devuelve la información de la correspondiente transacción en función del valor hash de la transacción especificado. 

## Descripción de parámetros

Txid: id. de transacción.

Verbose: Opcional.

El valor Verbose por defecto es 0. Cuando el valor es 0, la inforación del bloque devuelta está serializada. Se representa con una cadena hexadecimal. Si nececitas información detallada, necesitas llamar al SDK para la desserialización. Cuando el valor de Verbose es 1 la información del bloque se devuelve en una cadena en formato JSON.


## Ejemplo de llamada

http://node:10332?jsonrpc=2.0&method=getrawtransaction&params=["863f530b60f17f71dbdc7d8f7d1d177ef705ce5656a3ad349957e4e00923731e",1]&id=1

Petición:

```json
{
	"jsonrpc": "2.0",
	"method": "getrawtransaction",
	"params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657"],
	"id": 1
}
```

Respuesta:

```json
{
	"jsonrpc": "2.0",
	"id": 1,
	"result": "80000001195876cb34364dc38b730077156c6bc3a7fc570044a66fbfeeea56f71327e8ab0000029b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc500c65eaf440000000f9a23e06f74cf86b8827a9108ec2e0f89ad956c9b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50092e14b5e00000030aab52ad93f6ce17ca07fa88fc191828c58cb71014140915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58232103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"
}
```

Petición:

Verbose = 1, el valor se devuelve el formato JSON.

```json
{
	"jsonrpc": "2.0",
	"method": "getrawtransaction",
	"params": ["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657", 1],
	"id": 1
}
```

Respuesta:


```json
{
	"jsonrpc": "2.0",
	"id": 1,
	"result": {
		"Txid": "f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657",
		"Size": 262,
		"Type": "ContractTransaction",
		"Version": 0,
		"Attributes":[],
		"Vin": [
			{
				"Txid": "abe82713f756eaeebf6fa6440057fca7c36b6c157700738bc34d3634cb765819"
				"Vout": 0
			}
	],
		"Vout": [
			{
				"N": 0,
				"Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
				"Value": "2950",
				"Address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
			},
			{
				"N": 1,
				"Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
				"Value": "4050",
				"Address": "ALDCagdWUVV4wYoEzCcJ4dtHqtWhsNEEaR"
			}
	],
			"Sys_fee": "0",
			"Net_fee": "0",
			"Scripts": [
			{
				"Invocation": "40915467ecd359684b2dc358024ca750609591aa731a0b309c7fb3cab5cd0836ad3992aa0a24da431f43b68883ea5651d548feb6bd3c8e16376e6e426f91f84c58"
				"Verification": "2103322f35c7819267e721335948d385fae5be66e7ba8c748ac15467dcca0693692dac"
			
	],
			"Blockhash": "9c814276156d33f5dbd4e1bd4e279bb4da4ca73ea7b7f9f0833231854648a72c",
			"Confirmations": 144,
			"Blocktime": 1496719422
	}
}
```
