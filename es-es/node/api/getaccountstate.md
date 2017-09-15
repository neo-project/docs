# Método Getaccountstate

Devuelve el estado de la cuenta.


## Descripción de los parámetros

cuenta: Dirección de la cuenta. 


## Ejemplo de llamada


http://node:10332?jsonrpc=2.0&method=getaccountstate&params=["AVKUw1BH2gWxjhcJRrNRSPGcSBGuXnMhe2"]&id=1


Petición:
```json
{
	"jsonrpc": "2.0",
	"method": "getaccountstate",
	"params": ["AVKUw1BH2gWxjhcJRrNRSPGcSBGuXnMhe2"],
	"id": 1
}
```


Respuesta:
```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "script_hash": "8d21e9338c3307f963ae3a9f609ae124edfb9394",
        "frozen": false,
        "votes": [],
        "balances": [
            {
                "asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "99998801"
            },
            {
                "asset": "602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "1540.974168"
            },
            {
                "asset": "0f0ac3e50daa9a744f0b86db09e7cf025bc1f4e065369de6353134fd92c517cf",
                "value": "5"
            }
        ]
    }
}

```
