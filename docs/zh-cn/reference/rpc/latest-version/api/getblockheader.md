# getblockheader 方法

根据指定的哈希或索引，返回对应的区块头信息。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- hash | index：区块哈希或索引（即区块高度 = 区块数 - 1）

- verbose：可选参数，verbose 默认值为 0。
  - verbose 为 0 时返回的是区块的序列化后的信息，用 16 进制字符串表示，如果从中获取详细信息需要调用 SDK 来进行反序列化。
  - verbose 为 1 时返回的是对应区块的详细信息，用 Json 格式字符串表示。

## 调用示例

**示例1 - 使用区块哈希调用**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0xdf17b40c5627a45e83d61b286a6d6d14859136621760d0a5b58dd59d18fd53d4", 0],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "0000000059ff9a2ff0861bda1abf89e07a3d248def4cf4fd4493c23d32bcf9bc741b92867ac9948cd23059eb880182e443b5eb3c75ec68404d01ff7b3c8f85a6651a6aefdc0687a06f0100001027000057c8f7a5b8d6758f18fb906eaf03f007da0a9f2601420c4026a4ba2eba339629ce40817053625dc315c294cea30863bb56d15a7fb2f3445d615fa0d201b940e3df662c71b200e355b8193e746b36143dcb9de3669962fc852b110c21021e1563aa32a5191ff7198e8c28ef02a8c6b33aecf326f5b32c6a620138d4201b110b413073b3bb00"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": ["0xdf17b40c5627a45e83d61b286a6d6d14859136621760d0a5b58dd59d18fd53d4",1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xdf17b40c5627a45e83d61b286a6d6d14859136621760d0a5b58dd59d18fd53d4",
        "size": 213,
        "version": 0,
        "previousblockhash": "0x86921b74bcf9bc323dc29344fdf44cef8d243d7ae089bf1ada1b86f02f9aff59",
        "merkleroot": "0xef6a1a65a6858f3c7bff014d4068ec753cebb543e4820188eb5930d28c94c97a",
        "time": 1578946201308,
        "index": 10000,
        "nextconsensus": "NTv8iuL3yf4eiskKWWrtXLq9fKrX6LNGrG",
        "witnesses": [
            {
                "invocation": "DEAmpLouujOWKc5AgXBTYl3DFcKUzqMIY7tW0Vp/svNEXWFfoNIBuUDj32YscbIA41W4GT50azYUPcud42aZYvyF",
                "verification": "EQwhAh4VY6oypRkf9xmOjCjvAqjGszrs8yb1syxqYgE41CAbEQtBMHOzuw=="
            }
        ],
        "confirmations": 91937,
        "nextblockhash": "0xe5ee6885a736e194c14bb020dca34bd6effe4280fbaec4542e41e4bebd8d4870"
    }
}
```

**示例2 - 使用区块索引调用**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [6000, 0],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "0000000020c213cb72392bd365e1e7e4ff9958e83761cd104d49dab0dd05903f7b651fec9939608fd01705162af2b399b57cf21dd2750c52cae18b5848f85f0ca7694983e014539f6f0100007017000057c8f7a5b8d6758f18fb906eaf03f007da0a9f2601420c400eb0087228a71228edf83e635ad0bbcd30a8e0ba04207d26657dbce334e8ea1fa7b6684a393bc6d1e054df39927e9bdf3d89e3cd9cf760a5f8639ae5b27ecc822b110c21021e1563aa32a5191ff7198e8c28ef02a8c6b33aecf326f5b32c6a620138d4201b110b413073b3bb00"
}
```

请求正文：

verbose = 1，返回 JSON 格式的结果。

```json
{
  "jsonrpc": "2.0",
  "method": "getblockheader",
  "params": [6000, 1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xf929babb2b10eed2e3af429c73648ef6d3c05d247494eb95dcdae53a77236ddf",
        "size": 213,
        "version": 0,
        "previousblockhash": "0xec1f657b3f9005ddb0da494d10cd6137e85899ffe4e7e165d32b3972cb13c220",
        "merkleroot": "0x834969a70c5ff848588be1ca520c75d21df27cb599b3f22a160517d08f603999",
        "time": 1578926019808,
        "index": 6000,
        "nextconsensus": "NTv8iuL3yf4eiskKWWrtXLq9fKrX6LNGrG",
        "witnesses": [
            {
                "invocation": "DEAOsAhyKKcSKO34PmNa0LvNMKjgugQgfSZlfbzjNOjqH6e2aEo5O8bR4FTfOZJ+m989iePNnPdgpfhjmuWyfsyC",
                "verification": "EQwhAh4VY6oypRkf9xmOjCjvAqjGszrs8yb1syxqYgE41CAbEQtBMHOzuw=="
            }
        ],
        "confirmations": 150220,
        "nextblockhash": "0x17f3f1d81f2f442053a0bf8ca9a6addeb25646267127bb3b43884f61ed9a2822"
    }
}
```

