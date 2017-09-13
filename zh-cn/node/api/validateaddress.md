# validateaddress 方法

验证地址是否是正确的 NEO 地址。

## 参数说明

address：地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "AQVh2pG732YvtNaxEGkQUei3YA4cvo7d2i",
        "isvalid": true
    }
}
```

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "validateaddress",
  "params": ["152f1muMCNa7goXYhYAQC61hxEgGacmncB"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "152f1muMCNa7goXYhYAQC61hxEgGacmncB",
        "isvalid": false
    }
}
```



