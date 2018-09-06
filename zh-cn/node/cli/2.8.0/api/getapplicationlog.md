# getapplicationlog 方法

根据指定的 NEP-5 交易 ID 获取合约日志。

> [!Note]
>
> 调用此方法前需要运行命令 `dotnet neo-cli.dll --log` 启动日志记录, 完整的合约日志会记录到 ApplicationLogs 目录。

## 参数说明

txid：交易ID

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["0x0d03ad35eb8b0bb2e43e18896d22cd2a77fe54fc0b00794fb295bcf96257d0e3"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x0d03ad35eb8b0bb2e43e18896d22cd2a77fe54fc0b00794fb295bcf96257d0e3",
        "vmstate": "HALT, BREAK",
        "gas_consumed": "2.932",
        "stack": [],
        "notifications": [
            {
                "contract": "0xac116d4b8d4ca55e6b6d4ecce2192039b51cccc5",
                "state": {
                    "type": "Array",
                    "value": [
                        {
                            "type": "ByteArray",
                            "value": "7472616e73666572"
                        },
                        {
                            "type": "ByteArray",
                            "value": "45fc40a091bd0de5e5408e3dbf6b023919a6f7d9"
                        },
                        {
                            "type": "ByteArray",
                            "value": "96da23f79685e1611b99633f7a37bf07b542d42b"
                        },
                        {
                            "type": "ByteArray",
                            "value": "00345cd65804"
                        }
                    ]
                }
            }
        ]
    }
}
```
说明：
其中 gas_consumed 表示该交易消耗的 gas 数量，即交易手续费。每笔交易会有10 gas 的免费额度。如果数量小于10，则不收取手续费，如果大于10，那么收取超过10的那部分作为手续费并向上取整。例如 gas_consumed = 12.3，那么实际收取的手续费为3 gas.
