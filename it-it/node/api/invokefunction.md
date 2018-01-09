# Metodo invokefunction

Restituisce il risultato dopo la chiamata di uno smart contract a scripthash con le date operazioni e parametri.

> [!Nota]
>
> Questo metodo è per testare il tuo script VM come se fosse stato eseguito sulla blockchain in quel momento. Questa chiamata RPC non ha alcun effetto sulla blockchain in alcun modo.

## Descrizione del parametro

scripthash: Smart contract scripthash

operation: Il nome dell'operazione (string)

params: I parametri da passare nell'operazione dello smart contract

## Esempio

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "bfc469dd56932409677278f6b7422f3e1f34481d"
      }
    ]
  ],
  "id": 3
}
```

Corpo della risposta:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "state": "HALT, BREAK",
        "gas_consumed": "0.338",
        "stack": [
            {
                "type": "ByteArray",
                "value": "00e1f505"
            }
        ]
    }
}
```
