# invokefunction 方法

使用给定的操作和参数，通过合约脚本哈希调用智能合约之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，调用时只是在 RPC 对应的节点试运行脚本并返回结果，不会对区块链数据产生影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- scripthash：智能合约脚本哈希。

- operation：操作名称（字符串）。

- params：传递给智能合约操作的参数，可选。

- signers: 签名账户列表，可选。
  * account: 签名账户
  * scopes: 签名的作用域，定义用户签名的可用范围，防止未经授权的合约随意使用用户签名。允许的值为：
    * None：空，只对交易签名，不允许任何合约使用该签名
    * CalledByEntry：只作用链式调用的入口，比如用户调用 A 合约，那么只有 A 合约可以使用签名，A 合约再调用 B 合约，在 B 合约中是不能使用用户签名的。建议作为钱包的默认签名作用。
    * CustomContracts：自定义合约，在指定的合约中可以使用该签名。可与 CalledByEntry 配合使用。
    * CustomGroups：自定义合约组，在指定的合约组中可以使用该签名。可与 CalledByEntry 配合使用。
    * Global：全局。风险极高，合约有可能会转移地址中的所有资产，仅在极其信任该合约时选择。
  * allowedcontracts: 如果 scopes 是 CustomContracts，该字段是签名生效的合约 Hash 列表
  * allowedgroups: 如果 scopes 是 CustomGroups，该字段是签名生效的公钥列表。

> [!Note]
>
> 你需要根据传入地址的数据类型，使用正确的字节序格式。如果数据类型为 Hash160，输入大端序 scripthash；如果数据类型为 ByteArray，则输入小端序 scripthash。

例如：

```json
{
  "type": "String",
  "value": "Hello"
}

{
  "type": "Hash160",
  "value": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c"
}

{
  "type": "ByteArray",
  "value": "7472616e73666572"
}
```

## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "invokefunction",
    "params": [
        "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
        "transfer",
        [
            {
                "type": "Hash160",
                "value": "0x86df72a6b4ab5335d506294f9ce993722253b6e2"
            },
            {
                "type": "Hash160",
                "value": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa"
            },
            {
                "type": "Integer",
                "value": "10000"
            },
            {
                "type": "String",
                "value": ""
            }
        ],
        [
            {
                "account": "0x86df72a6b4ab5335d506294f9ce993722253b6e2",
                "scopes": "CalledByEntry",
                "allowedcontracts": [],
                "allowedgroups": []
            }
        ]
    ]
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "script": "DAABECcMFPqJ+ywU3w9Z3d8E9uVlF/KzSq7rDBTitlMicpPpnE8pBtU1U6u0pnLfhhTAHwwIdHJhbnNmZXIMFIOrBnmtVcBQoTrUP1k26nP16x72QWJ9W1I=",
        "state": "HALT",
        "gasconsumed": "9999720",
        "exception": null,
        "stack": [
            {
                "type": "Boolean",
                "value": true
            }
        ],
        "tx": "AI3PBQRolZgAAAAAAMrSEgAAAAAAtRcAAAHitlMicpPpnE8pBtU1U6u0pnLfhgEAWQwAARAnDBT6ifssFN8PWd3fBPblZRfys0qu6wwU4rZTInKT6ZxPKQbVNVOrtKZy34YUwB8MCHRyYW5zZmVyDBSDqwZ5rVXAUKE61D9ZNupz9ese9kFifVtSAUIMQB87UjubTE7Kb/fOe8Yu2QDUQJ6c5pL9LjcoFaNkEiJzLY5yd72jrsvVbVFNZ6ObWloAmLkjCgDXw9enkVtwVBMrEQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
    }
}
```

响应说明：

- script：合约的调用脚本，在 Neo 官网上可以解析 https://neo.org/converter

   ```
   SYSCALL System.Contract.Call
   PUSHDATA1 0xf61eebf573ea36593fd43aa150c055ad7906ab83
   PUSHDATA1 transfer
   PUSHDATA1 0x86df72a6b4ab5335d506294f9ce993722253b6e2
   PUSHDATA1 0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa
   PUSHINT16 10000
   PUSHDATA1
   ```
   
- state：虚拟机状态， `HALT` 表示虚拟机执行成功，`FAULT` 表示虚拟机执行时遇到异常退出。
- gasconsumed：调用智能合约时消耗的系统手续费。
- stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。
- tx：本次调用合约交易的 Base64 编码，需要打开钱包并且传入正确的签名账户参数，否则 tx 为 null。

## 特别说明

当合约执行结果里包含迭代器时，会根据 `RpcServer` 插件的 `config` 文件中 `MaxIteratorResultItems` 设置的值来限制迭代次数，默认为 100 次。

在下面的示例中，实际最多可获得6个返回结果。当设置`MaxIteratorResultItems ` 值为 5 时，只返回5次迭代结果，且 `truncated` 为 true ，提示还有数据未返回：

```
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "wh8MBnRva2VucwwUR7xWZRSFd3BpKcM7Mj3g3v4/u3ZBYn1bUg==",
        "state": "HALT",
        "gasconsumed": "2288880",
        "exception": null,
        "stack": [
            {
                "type": "InteropInterface",
                "iterator": [
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDMuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDUuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDEuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDIuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDQuY3A="
                    }
                ],
                "truncated": true
            }
        ]
    }
}
```

当设置`MaxIteratorResultItems ` 值为大于等于 6 时，会返回6次迭代结果，且 `truncated` 为 false ，提示已返回全部数据：

```
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "wh8MBnRva2VucwwUR7xWZRSFd3BpKcM7Mj3g3v4/u3ZBYn1bUg==",
        "state": "HALT",
        "gasconsumed": "2288880",
        "exception": null,
        "stack": [
            {
                "type": "InteropInterface",
                "iterator": [
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDMuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDUuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDEuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDIuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDQuY3A="
                    },
                    {
                        "type": "ByteString",
                        "value": "Ymp5eDYuY3A="
                    }
                ],
                "truncated": false
            }
        ]
    }
}
```



