# NEO 客户端插件

从 NEO 2.9.0 开始，一些附加功能被独立封装在插件中用以调用，目的是为了提升节点的安全性，稳定性和灵活性。用户可以自行选取所需要的扩展功能而不用每次在启动 NEO-CLI时通过附加参数来调用，避免了很多人为的失误操作同时简化了打开钱包，调用 API 等一系列繁琐的指令。点击此处下载 [Plugins](https://github.com/neo-project/neo-plugins/releases)。

| 插件                                                         | 功能                                                         |              |
| ------------------------------------------------------------ | ------------------------------------------------------------ | ------------ |
| [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/ApplicationLogs.zip) | 在 RPC 模式下自动同步智能合约日志（ApplicationLogs），目前日志已经改为以 LevelDB 格式存储。 | 交易所必选   |
| [ImportBlocks](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/ImportBlocks.zip) | 同步离线包。                           | 必选         |
| [RpcSecurity](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/RpcSecurity.zip) | 提升 RPC 安全。                                              | 可选         |
| [SimplePolicy](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/SimplePolicy.zip) | 启用共识的简单策略。                                         | 搭建私链必选 |
| [StatesDumper](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/StatesDumper.zip) | 导出 NEO-CLI 状态数据。                                      | 可选         |

## 安装插件

要安装插件，在客户端根目录下新建 Plugins 文件夹（注意首字母大写），然后将解压出来的插件拷贝到其中，如下所示在neo-cli根目录下安装：

![plugins.png](../../assets/plugins.png)

## 插件中的 API 接口

### getapplicationlog 方法

根据指定的 NEP-5 交易 ID 获取合约日志。完整的合约日志会记录到 ApplicationLogs 目录。

此方法由插件提供，需要安装 [ApplicationLogs](https://github.com/neo-project/neo-plugins/releases/download/v2.9.2/ApplicationLogs.zip) 插件才可以调用。

#### 参数说明

txid：交易ID

#### 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getapplicationlog",
  "params": ["0xff488264c1abf9f5c3c17ed8071f6dd3cd809b25797a43af49316490ded8fb07"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xff488264c1abf9f5c3c17ed8071f6dd3cd809b25797a43af49316490ded8fb07",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x0110a8f666bcc650dc0b544e71c31491b061c79e",
                "vmstate": "HALT, BREAK",
                "gas_consumed": "2.855",
                "stack": [
                    {
                        "type": "Integer",
                        "value": "1"
                    }
                ],
                "notifications": [
                    {
                        "contract": "0xb9d7ea3062e6aeeb3e8ad9548220c4ba1361d263",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "e3069da508f128069a0cd2544b0728ccbacdfb43"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "d142f89e93b2717426a8130c37dad93aad70cff5"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "00e1f50500000000"
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
