# submitblock 方法

在 NEO 网络广播新的区块。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用 

## 参数说明

Hex: 序列化区块的十六进制字符串。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "submitblock",
  "params": ["000000000000000000000000000000000000000000000000000000000000000000000000845c34e7c1aed302b1718e914da0c42bf47c476ac4d89671f278d8ab6d27aa3d65fc8857000000001dac2b7c00000000be48d3a3f5d10013ab9ffee489706078714f1ea2010001510400001dac2b7c00000000400000455b7b226c616e67223a227a682d434e222c226e616d65223a22e5b08fe89a81e882a1227d2c7b226c616e67223a22656e222c226e616d65223a22416e745368617265227d5d0000c16ff28623000000da1745e9b549bd0bfa1a569971c77eba30cd5a4b00000000400001445b7b226c616e67223a227a682d434e222c226e616d65223a22e5b08fe89a81e5b881227d2c7b226c616e67223a22656e222c226e616d65223a22416e74436f696e227d5d0000c16ff286230008009f7fd096d37ed2c0e3f7f0cfc924beef4ffceb680000000001000000019b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc50000c16ff2862300be48d3a3f5d10013ab9ffee489706078714f1ea201000151"],
  "id": 1
}
```

如果成功，响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": true
}
```

如果失败，响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "error": {
        "code": -500,
        "message": "AlreadyExists"
    }
}
```

响应说明：

当结果为 false 时，区块广播失败并引发异常。可能返回以下错误代码：

| 错误代码 | 信息 | 注释 |
| ------------ | ------------- | ------------- |
| 500        | AlreadyExists | 重复交易 |
|       | OutOfMemory | 交易数超出 Mempool 预设的最大容量|
|       | UnableToVerify | 未知区块信息 |
|       | Invalid | 不正确的格式或参数 |
|       | Expired | 过期的区块信息 |
|       | InsufficientFunds | 余额不足 |
|       | PolicyFail | 不符合规则的行为（如 黑名单地址交易）|

