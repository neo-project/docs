# getrawtransaction 方法

根据指定的散列值，返回对应的交易信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用

## 参数说明

- txid：交易 ID。

- verbose：可选参数，verbose 默认值为 0。
  - verbose 为 0 时返回的是交易的序列化后的信息，用 16 进制字符串表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  - verbose 为 1 时返回的是对应交易的详细信息，用 Json 格式字符串表示。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0x1df1a550a2764326e14ae5609b066a01b692660e7df612bbc88f5a920c69b3ac", 0],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "0082b3103425275006800e73cc64286753a3a732422521c8e400e1f50500000000466a13000000000063e72000000125275006800e73cc64286753a3a732422521c8e4015d0300e40b54020000000c142bf173f849d1d59123d097c009aa31624d39e7390c1425275006800e73cc64286753a3a732422521c8e413c00c087472616e736665720c143b7d3711c6f0ccf9b1dca903d1bfa1d896f1238c41627d5b523901420c4048f7972d1785bc159a998aa9b87935e869597c224b23b4c3a0860c9df2a252d084295b4529c52dbd262ce36ffe7089fd61b746de92c5a7e9684cf26ada409aa1290c2102c9885a0be8be46eef981a95da7d57a38a1568f6e8455deda4dc5e2009327ff4a0b410a906ad4"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0x1df1a550a2764326e14ae5609b066a01b692660e7df612bbc88f5a920c69b3ac", 1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x1df1a550a2764326e14ae5609b066a01b692660e7df612bbc88f5a920c69b3ac",
        "size": 272,
        "version": 0,
        "nonce": 873509762,
        "sender": "NPJRHLjDm4r1wd8wHBGFRWqzsneFX9tBch",
        "sys_fee": "100000000",
        "net_fee": "1272390",
        "valid_until_block": 2156387,
        "attributes": [],
        "cosigners": [
            {
                "account": "0xe4c821254232a7a353672864cc730e8006502725",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "AwDkC1QCAAAADBQr8XP4SdHVkSPQl8AJqjFiTTnnOQwUJSdQBoAOc8xkKGdTo6cyQiUhyOQTwAwIdHJhbnNmZXIMFDt9NxHG8Mz5sdypA9G/odiW8SOMQWJ9W1I5",
        "witnesses": [
            {
                "invocation": "DEBI95ctF4W8FZqZiqm4eTXoaVl8IksjtMOghgyd8qJS0IQpW0UpxS29Jizjb/5wif1ht0beksWn6WhM8mraQJqh",
                "verification": "DCECyYhaC+i+Ru75galdp9V6OKFWj26EVd7aTcXiAJMn/0oLQQqQatQ="
            }
        ],
        "blockhash": "0xbd96fddf3c19381671f96de6b9e7779b7aef9972b87f5cff8412f4fbd64a9d47",
        "confirmations": 30,
        "blocktime": 1579168140997,
        "vmState": "HALT"
    }
}
```



