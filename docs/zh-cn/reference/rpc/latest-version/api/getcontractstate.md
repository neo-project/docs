# getcontractstate 方法

根据合约脚本散列或原生合约名称，查询合约的信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

script_hash / name：合约脚本散列或者原生合约的名称。

因为用户部署的合约名称可重复，所以这里搜索的合约名称仅限于原生合约。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getcontractstate",
  "params": ["neotoken"],
  "id": 1
}
```

或

```json
{
  "jsonrpc": "2.0",
  "method": "getcontractstate",
  "params": ["0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5"],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "id": -5,
    "updatecounter": 0,
    "hash": "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5",
    "nef": {
      "magic": 860243278,
      "compiler": "neo-core-v3.0",
      "tokens": [],
      "script": "EEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQBBBGvd7Z0AQQRr3e2dAEEEa93tnQA==",
      "checksum": 1841570703
    },
    "manifest": {
      "name": "NeoToken",
      "groups": [],
      "supportedstandards": [
        "NEP-17"
      ],
      "abi": {
        "methods": [
          {
            "name": "balanceOf",
            "parameters": [
              {
                "name": "account",
                "type": "Hash160"
              }
            ],
            "returntype": "Integer",
            "offset": 0,
            "safe": true
          },
          {
            "name": "decimals",
            "parameters": [],
            "returntype": "Integer",
            "offset": 7,
            "safe": true
          },
          {
            "name": "getCandidates",
            "parameters": [],
            "returntype": "Array",
            "offset": 14,
            "safe": true
          },
          {
            "name": "getCommittee",
            "parameters": [],
            "returntype": "Array",
            "offset": 21,
            "safe": true
          },
          {
            "name": "getGasPerBlock",
            "parameters": [],
            "returntype": "Integer",
            "offset": 28,
            "safe": true
          },
          {
            "name": "getNextBlockValidators",
            "parameters": [],
            "returntype": "Array",
            "offset": 35,
            "safe": true
          },
          {
            "name": "getRegisterPrice",
            "parameters": [],
            "returntype": "Integer",
            "offset": 42,
            "safe": true
          },
          {
            "name": "registerCandidate",
            "parameters": [
              {
                "name": "pubkey",
                "type": "PublicKey"
              }
            ],
            "returntype": "Boolean",
            "offset": 49,
            "safe": false
          },
          {
            "name": "setGasPerBlock",
            "parameters": [
              {
                "name": "gasPerBlock",
                "type": "Integer"
              }
            ],
            "returntype": "Void",
            "offset": 56,
            "safe": false
          },
          {
            "name": "setRegisterPrice",
            "parameters": [
              {
                "name": "registerPrice",
                "type": "Integer"
              }
            ],
            "returntype": "Void",
            "offset": 63,
            "safe": false
          },
          {
            "name": "symbol",
            "parameters": [],
            "returntype": "String",
            "offset": 70,
            "safe": true
          },
          {
            "name": "totalSupply",
            "parameters": [],
            "returntype": "Integer",
            "offset": 77,
            "safe": true
          },
          {
            "name": "transfer",
            "parameters": [
              {
                "name": "from",
                "type": "Hash160"
              },
              {
                "name": "to",
                "type": "Hash160"
              },
              {
                "name": "amount",
                "type": "Integer"
              },
              {
                "name": "data",
                "type": "Any"
              }
            ],
            "returntype": "Boolean",
            "offset": 84,
            "safe": false
          },
          {
            "name": "unclaimedGas",
            "parameters": [
              {
                "name": "account",
                "type": "Hash160"
              },
              {
                "name": "end",
                "type": "Integer"
              }
            ],
            "returntype": "Integer",
            "offset": 91,
            "safe": true
          },
          {
            "name": "unregisterCandidate",
            "parameters": [
              {
                "name": "pubkey",
                "type": "PublicKey"
              }
            ],
            "returntype": "Boolean",
            "offset": 98,
            "safe": false
          },
          {
            "name": "vote",
            "parameters": [
              {
                "name": "account",
                "type": "Hash160"
              },
              {
                "name": "voteTo",
                "type": "PublicKey"
              }
            ],
            "returntype": "Boolean",
            "offset": 105,
            "safe": false
          }
        ],
        "events": [
          {
            "name": "Transfer",
            "parameters": [
              {
                "name": "from",
                "type": "Hash160"
              },
              {
                "name": "to",
                "type": "Hash160"
              },
              {
                "name": "amount",
                "type": "Integer"
              }
            ]
          }
        ]
      },
      "permissions": [
        {
          "contract": "*",
          "methods": "*"
        }
      ],
      "trusts": [],
      "extra": null
    }
  }
}
```

