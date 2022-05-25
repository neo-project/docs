# getnep11properties 方法

获取 NEP-11 资产的自定义属性，其中 name、description、image、tokenURI 属性会自动使用 UTF8 解码。

> [!Note]
>
> 此方法由插件提供，需要安装 [TokensTracker](https://github.com/neo-project/neo-modules/releases) 、[LevelDBStore](https://github.com/neo-project/neo-modules/releases) 和 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- contract：合约hash

- tokenId：token id 的hex字符串


## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep11properties",
  "params": ["0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f","452023313032204e6f697a"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "name": "E #102 Noiz",
        "owner": "wJjkrPCyCQ3Rbss9WN5CaocVhRs=",
        "number": "Zg==",
        "image": "https://neo.org/Noiz.png",
        "video": null
    }
}
```



