# getrawtransaction Method

Returns the corresponding transaction information based on the specified hash value.

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": [txid, verbose],
  "id": 1
}
```

## Parameter Description

* txid: Transaction ID

* verbose: Optional. The default value is 0. 
  * When verbose is 0, serialized information of the block is returned in a hexadecimal string. If you need the detailed information, use the SDK for deserialization. 
  * When verbose is 1, detailed information of the block is returned in Json format string.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["dd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6"],
  "id": 1
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "00000000000568123e7fe8da1745e9b549bd0bfa1a569971c77eba30cd5a4b000000000000000000000000000000000000000000000151""
}
```

Request body:

When verbose = 1, the result in Json format is returned:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["dd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6", 1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0", 
    "id": "1", 
    "result": {
        "txid": "0xdd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6", 
        "size": 55, 
        "version": 0, 
        "nonce": 0, 
        "script": "68123e7fe8", 
        "sender": "Abf2qMs1pzQb8kYk9RuxtUb9jtRKJVuBJt", 
        "gas": "0", 
        "net_fee": "0", 
        "valid_until_block": 0, 
        "attributes": [ ], 
        "witness": {
            "invocation": "", 
            "verification": "51"
        }, 
        "blockhash": "0x479d71eae26a817647a373381f21de06c5e4bf3ee7717c948f006ce8e25441be", 
        "confirmations": 6180, 
        "blocktime": 1468595301
    }
}
```
