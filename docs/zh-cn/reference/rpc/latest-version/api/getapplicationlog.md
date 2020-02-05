# getapplicationlog 方法

根据指定的 NEP-5 交易 ID 获取合约日志。完整的合约日志会记录到 ApplicationLogs 目录。

> [!Note]
>
> 此方法由插件提供，需要安装 [ApplicationLogs](https://github.com/neo-project/neo-modules/releases) 和[LevelDBStore](https://github.com/neo-project/neo-modules/releases)插件才可以调用。

## 参数说明

txid：交易ID

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["0x760dffe5ac809baa81b002864e8d8a7cec90dc6905d38fdc7e9c5fdc70d2cb64"],
  "id": 1
} 
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x760dffe5ac809baa81b002864e8d8a7cec90dc6905d38fdc7e9c5fdc70d2cb64",
        "trigger": "Application",
        "vmstate": "HALT",
        "gas_consumed": "12196370",
        "stack": [],
        "notifications": [
            {
                "contract": "0xf8bf38f68c72e9a529ca2324cfbf2dccbd8f7daa",
                "state": {
                    "type": "Array",
                    "value": [
                        {
                            "type": "ByteArray",
                            "value": "VHJhbnNmZXI="
                        },
                        {
                            "type": "ByteArray",
                            "value": "K/Fz+EnR1ZEj0JfACaoxYk055zk="
                        },
                        {
                            "type": "ByteArray",
                            "value": "z2FL7K8LazAkM1WYGuB6RhOqV/4="
                        },
                        {
                            "type": "Integer",
                            "value": "500000000000"
                        }
                    ]
                }
            }
        ]
    }
}
```

响应说明：
gas_consumed ：该交易消耗的 gas 数量，即交易手续费。
