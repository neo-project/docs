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

请求正文 1：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getapplicationlog",
  "params": [
    "0x6ea186fe714b8168ede3b78461db8945c06d867da649852352dbe7cbf1ba3724"
  ]
}
```

响应正文 1：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "blockhash": "0x6ea186fe714b8168ede3b78461db8945c06d867da649852352dbe7cbf1ba3724",
    "executions": [
      {
        "trigger": "OnPersist",
        "vmstate": "HALT",
        "gasconsumed": "0.0203126",
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
                  "value": "CqOHtT6Wt5iaYxQxoFbdH0CgQvY="
                },
                {
                  "type": "Any"
                },
                {
                  "type": "Integer",
                  "value": "18083410"
                }
              ]
            }
          },
          {
            "contract": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
            "eventname": "Transfer",
            "state": {
              "type": "Array",
              "value": [
                {
                  "type": "Any"
                },
                {
                  "type": "ByteString",
                  "value": "z6LDQN4w1uEMToIZiPSxToNRPog="
                },
                {
                  "type": "Integer",
                  "value": "1252390"
                }
              ]
            }
          }
        ]
      },
      {
        "trigger": "PostPersist",
        "vmstate": "HALT",
        "gasconsumed": "0.0203126",
        "stack": [],
        "notifications": [
          {
            "contract": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
            "eventname": "Transfer",
            "state": {
              "type": "Array",
              "value": [
                {
                  "type": "Any"
                },
                {
                  "type": "ByteString",
                  "value": "z6LDQN4w1uEMToIZiPSxToNRPog="
                },
                {
                  "type": "Integer",
                  "value": "50000000"
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
gasconsumed ：该交易消耗的 GasToken 数量，即交易手续费。