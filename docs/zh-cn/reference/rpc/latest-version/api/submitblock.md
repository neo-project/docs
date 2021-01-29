# submitblock 方法

在 Neo 网络广播新的区块。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用 

## 参数说明

block: 序列化区块的 Base64 编码。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "submitblock",
  "params": ["AAAAACMSKFbGpGl6t7uroMpi2ilhQd84eU/pUrRfQyswXYl76woLOY0oW1z4InfxoKyxFAAB+8FS6cRu2Pm0iaOiD8OMCnLadQEAAMgcAAD6lrDvowCyjK9dBALCmE1fvMuahQFCDEAd8EoEFBcxOLCZfh8w0tUEHHmyn++KzW4I8oeJ1WyMmjHVcolpNzOnAOzXTn/xujwy93gJ9ijvVo6wAF5qC3wCKxEMIQL4L//X3jDpIyMLze0sPNW+yFcufrrL3bnzOipdJpNLixELQRON768CAGUTt7+NSxXGAA7aoUS2kokAAAAAACYcEwAAAAAARzMAAAHNWK7P0zW+HrPTEeHcgAlj39ctnwEAXQMA5AtUAgAAAAwUzViuz9M1vh6z0xHh3IAJY9/XLZ8MFM1Yrs/TNb4es9MR4dyACWPf1y2fE8AMCHRyYW5zZmVyDBS8r0HWhMfUrW7g2Z2pcHudHwyOZkFifVtSOAFCDEADRhUarLK+/BBjhqaWY5ieento21zgkcsUMWNCBWGd+v8a35zatNRgFbUkni4dDNI/BGc3zOgPT6EwroUsgvR+KQwhAv3yei642bBp1hrlpk26E7iWN8VC2MdMXWurST/mONaPC0GVRA14"],
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

