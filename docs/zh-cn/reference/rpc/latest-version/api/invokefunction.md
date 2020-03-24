# invokefunction 方法

使用给定的操作和参数，以散列值调用智能合约之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个RPC调用对区块链没有任何影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- scripthash：智能合约脚本散列值。
- operation：操作名称（字符串）。
- params：传递给智能合约操作的参数。注意你需要根据传入地址的数据类型，使用正确的字节序格式。如果数据类型为 Hash160，输入大端序 scripthash；如果数据类型为 ByteArray，则输入小端序 scripthash。


## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "39e7394d6231aa09c097d02391d5d149f873f12b"
      }
    ]
  ],
  "id": 3
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b52",
        "state": "HALT",
        "gas_consumed": "2007570",
        "stack": [
            {
                "type": "Integer",
                "value": "9999885"
            }
        ],
        "tx": "0075fa234c2bf173f849d1d59123d097c009aa31624d39e73900e1f50500000000269f120000000000dbe1200000003e0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b5201420c40b9539b4affc196cc2dccf49df0d8ba962ed7cca1f2c5a708a5da4405a79263694464a9140d686445b5d3857abdd1322b3aeed6486490ef4c8b298460138de237290c2103b9c46c6d5c671ef5c21bc7aa7c30468aeb081a2e3895269adf947718d650ce1e0b410a906ad4"
    }
}
```

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0x9c33bbf2f5afbbc8fe271dd37508acd93573cffc",
    "symbol",
    [ ]
  ],
  "id": 3
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "10c00c0673796d626f6c0c14fccf7335d9ac0875d31d27fec8bbaff5f2bb339c41627d5b52",
        "state": "HALT",
        "gas_consumed": "1036870",
        "stack": [
            {
                "type": "ByteArray",
                "value": "RERB"
            }
        ],
        "tx": "00e7fc08682bf173f849d1d59123d097c009aa31624d39e73900e1f505000000007e3d120000000000c1e1200000002510c00c0673796d626f6c0c14fccf7335d9ac0875d31d27fec8bbaff5f2bb339c41627d5b5201420c4099b21d5356e17dcca7eea7940815f528c1bf9e5faddb5717a57b050e4afb71a82db068bd087888b780eebfcb8d8bca359d8f360d5a0876a8548afb36150f50cb290c2103b9c46c6d5c671ef5c21bc7aa7c30468aeb081a2e3895269adf947718d650ce1e0b410a906ad4"
    }
}
```
