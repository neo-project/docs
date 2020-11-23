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
  "params": ["0xdcdac54af951034bccc5079e8619f9ce9803a5e2fb90e351571657a62e38b28a"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AA7aoUS2kokAAAAAACYcEwAAAAAARzMAAAHNWK7P0zW+HrPTEeHcgAlj39ctnwEAXQMA5AtUAgAAAAwUzViuz9M1vh6z0xHh3IAJY9/XLZ8MFM1Yrs/TNb4es9MR4dyACWPf1y2fE8AMCHRyYW5zZmVyDBS8r0HWhMfUrW7g2Z2pcHudHwyOZkFifVtSOAFCDEADRhUarLK+/BBjhqaWY5ieento21zgkcsUMWNCBWGd+v8a35zatNRgFbUkni4dDNI/BGc3zOgPT6EwroUsgvR+KQwhAv3yei642bBp1hrlpk26E7iWN8VC2MdMXWurST/mONaPC0GVRA14"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0xdcdac54af951034bccc5079e8619f9ce9803a5e2fb90e351571657a62e38b28a", 1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xdcdac54af951034bccc5079e8619f9ce9803a5e2fb90e351571657a62e38b28a",
        "size": 252,
        "version": 0,
        "nonce": 1151457806,
        "sender": "NedjwsfAJYFas9rn8UHWQftTW4oKAQyW9h",
        "sysfee": "9015990",
        "netfee": "1252390",
        "validuntilblock": 13127,
        "signers": [
            {
                "account": "0x9f2dd7df630980dce111d3b31ebe35d3cfae58cd",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AwDkC1QCAAAADBTNWK7P0zW+HrPTEeHcgAlj39ctnwwUzViuz9M1vh6z0xHh3IAJY9/XLZ8TwAwIdHJhbnNmZXIMFLyvQdaEx9StbuDZnalwe50fDI5mQWJ9W1I4",
        "witnesses": [
            {
                "invocation": "DEADRhUarLK+/BBjhqaWY5ieento21zgkcsUMWNCBWGd+v8a35zatNRgFbUkni4dDNI/BGc3zOgPT6EwroUsgvR+",
                "verification": "DCEC/fJ6LrjZsGnWGuWmTboTuJY3xULYx0xda6tJP+Y41o8LQZVEDXg="
            }
        ],
        "blockhash": "0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",
        "confirmations": 44,
        "blocktime": 1605687708300,
        "vmstate": "HALT"
    }
}
```



