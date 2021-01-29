# sendrawtransaction 方法

广播交易。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

transaction：在程序中构造的已签名的交易序列化后的 Base64 加密字符串。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendrawtransaction",
  "params": ["ALmNfAb4lqIAAAAAAAZREgAAAAAA8S8AAAEKo4e1Ppa3mJpjFDGgVt0fQKBC9gEAKQwFd29ybGQRwAwDcHV0DBR9rbALvBGpMrl7cXVBdSsPOC0EmUFifVtSAUIMQACXF48H1VRmI50ievPfC042rJgj7ZQ3Y4ff27abOpeclh+6KpsL6gWfZTAUyFOwdjkA7CWLM3HsovQeDQlI0oopDCEDzqPi+B8a+TUi0p7eTySh8L7erXKTOR0ziA9Uddl4eMkLQZVEDXg="],
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