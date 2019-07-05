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
  "params": ["92b1ecc0e8ca8d6b03db7fe6297ed38aa5578b3e6316c0526b414b453c89e20d"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x92b1ecc0e8ca8d6b03db7fe6297ed38aa5578b3e6316c0526b414b453c89e20d",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x6ec33f0d370617dd85e51d31c483b6967074249d",
                "vmstate": "HALT",
                "gas_consumed": "2.912",
                "stack": [
                    {
                        "type": "Integer",
                        "value": "1"
                    }
                ],
                "notifications": [
                    {
                        "contract": "0x78e6d16b914fe15bc16150aeb11d0c2a8e532bdd",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "d086ac0ed3e578a1afd3c0a2c0d8f0a180405be2"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "002ba7f83fd4d3975dedb84de27345684bea2996"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "0065cd1d00000000"
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
