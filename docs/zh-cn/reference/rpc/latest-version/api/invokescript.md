# invokescript 方法

通过虚拟机传递脚本之后返回结果。

> [!Note]
>
> - 此方法用于测试你的虚拟机脚本，如同在区块链上运行一样。这个 RPC 调用对区块链没有任何影响。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- script：一个由虚拟机运行的脚本，与 invokefunction 返回的 script 相同；
- signers: 签名账户列表
  * account: 签名账户
  * scopes: 签名的作用域，允许的值: FeeOnly, CalledByEntry, CustomContracts, CustomGroups, Global
  * allowedcontracts: 如果 scopes 是 CustomContracts，该字段是签名允许的合约 Hash 列表
  * allowedgroups: 如果 scopes 是 CustomGroups，该字段是签名允许的公钥列表。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "invokescript",
  "params": [
    "180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52",
    [
         {
          "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
          "scopes": "CustomContracts",
          "allowedcontracts":["0xde5f57d430d3dece511cf975a8d37848cb9e0525","0x1f177332c467db9ba734d3ca85645fbadd7e13e3","0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc"],
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
        "script": "180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b52",
        "state": "HALT",
        "gasconsumed": "9007960",
        "stack": [
            {
                "type": "Boolean",
                "value": true
            }
        ],
        "tx": "0068f10067587389000000000046e71300000000008d1e2000011c0357464b777ecf6b5f3ac3893ace1f8b1621f6100325059ecb4878d3a875f91c51ceded330d4575fdee3137eddba5f6485cad334a79bdb67c43273171fbcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e660054180c14e3137eddba5f6485cad334a79bdb67c43273171f0c141c0357464b777ecf6b5f3ac3893ace1f8b1621f613c00c087472616e736665720c14bcaf41d684c7d4ad6ee0d99da9707b9d1f0c8e6641627d5b5201420c40840c3de238b0b876bf78bc5f83f4f42b8652554925a33d8728e2ecd2e3f7c9abfdb6c7b45a8d5a033616c97fb0c8cd26d810c819a336bb3682a9caf87a852674290c210222d8515184c7d62ffa99b829aeb4938c4704ecb0dd7e340e842e9df1218263430b4195440d78"
    }
}
```

- state：虚拟机状态， `HALT` 表示虚拟机执行成功，`FAULT` 表示虚拟机执行时遇到异常退出。
- gasconsumed：调用智能合约时消耗的系统手续费。
- stack：合约执行结果，其中 value 如果是字符串或 ByteArray，则是 Base64 编码后的结果。
- tx：本次调用合约交易的 hex string，需要打开钱包并且传入正确的签名账户参数，否则 tx 为 null。
