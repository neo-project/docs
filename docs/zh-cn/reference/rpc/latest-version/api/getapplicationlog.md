# getapplicationlog 方法

根据交易 txid 获取合约的事件信息。合约事件信息会保存到 ApplicationLogs 目录。

> [!Note]
>
> 此方法由插件提供，需要安装 [ApplicationLogs](https://github.com/neo-project/neo-modules/releases) 和 [LevelDBStore](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- txid/blockhash：交易 ID 或区块 hash

- trigger type:  可选参数， 有以下 trigger 类型：

  - OnPersist
  - PostPersist
  - Application
  - Verification
  - System: OnPersist | PostPersist
  - All: OnPersist | PostPersist | Verification | Application

  默认获取所有类型，也可以指定某种类型。 

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getapplicationlog",
  "params": [
    "0x7da6ae7ff9d0b7af3d32f3a2feb2aa96c2a27ef8b651f9a132cfaad6ef20724c"
  ]
}
```

该交易是将 100 GAS 从 NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF 转到 NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ。

响应正文 ：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x7da6ae7ff9d0b7af3d32f3a2feb2aa96c2a27ef8b651f9a132cfaad6ef20724c",
        "executions": [
            {
                "trigger": "Application",
                "vmstate": "HALT",
                "exception": null,
                "gasconsumed": "9999540",
                "stack": [],
                "notifications": [
                    {
                        "contract": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                        "eventname": "Transfer",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteString",
                                    "value": "4rZTInKT6ZxPKQbVNVOrtKZy34Y="
                                },
                                {
                                    "type": "ByteString",
                                    "value": "+on7LBTfD1nd3wT25WUX8rNKrus="
                                },
                                {
                                    "type": "Integer",
                                    "value": "10000000000"
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

响应说明：

- txid：交易 ID。

- trigger：触发器。

- vmstate：虚拟机执行状态，HALT 代表成功，FAULT 代表失败。

- gasconsumed ：该交易消耗的 GasToken 数量，即交易手续费。

- notifications：智能合约通知。如果没有通知返回，表明该交易不成功，详情参见下文的Note说明。

- contract：发出通知的合约，这里是 GasToken 原生合约。

- eventname：通知的事件名称。

- state：通知内容。其中 ByteString 为 Base64 编码表示的钱包地址，可以在 [Data Convertor](https://neo.org/converter/index) 进行转换。

> [!Note]
>
> 上例显示的是一个成功转账交易的日志，但如果传输失败或NeoVM执行异常，显示结果可能是以下情况:
>
> - 转账失败: 不返回 Transfer notifications。执行状态 vmstate 显示 `HALT` 且 stack 值为 `False`。
> - NeoVM 异常: 可能返回或不返回 Transfer notifications。执行状态 vmstate 显示 `FAULT` 。
