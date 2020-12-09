# getblockheader Method

Returns the corresponding block header information according to the specified script hash or index.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* hash | index: The block script hash or index (i.e. block height=number of blocks - 1).

* verbose: Optional, the default value is 0. 
  * When verbose is 0, serialized information of the block is returned in a hexadecimal string. If you need the detailed information, use the SDK for deserialization. 
  * When verbose is 1, detailed information of the block is returned in Json format. 

## Example

**Example 1 - invoke with block hash**

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b", 0],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAACMSKFbGpGl6t7uroMpi2ilhQd84eU/pUrRfQyswXYl76woLOY0oW1z4InfxoKyxFAAB+8FS6cRu2Pm0iaOiD8OMCnLadQEAAMgcAAD6lrDvowCyjK9dBALCmE1fvMuahQFCDEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wCKxEMIQL4L//X3jDpIyMLze0sPNW+yFcufrrL3bnzOipdJpNLixELQRON768A"
}
```

Request body:

Verbose = 1, returns the result in JSON format:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",
        "size": 213,
        "version": 0,
        "previousblockhash": "0x7b895d302b435fb452e94f7938df416129da62caa0abbbb77a69a4c656281223",
        "merkleroot": "0xc30fa2a389b4f9d86ec4e952c1fb010014b1aca0f17722f85c5b288d390b0aeb",
        "time": 1605687708300,
        "index": 7368,
        "nextconsensus": "NikxdvEetzBKLHAddYJ7BHZT9USwm8qGFP",
        "witnesses": [
            {
                "invocation": "DEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wC",
                "verification": "EQwhAvgv/9feMOkjIwvN7Sw81b7IVy5+usvdufM6Kl0mk0uLEQtBE43vrw=="
            }
        ],
        "confirmations": 12,
        "nextblockhash": "0x1545a328149baf8037873793d7e45d27385221dd69ddb606ee55434eb173a3ff"
    }
}
```

**Example 2 - invoke with block index**

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [7368],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAACMSKFbGpGl6t7uroMpi2ilhQd84eU/pUrRfQyswXYl76woLOY0oW1z4InfxoKyxFAAB+8FS6cRu2Pm0iaOiD8OMCnLadQEAAMgcAAD6lrDvowCyjK9dBALCmE1fvMuahQFCDEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wCKxEMIQL4L//X3jDpIyMLze0sPNW+yFcufrrL3bnzOipdJpNLixELQRON768A"
}
```

Request body:

Verbose = 1, returns the result in JSON format:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [7368, 1],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",
        "size": 213,
        "version": 0,
        "previousblockhash": "0x7b895d302b435fb452e94f7938df416129da62caa0abbbb77a69a4c656281223",
        "merkleroot": "0xc30fa2a389b4f9d86ec4e952c1fb010014b1aca0f17722f85c5b288d390b0aeb",
        "time": 1605687708300,
        "index": 7368,
        "nextconsensus": "NikxdvEetzBKLHAddYJ7BHZT9USwm8qGFP",
        "witnesses": [
            {
                "invocation": "DEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wC",
                "verification": "EQwhAvgv/9feMOkjIwvN7Sw81b7IVy5+usvdufM6Kl0mk0uLEQtBE43vrw=="
            }
        ],
        "confirmations": 16,
        "nextblockhash": "0x1545a328149baf8037873793d7e45d27385221dd69ddb606ee55434eb173a3ff"
    }
}
```

