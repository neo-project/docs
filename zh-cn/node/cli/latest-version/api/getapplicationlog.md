# getapplicationlog 方法

根据指定的 NEP-5 交易 ID 获取合约日志。完整的合约日志会记录到 ApplicationLogs 目录。

> [!Note]
>
> 此方法由插件提供，需要安装 [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

txid：交易ID

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["b6377ca56ff74ea5416469094f56ab7abd6caa46c0b5eb16b9c1998b567ff1e3"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xb6377ca56ff74ea5416469094f56ab7abd6caa46c0b5eb16b9c1998b567ff1e3",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x23c3aaaa31a0c373c23505157e9fb2665c7065ec",
                "vmstate": "HALT",
                "gas_consumed": "2.931",
                "stack": [],
                "notifications": [
                    {
                        "contract": "0x1578103c13e39df15d0d29826d957e85d770d8c9",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "235a717ed7ed18a43de47499c3d05b8d4a4bcf3a"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "0b2f7cac1d57b9f535d35da1a5421015e4e32b19"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "00f44a4f9df66d01"
                                }
                            ]
                        }
                    }
                ]
            }
        ]
    }
}
```

说明：
其中 gas_consumed 表示该交易消耗的 gas 数量，即交易手续费。每笔交易会有10 gas 的免费额度。如果数量小于10，则不收取手续费，如果大于10，那么收取超过10的那部分作为手续费并向上取整。例如 gas_consumed = 12.3，那么实际收取的手续费为3 gas.