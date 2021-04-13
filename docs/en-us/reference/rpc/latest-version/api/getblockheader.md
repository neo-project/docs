# getblockheader Method

Returns the corresponding block header information according to the specified script hash or index.

The usage of this method is as same as `getblock`. The only difference is that `getblockeader` gets the block header and `getblock` gets the complete block.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* hash | index: The block script hash or index (i.e. block height=number of blocks - 1).

* verbose: Optional, the default value is false. 
  * When verbose is false, serialized information of the block is returned in a hexadecimal string. If you need the detailed information, use the SDK for deserialization. 
  * When verbose is true or 1, detailed information of the block is returned in Json format. 

## Example

**Example 1 - invoke with block hash**

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [140],
  "id": 1
}
```

or

```
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAAFrf0tgylRv20FkZygEC2UDiMHJTukXJPQ/DFP5sezdzm3A7VffHxK0b4rwXh/xR/zV24Mj6+Vhq25qoN1WlxRIBIKp7dwEAAIwAAADitlMicpPpnE8pBtU1U6u0pnLfhgFCDEDGZIUihuWK6RLqloq6UiKxkoW0QFhqGhoQU3cK5IQRATFUY807W/hGmYqP80N8qjKQ/e4o8URTzgRUXJKXf1/sKxEMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4hELQRON768A"
}
```

**Example 2 - 获取 JSON 格式的区块信息**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [140, true],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getblockheader",
  "params": ["0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c", true]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c",
        "size": 213,
        "version": 0,
        "previousblockhash": "0x73377b6cfe14c30f3dc945ba537230e240d90201ca1959d0f61b9532d8d2df5a",
        "merkleroot": "0x12c5a55537a89adb6a58f9fac8e07635ff51fc8717bce21badc4c7f7553b709b",
        "time": 1612687482881,
        "primary": 0,
        "index": 140,
        "nextconsensus": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "witnesses": [
            {
                "invocation": "DEDGZIUihuWK6RLqloq6UiKxkoW0QFhqGhoQU3cK5IQRATFUY807W/hGmYqP80N8qjKQ/e4o8URTzgRUXJKXf1/s",
                "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
            }
        ],
        "confirmations": 41,
        "nextblockhash": "0xd087785fc3cf5b59c6a4631bdbdd63ed3e44947c22eb69ba866ea9291473b2b5"
    }
}
```

