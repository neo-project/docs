# sendrawtransaction 方法

广播交易。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

hex：在程序中构造的已签名的交易序列化后的 16 进制字符串。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendrawtransaction",
  "params": ["004715897d2bf173f849d1d59123d097c009aa31624d39e73900e1f50500000000466a130000000000f699200000012bf173f849d1d59123d097c009aa31624d39e739015d0300d0ed902e0000000c1425275006800e73cc64286753a3a732422521c8e40c142bf173f849d1d59123d097c009aa31624d39e73913c00c087472616e736665720c143b7d3711c6f0ccf9b1dca903d1bfa1d896f1238c41627d5b523901420c40632d2abc04cce02a7d373a2def1b5d126ce75cdd6f40ef8ab9258960841c4123c48288a6f44bc86d94e83755faee3c17d059b99561a18d923202717796e0b68f290c2103b9c46c6d5c671ef5c21bc7aa7c30468aeb081a2e3895269adf947718d650ce1e0b410a906ad4"],
  "id": 1
}
```

成功的响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x13ccdb9f7eda95a24aa5a4841b24fed957fe7f1b944996cbc2e92a4fa4f1fa73"
    }
}
```

失败的响应正文：

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

当 result 返回交易的 txid 时，表明交易广播成功。

当 result 为 false 时表示当前交易广播失败，原因可能有双重花费、签名不完整等。

本示例中广播了一个已经确认的交易，因为双重花费所以广播失败。可能会遇到以下错误码：

| 错误代码 | 信息              | 注释                                  |
| -------- | ----------------- | ------------------------------------- |
| 500      | AlreadyExists     | 重复交易                              |
|          | OutOfMemory       | 交易数超出 Mempool 预设的最大容量     |
|          | UnableToVerify    | 未知区块信息                          |
|          | Invalid           | 不正确的格式或参数                    |
|          | Expired           | 过期的区块信息                        |
|          | InsufficientFunds | 余额不足                              |
|          | PolicyFail        | 不符合规则的行为（如 黑名单地址交易） |