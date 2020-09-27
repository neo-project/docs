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
  "params": ["0000000020101cfb80de52766575a91310fddd7bf4fbd4f904e5574373649092cffffcf154badd3ae13d8aa76e75ebf9a1b2fcff874e85798a940da9e21f9533625b5a135bf545ce74010000180000000b2222301e1d5984be6d5a928e946d269603505801420c40ffe24193611172117b7cb49915afe91ec7bf314c6f855f13f82f84329238e8e1649c1aea471873fb374f548a70bb04d0cb127ddb1d4765f67d3b29a2a10e42822b110c2102470d8f746f040f8b9355be5e6fd1dc280f0c6ba9270420290337b07a37f706bd110b41138defaf010088e65a74589edfbf"],
  "id": 1
}
```

如果成功，响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xbe153a2ef9e9160906f7054ed8f676aa223a826c4ae662ce0fb3f09d38b093c1"
    }
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

