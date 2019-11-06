# getblockheader Method

Returns the corresponding block header information according to the specified script hash.

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [index, verbose],
  "id": 1
}
```

## Parameter Description

* Index: Block index (block height) = Number of blocks - 1.

* verbose: Optional, the default value of verbose is 0. 
  * When verbose is 0, the serialized information of the block is returned in a hexadecimal string. If you want the detailed information, you will need to use the SDK for deserialization. 
  * When verbose is 1, detailed information of the corresponding block in Json format string, is returned.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [0],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0", 
    "id": "1", 
    "result": "0000000000000000000000000000000000000000000000000000000000000000000000008e29af06ec157a3d85717b1eb7317c3ef4049a7222d76c6dd4d5a24598c6571665fc885700000000f071d5fc6d2e2978a45842f05b1ac970e87d197700015100"
}
```

Request body:

Verbose = 1, return the result in JSON format.

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [0, 1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0", 
    "id": "1", 
    "result": {
        "hash": "0x479d71eae26a817647a373381f21de06c5e4bf3ee7717c948f006ce8e25441be", 
        "size": 100, 
        "version": 0, 
        "previousblockhash": "0x0000000000000000000000000000000000000000000000000000000000000000", 
        "merkleroot": "0x1657c69845a2d5d46d6cd722729a04f43e7c31b71e7b71853d7a15ec06af298e", 
        "time": 1468595301, 
        "index": 0, 
        "nextconsensus": "AdhEBzaBZujuj5kEiwvKmMVy5ydqj3AC3V", 
        "witness": {
            "invocation": "", 
            "verification": "51"
        }, 
        "confirmations": 6180, 
        "nextblockhash": "0x1c00023b24ba5328918f4a0adc35607c8f97913fdda88b4eb4c571e7bc613bf4"
    }
}
```