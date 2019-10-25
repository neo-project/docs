# getrawmempool 方法

获取内存中确认 / 未确认的交易列表。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
  "params": [shouldGetUnverified],
  "id": 1
}
```

### 参数说明

* shouldGetUnverified：可选参数，shouldGetUnverified 默认值为 0。
  * 为 0 时，返回的是内存池中已经确认过的交易hash列表。
  * 为 1 时，返回的信息包含当前高度，内存池中已经确认过以及未确认过的交易hash列表。

## 调用示例

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

请求正文：

verbose = 1，返回当前高度，内存池中已经确认过以及未确认过的交易hash列表。

```json
{
  "jsonrpc": "2.0",
  "method": "getrawmempool",
  "params": [1],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        "height": 6180,
        "verified": [
            "0x9786cce0dddb524c40ddbdd5e31a41ed1f6b5c8a683c122f627ca4a007a7cf4e",
            "0xb488ad25eb474f89d5ca3f985cc047ca96bc7373a6d3da8c0f192722896c1cd7",
            "0xf86f6f2c08fbf766ebe59dc84bc3b8829f1053f0a01deb26bf7960d99fa86cd6"
        ],
        "unverified": [
            "0xdd4372964d52e800e07b7d1c536a0ad29022edbf506603c01a4efa6cc0b4e1c6"
        ]
    ]
}
```

