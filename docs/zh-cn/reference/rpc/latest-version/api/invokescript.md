# invokescript 方法

通过虚拟机传递脚本之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个 RPC 调用对区块链没有任何影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- script：一个由虚拟机运行的脚本，与 invokefunction 返回的 script 相同；
- signers：签名账户列表，可选
  * account: 签名账户
  * scopes: 签名的作用域，允许的值: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
  * allowedcontracts: 如果 scopes 是 CustomContracts，该字段是签名生效的合约 Hash 列表
  * allowedgroups: 如果 scopes 是 CustomGroups，该字段是签名生效的公钥列表。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokescript",
  "params": [    
    "DAlqdXN0IHRlc3QRDBRWyI0UCtLMDykDfdEKfwBgorUoXAwU19eXMOJ4xtkG5uj2lb+th34/+pAUwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtS",
    [
         {
          "account": "NfbEjVjhhpDsni716KVbuQWqSjVNHAUdTh",
          "scopes": "CustomContracts",
          "allowedcontracts":["0xd2a4cff31913016155e38e474a2c06d08be276cf","0xd2a4cff31913016155e38e474a2c06d08be276cf"],
          "allowedgroups":[]
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
        "script": "DAlqdXN0IHRlc3QRDBRWyI0UCtLMDykDfdEKfwBgorUoXAwU19eXMOJ4xtkG5uj2lb+th34/+pAUwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtS",
        "state": "HALT",
        "gasconsumed": "997796",
        "exception": null,
        "stack": [
            {
                "type": "Boolean",
                "value": false
            }
        ]
    }
}
```

- state：虚拟机状态， `HALT` 表示虚拟机执行成功，`FAULT` 表示虚拟机执行时遇到异常退出。
- gasconsumed：调用智能合约时消耗的系统手续费。
- stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。
