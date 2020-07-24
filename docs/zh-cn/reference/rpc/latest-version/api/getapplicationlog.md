# getapplicationlog 方法

根据指定的 NEP-5 交易 ID 获取合约日志。完整的合约日志会记录到 ApplicationLogs 目录。

> [!Note]
>
> 此方法由插件提供，需要安装 [ApplicationLogs](https://github.com/neo-project/neo-modules/releases) 和 [LevelDBStore](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

txid：交易ID

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["0x5af8769d0a209e55c8d27dab8be6c8c6288e2083b02f11043d9586377cd30295"],
  "id": 1
} 
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": "1",
    "result": {
        "txid": "0x5af8769d0a209e55c8d27dab8be6c8c6288e2083b02f11043d9586377cd30295",
        "trigger": "Application",
        "vmstate": "HALT",
        "gasconsumed": "9007990",
        "stack": [],
        "notifications": [
            {
                "contract": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "eventname": "Transfer",
                "state": {
                    "type": "Array",
                    "value": [
                        {
                            "type": "ByteString",
                            "value": "+pU2/Hks6bMS9XhEc3F6o2fineE="
                        },
                        {
                            "type": "ByteString",
                            "value": "GM4RybFKiRJSR0M8IDpNgA/1ILE="
                        },
                        {
                            "type": "Integer",
                            "value": "1223300000000"
                        }
                    ]
                }
            }
        ]
    }
}
```

响应说明：
gasconsumed ：该交易消耗的 gas 数量，即交易手续费。
