# invokecontractverify 方法

调用合约的验证（Verify）方法。该方法与 invokefunction 不同， invokefunction 是通过 Application 触发器执行智能合约，而 invokecontractverify 方法是通过 Verification 触发器执行智能合约。并且可以传入 Verify 的参数（params）、签名账户列表（signers）。具体参数类型和数量取决于所调用的智能合约。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，调用时只是在 RPC 对应的节点试运行脚本并返回结果，不会对区块链数据产生影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- scripthash：智能合约脚本哈希。

- params：传递给智能合约操作的参数。

- signers: 签名账户列表，可选。
  * account: 签名账户
  * scopes: 签名的作用域，允许的值: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
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
  ```

```json
  {
    "type": "Hash160",
    "value": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c"
  }
```

```json
  {
    "type": "ByteArray",
    "value": "7472616e73666572"
  }
```

## 调用示例

请求正文：

部署合约如下：


```json
{
  "jsonrpc": "2.0",
  "method": "invokecontractverify",
  "params": [ 
  "0x92f5c79b88560584a900cfec15b0e00dc4d58b54", 
  [ ],
  [
      {
        "account": "NTpqYncLsNNsMco71d9qrd5AWXdCq8YLAA",
        "scopes": "CalledByEntry"
      }
  ]
],
  "id": 1
}

```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "script": "VgEMFFbIjRQK0swPKQN90Qp/AGCitShcYEBXAANAQZv2Z84MBWhlbGxvDAV3b3JsZFNB5j8YhEBXAQAMFFbIjRQK0swPKQN90Qp/AGCitShcQfgn7IxwaEA=",
    "state": "HALT",
    "gasconsumed": "1017810",
    "exception": null,
    "stack": [
      {
        "type": "Boolean",
        "value": true
      }
    ]
  }
}
```

响应说明：

- script：合约的调用脚本，参考 [Neo 数据转换](https://neo.org/converter) 页面，可以将脚本转为 OpCode 
- state：虚拟机状态， `HALT` 表示虚拟机执行成功，`FAULT` 表示虚拟机执行时遇到异常退出。
- gasconsumed：调用智能合约时消耗的系统手续费。
- stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。
