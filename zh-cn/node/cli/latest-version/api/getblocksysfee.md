# getblocksysfee 方法

根据指定的索引，返回截止到该区块前的系统手续费。

## 参数说明

index：区块索引。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblocksysfee",
  "params": [1005434],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "195500"
}
```

响应说明：

result：截止到该区块前的系统手续费，单位为 NeoGas。