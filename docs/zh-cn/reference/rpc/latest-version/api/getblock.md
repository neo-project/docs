# getblock 方法

根据指定的哈希或索引，返回对应的区块信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- hash | index：区块哈希或区块索引（即区块高度=区块数-1）。

- verbose：可选参数，verbose 默认值为 0。
  - verbose 为 0 时返回的是区块的序列化后的信息，用 16 进制字符串表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  - verbose 为 1 时返回的是对应区块的详细信息，用 Json 格式字符串表示。

## 调用示例

**示例1 - 使用区块哈希调用**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["0xdf9c92cdb8d503214d0bf6c231ccbfa25c20ce24fc4d03a966760e4423889710", 0],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAAFjOB3LXvZFhG/DF9PnA4Zh/buBfAFhvwG6JAzP4EAht5itJ14qK/tiaUxujBBTdZAYFAKnwJroJd8AQAp+vHgzyjenQdQEAANAHAAD6lrDvowCyjK9dBALCmE1fvMuahQFCDEBxGiRWC9d/xNWdbZ1uM9Z/yBVoPLKG6WTQ22aMOgk/AwQMTFdgoZEoSkvyA0791Y1AV146AJEu2R/jFOZZyj37KxEMIQL4L//X3jDpIyMLze0sPNW+yFcufrrL3bnzOipdJpNLixELQRON768BAGgp5HJL+bHp"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": ["0xdf9c92cdb8d503214d0bf6c231ccbfa25c20ce24fc4d03a966760e4423889710", 1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xdf9c92cdb8d503214d0bf6c231ccbfa25c20ce24fc4d03a966760e4423889710",
        "size": 222,
        "version": 0,
        "previousblockhash": "0x6d0810f83303896ec06f58005fe06e7f98e1c0f9f4c5f01b6191bdd77207ce58",
        "merkleroot": "0x0c1eaf9f0210c07709ba26f0a900050664dd1404a31b539ad8fe8a8ad7492be6",
        "time": 1605527768562,
        "index": 2000,
        "nextconsensus": "NikxdvEetzBKLHAddYJ7BHZT9USwm8qGFP",
        "witnesses": [
            {
                "invocation": "DEBxGiRWC9d/xNWdbZ1uM9Z/yBVoPLKG6WTQ22aMOgk/AwQMTFdgoZEoSkvyA0791Y1AV146AJEu2R/jFOZZyj37",
                "verification": "EQwhAvgv/9feMOkjIwvN7Sw81b7IVy5+usvdufM6Kl0mk0uLEQtBE43vrw=="
            }
        ],
        "consensusdata": {
            "primary": 0,
            "nonce": "e9b1f94b72e42968"
        },
        "tx": [],
        "confirmations": 5313,
        "nextblockhash": "0x09638b66b8254485b594e7849dc279675e7631a06cdff857bee6991c1daa8105"
    }
}
```

**示例2 - 使用区块索引调用**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [7368],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAACMSKFbGpGl6t7uroMpi2ilhQd84eU/pUrRfQyswXYl76woLOY0oW1z4InfxoKyxFAAB+8FS6cRu2Pm0iaOiD8OMCnLadQEAAMgcAAD6lrDvowCyjK9dBALCmE1fvMuahQFCDEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wCKxEMIQL4L//X3jDpIyMLze0sPNW+yFcufrrL3bnzOipdJpNLixELQRON768CAGUTt7+NSxXGAA7aoUS2kokAAAAAACYcEwAAAAAARzMAAAHNWK7P0zW+HrPTEeHcgAlj39ctnwEAXQMA5AtUAgAAAAwUzViuz9M1vh6z0xHh3IAJY9/XLZ8MFM1Yrs/TNb4es9MR4dyACWPf1y2fE8AMCHRyYW5zZmVyDBS8r0HWhMfUrW7g2Z2pcHudHwyOZkFifVtSOAFCDEADRhUarLK+/BBjhqaWY5ieento21zgkcsUMWNCBWGd+v8a35zatNRgFbUkni4dDNI/BGc3zOgPT6EwroUsgvR+KQwhAv3yei642bBp1hrlpk26E7iWN8VC2MdMXWurST/mONaPC0GVRA14"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [7368,1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x5f0b81b921eebf719f97e98e8c56e260db8720138b4a7def766b1498a3f4296b",
        "size": 474,
        "version": 0,
        "previousblockhash": "0x7b895d302b435fb452e94f7938df416129da62caa0abbbb77a69a4c656281223",
        "merkleroot": "0xc30fa2a389b4f9d86ec4e952c1fb010014b1aca0f17722f85c5b288d390b0aeb",
        "time": 1605687708300,
        "index": 7368,
        "nextconsensus": "NikxdvEetzBKLHAddYJ7BHZT9USwm8qGFP",
        "witnesses": [
            {
                "invocation": "DEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wC",
                "verification": "EQwhAvgv/9feMOkjIwvN7Sw81b7IVy5+usvdufM6Kl0mk0uLEQtBE43vrw=="
            }
        ],
        "consensusdata": {
            "primary": 0,
            "nonce": "c6154b8dbfb71365"
        },
        "tx": [
            {
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
                ]
            }
        ],
        "confirmations": 2,
        "nextblockhash": "0x1545a328149baf8037873793d7e45d27385221dd69ddb606ee55434eb173a3ff"
    }
}
```





