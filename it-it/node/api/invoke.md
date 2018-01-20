# Metodo invoke 

Restituisce il risultato dopo la chiamata a uno smart contract in scripthash con i parametri specificati.

> [!Nota]
>
> Questo metodo è per testare il tuo script della macchina virtuale (VM) come se fosse stato eseguito sulla blockchain in quel momento. Questa chiamata RPC, non ha in alcun modo effetto sulla blockchain.

## Desrizione del parametro

scripthash: Smart contract scripthash

params: I parametri da passare allo smart contract

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
