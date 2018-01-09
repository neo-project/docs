# Metodo invokescript

Restituisce il risultato dopo aver passato lo script attraverso la VM.

> [!Nota
>
> Questo metodo è per testare il tuo script VM come se fosse stato seguiti sulla blockchain in quel momento. This RPC call does not affect the blockchain in any way.

## Parameter Description

script: A script runnable by the VM. This is the same script that is carried in InvocationTransaction

## Example

Corpo della richiesta:

```json
{
  "jsonrpc": "2.0",
  "method": "invokescript",
  "params": ["00046e616d656711c4d1f4fba619f2628870d36e3a9773e874705b"],
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
        "gas_consumed": "0.125",
        "stack": [
            {
                "type": "ByteArray",
                "value": "5265642050756c736520546f6b656e20332e312e34"
            }
        ]
    }
}
```
