# getblock 方法

根据指定的哈希或索引，返回对应的区块信息。

该方法与 getblockheader 方法的用法一样，区别是 getblockheader 只获取区块头，而 getblock 获取完整区块。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- hash | index：区块哈希或区块索引（即区块高度=区块数-1）。

- verbose：可选参数，verbose 默认值为 false。
  - verbose 为 false 时返回的是区块的序列化后的信息，用 base64 编码表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  - verbose 为 true（或 1） 时返回的是对应区块的详细信息，用 JSON 格式字符串表示。

## 调用示例

**示例1 - 获取序列化后的区块信息**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [4],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["0xe2700e964bfaf8ac00c7b346eeca00826946fc4d1af409bd5e790672f459f0aa"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAAPKlYFvxWXWiC6fBuxNdcEdT4/vit3BJeCEOe7Igh1nh3Gj9UEwqbv772NBC0sONn35vQ2PQ3duR1T5ahI1zsdkCFbw4dwEAAAQAAADitlMicpPpnE8pBtU1U6u0pnLfhgFCDEBEfgRU7VEEbzdGIYvT7NkZYBfSZfuQVkBe0j0n15WW4yr9puAfBVKKDbf35sM2JfDEPh+KHFyxa7Qc2jFj4JMgKxEMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4hELQRON768CAICY7ddHCOSKACWjnEG0lJgAAAAAAMjIIwAAAAAAgxYAAAL6ifssFN8PWd3fBPblZRfys0qu6wDitlMicpPpnE8pBtU1U6u0pnLfhgEAVwsRDBT6ifssFN8PWd3fBPblZRfys0qu6wwU4rZTInKT6ZxPKQbVNVOrtKZy34YUwB8MCHRyYW5zZmVyDBSDqwZ5rVXAUKE61D9ZNupz9ese9kFifVtSOQJCDEDkpAjk9rgAWpU7eRynVfHIYOU1yj3crIIAy700P7M4WJfc81XtRjNZlesVu6qUP+16pEn89ObrF4A/iyP/BwNrKQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiC0GVRA14QgxAa0g6Ni7IxByYeIQPO5hwDcwa6o8hZYMvlox05MFY2tv6/e1ptl9ey7YvltlClQLSnSn3eYJoC1GaPJtgfBEjJCsRDCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eIRC0ETje+v"
}
```

**示例1 - 获取 JSON 格式的区块信息**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [4, true],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
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
        "size": 600,
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
        "consensusdata": {
            "primary": 0,
            "nonce": "8ae40847d7ed9880"
        },
        "tx": [
            {
                "hash": "0x4e59a6908f1f7c4f00cd7ec046df3fd98e9f7abc081b56792ad4a7c9bdd838c0",
                "size": 378,
                "version": 0,
                "nonce": 1100784421,
                "sender": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "sysfee": "0.0999954",
                "netfee": "0.0234516",
                "validuntilblock": 5763,
                "signers": [
                    {
                        "account": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa",
                        "scopes": "None"
                    },
                    {
                        "account": "0x86df72a6b4ab5335d506294f9ce993722253b6e2",
                        "scopes": "CalledByEntry"
                    }
                ],
                "attributes": [],
                "script": "CxEMFPqJ+ywU3w9Z3d8E9uVlF/KzSq7rDBTitlMicpPpnE8pBtU1U6u0pnLfhhTAHwwIdHJhbnNmZXIMFIOrBnmtVcBQoTrUP1k26nP16x72QWJ9W1I5",
                "witnesses": [
                    {
                        "invocation": "DEDkpAjk9rgAWpU7eRynVfHIYOU1yj3crIIAy700P7M4WJfc81XtRjNZlesVu6qUP+16pEn89ObrF4A/iyP/BwNr",
                        "verification": "DCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXg="
                    },
                    {
                        "invocation": "DEBrSDo2LsjEHJh4hA87mHANzBrqjyFlgy+WjHTkwVja2/r97Wm2X17Lti+W2UKVAtKdKfd5gmgLUZo8m2B8ESMk",
                        "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
                    }
                ]
            }
        ],
        "confirmations": 6,
        "nextblockhash": "0x4acb84ce4c125a08aba5e619b39db8c89a56fd9a99fdcc9affa2c218905c26ac"
    }
}
```

