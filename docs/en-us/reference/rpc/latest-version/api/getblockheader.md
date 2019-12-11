# getblockheader Method

Returns the corresponding block header information according to the specified script hash.

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [hash, verbose],
  "id": 1
}
```

## Parameter Description

* hash: The block script hash.

* verbose: Optional, the default value is 0. 
  * When verbose is 0, serialized information of the block is returned in a hexadecimal string. If you need the detailed information, use the SDK for deserialization. 
  * When verbose is 1, detailed information of the block is returned in Json format. 

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["479d71eae26a817647a373381f21de06c5e4bf3ee7717c948f006ce8e25441be"],
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

Verbose = 1, returns the result in JSON format:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["479d71eae26a817647a373381f21de06c5e4bf3ee7717c948f006ce8e25441be", 1],
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