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
  "params": [4],
  "id": 1
}
```

or

```
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0xe2700e964bfaf8ac00c7b346eeca00826946fc4d1af409bd5e790672f459f0aa"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAAPKlYFvxWXWiC6fBuxNdcEdT4/vit3BJeCEOe7Igh1nh3Gj9UEwqbv772NBC0sONn35vQ2PQ3duR1T5ahI1zsdkCFbw4dwEAAAQAAADitlMicpPpnE8pBtU1U6u0pnLfhgFCDEBEfgRU7VEEbzdGIYvT7NkZYBfSZfuQVkBe0j0n15WW4yr9puAfBVKKDbf35sM2JfDEPh+KHFyxa7Qc2jFj4JMgKxEMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4hELQRON768A"
}
```

**Example 2 - 获取 JSON 格式的区块信息**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [4, true],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0xe2700e964bfaf8ac00c7b346eeca00826946fc4d1af409bd5e790672f459f0aa", true],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xe2700e964bfaf8ac00c7b346eeca00826946fc4d1af409bd5e790672f459f0aa",
        "size": 213,
        "version": 0,
        "previousblockhash": "0xe1598720b27b0e21784970b7e2fbe35347705d13bbc1a70ba27559f15b60a5f2",
        "merkleroot": "0xd9b1738d845a3ed591dbddd063436f7e9f8dc3d242d0d8fbfe6e2a4c50fd68dc",
        "time": 1611564586242,
        "index": 4,
        "nextconsensus": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "witnesses": [
            {
                "invocation": "DEBEfgRU7VEEbzdGIYvT7NkZYBfSZfuQVkBe0j0n15WW4yr9puAfBVKKDbf35sM2JfDEPh+KHFyxa7Qc2jFj4JMg",
                "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
            }
        ],
        "confirmations": 37,
        "nextblockhash": "0x4acb84ce4c125a08aba5e619b39db8c89a56fd9a99fdcc9affa2c218905c26ac"
    }
}
```

