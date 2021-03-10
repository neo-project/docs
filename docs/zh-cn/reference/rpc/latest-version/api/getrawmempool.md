# getrawmempool 方法

获取内存中已确认或未确认的交易列表。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 调用示例

##### 示例1 - 获取已确认交易

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
  "params": [],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        "0x9786cce0dddb524c40ddbdd5e31a41ed1f6b5c8a683c122f627ca4a007a7cf4e",
        "0xb488ad25eb474f89d5ca3f985cc047ca96bc7373a6d3da8c0f192722896c1cd7",
        "0xf86f6f2c08fbf766ebe59dc84bc3b8829f1053f0a01deb26bf7960d99fa86cd6"
    ]
}
```

这些是节点收到的已确定的交易。

##### 示例2 - 获取已确认与未确认交易

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
  "params": [true],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "height": 5882071,
    "verified": [
      "0x0c65fbfd2598aee5f30cd18f1264b458f1db137c4a460f4a174facb3f2d59d06",
      "0xc8040c285aa495f5b5e5b3761fd9333899f4ed902951c46d86c3bbb1cb12f2c0"
    ],
    "unverified": []
  }
}
```

