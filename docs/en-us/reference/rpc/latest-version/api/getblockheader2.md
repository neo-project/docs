# getblockheader Method

Returns the corresponding block header information according to the specified script hash.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* Index: Block index (block height) = Number of blocks - 1.

* verbose: Optional. The default value is 0. 
  * When verbose is 0, serialized information of the block is returned in a hexadecimal string. If you need the detailed information, use the SDK for deserialization. 
  * When verbose is 1, detailed information of the block is returned in Json format.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [6000, 0],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0", 
    "id": "1", 
    "result": "0000000020c213cb72392bd365e1e7e4ff9958e83761cd104d49dab0dd05903f7b651fec9939608fd01705162af2b399b57cf21dd2750c52cae18b5848f85f0ca7694983e014539f6f0100007017000057c8f7a5b8d6758f18fb906eaf03f007da0a9f2601420c400eb0087228a71228edf83e635ad0bbcd30a8e0ba04207d26657dbce334e8ea1fa7b6684a393bc6d1e054df39927e9bdf3d89e3cd9cf760a5f8639ae5b27ecc822b110c21021e1563aa32a5191ff7198e8c28ef02a8c6b33aecf326f5b32c6a620138d4201b110b413073b3bb00"
}
```

Request body:

Verbose = 1, returns the result in JSON format:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [6000, 1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xf929babb2b10eed2e3af429c73648ef6d3c05d247494eb95dcdae53a77236ddf",
        "size": 213,
        "version": 0,
        "previousblockhash": "0xec1f657b3f9005ddb0da494d10cd6137e85899ffe4e7e165d32b3972cb13c220",
        "merkleroot": "0x834969a70c5ff848588be1ca520c75d21df27cb599b3f22a160517d08f603999",
        "time": 1578926019808,
        "index": 6000,
        "nextconsensus": "NTv8iuL3yf4eiskKWWrtXLq9fKrX6LNGrG",
        "witnesses": [
            {
                "invocation": "DEAOsAhyKKcSKO34PmNa0LvNMKjgugQgfSZlfbzjNOjqH6e2aEo5O8bR4FTfOZJ+m989iePNnPdgpfhjmuWyfsyC",
                "verification": "EQwhAh4VY6oypRkf9xmOjCjvAqjGszrs8yb1syxqYgE41CAbEQtBMHOzuw=="
            }
        ],
        "confirmations": 150220,
        "nextblockhash": "0x17f3f1d81f2f442053a0bf8ca9a6addeb25646267127bb3b43884f61ed9a2822"
    }
}
```