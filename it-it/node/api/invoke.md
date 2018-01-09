# Metodo invoke 

Restituisce il risultato dopo a uno smart contract a scripthash con i parametri specificati.

> [!Nota]
>
> This method is to test your VM script as if they were ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.

## Desrizione del parametro

scripthash: Smart contract scripthash

params: Il parametro passato allo smart contract

## Esempio

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "invoke",
  "params": [
"dc675afc61a7c0f7b3d2682bf6e1d8ed865a0e5f",
[
  {
    "type": "String",
    "value": "name"
  },
  {
    "type":"Boolean",
    "value": false
  }
]
  ],
  "id": 1
}
```

Corpo della risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "2.489",
        "stack": [
            {
                "type": "ByteArray",
                "value": "576f6f6c6f6e67"
            }
        ]
    }
}
```
