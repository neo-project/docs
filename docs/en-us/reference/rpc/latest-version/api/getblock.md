# getblock Method

Returns the corresponding block information according to the specified hash or index.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* hash | index: Block hash string or block index (i.e. block height = number of blocks - 1).

* verbose: Optional. The default value is 0. 
  * When verbose is 0, serialized information of the block is returned in a hexadecimal string. If you need the detailed information, use SDK for deserialization. 
  * When verbose is 1, detailed information of the block is returned in Json format.

## Example

**Example 1 - invoke with block hash**

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["0xdf17b40c5627a45e83d61b286a6d6d14859136621760d0a5b58dd59d18fd53d4"],
  "id": 1
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "0000000059ff9a2ff0861bda1abf89e07a3d248def4cf4fd4493c23d32bcf9bc741b92867ac9948cd23059eb880182e443b5eb3c75ec68404d01ff7b3c8f85a6651a6aefdc0687a06f0100001027000057c8f7a5b8d6758f18fb906eaf03f007da0a9f2601420c4026a4ba2eba339629ce40817053625dc315c294cea30863bb56d15a7fb2f3445d615fa0d201b940e3df662c71b200e355b8193e746b36143dcb9de3669962fc852b110c21021e1563aa32a5191ff7198e8c28ef02a8c6b33aecf326f5b32c6a620138d4201b110b413073b3bb0100f86bb4ae521c7046"
}
```

Request body:

verbose = 1，returns the result in JSON format:

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["0xdf17b40c5627a45e83d61b286a6d6d14859136621760d0a5b58dd59d18fd53d4", 1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xdf17b40c5627a45e83d61b286a6d6d14859136621760d0a5b58dd59d18fd53d4",
        "size": 222,
        "version": 0,
        "previousblockhash": "0x86921b74bcf9bc323dc29344fdf44cef8d243d7ae089bf1ada1b86f02f9aff59",
        "merkleroot": "0xef6a1a65a6858f3c7bff014d4068ec753cebb543e4820188eb5930d28c94c97a",
        "time": 1578946201308,
        "index": 10000,
        "nextconsensus": "NTv8iuL3yf4eiskKWWrtXLq9fKrX6LNGrG",
        "witnesses": [
            {
                "invocation": "DEAmpLouujOWKc5AgXBTYl3DFcKUzqMIY7tW0Vp/svNEXWFfoNIBuUDj32YscbIA41W4GT50azYUPcud42aZYvyF",
                "verification": "EQwhAh4VY6oypRkf9xmOjCjvAqjGszrs8yb1syxqYgE41CAbEQtBMHOzuw=="
            }
        ],
        "consensus_data": {
            "primary": 0,
            "nonce": "46701c52aeb46bf8"
        },
        "tx": [],
        "confirmations": 129368,
        "nextblockhash": "0xe5ee6885a736e194c14bb020dca34bd6effe4280fbaec4542e41e4bebd8d4870"
    }
}
```

**Example 2 - invoke with block index**

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [10000],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0", 
    "id": "1", 
    "result": "0000000059ff9a2ff0861bda1abf89e07a3d248def4cf4fd4493c23d32bcf9bc741b92867ac9948cd23059eb880182e443b5eb3c75ec68404d01ff7b3c8f85a6651a6aefdc0687a06f0100001027000057c8f7a5b8d6758f18fb906eaf03f007da0a9f2601420c4026a4ba2eba339629ce40817053625dc315c294cea30863bb56d15a7fb2f3445d615fa0d201b940e3df662c71b200e355b8193e746b36143dcb9de3669962fc852b110c21021e1563aa32a5191ff7198e8c28ef02a8c6b33aecf326f5b32c6a620138d4201b110b413073b3bb0100f86bb4ae521c7046"
}
```

Request body:

Verbose = 1, returns the result in JSON format:

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [10000, 1],
  "id": 1
}
```

Response body:

```
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xdf17b40c5627a45e83d61b286a6d6d14859136621760d0a5b58dd59d18fd53d4",
        "size": 222,
        "version": 0,
        "previousblockhash": "0x86921b74bcf9bc323dc29344fdf44cef8d243d7ae089bf1ada1b86f02f9aff59",
        "merkleroot": "0xef6a1a65a6858f3c7bff014d4068ec753cebb543e4820188eb5930d28c94c97a",
        "time": 1578946201308,
        "index": 10000,
        "nextconsensus": "NTv8iuL3yf4eiskKWWrtXLq9fKrX6LNGrG",
        "witnesses": [
            {
                "invocation": "DEAmpLouujOWKc5AgXBTYl3DFcKUzqMIY7tW0Vp/svNEXWFfoNIBuUDj32YscbIA41W4GT50azYUPcud42aZYvyF",
                "verification": "EQwhAh4VY6oypRkf9xmOjCjvAqjGszrs8yb1syxqYgE41CAbEQtBMHOzuw=="
            }
        ],
        "consensus_data": {
            "primary": 0,
            "nonce": "46701c52aeb46bf8"
        },
        "tx": [],
        "confirmations": 129343,
        "nextblockhash": "0xe5ee6885a736e194c14bb020dca34bd6effe4280fbaec4542e41e4bebd8d4870"
    }
}
```

