# getblockhash 方法

根据指定的区块高度，返回对应的区块hash

```json
{
  "jsonrpc": "2.0",
  "method": "getblockhash",
  "params": [index],
  "id": 1
}
```
### 参数说明

* index：区块索引。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblockhash",
  "params": [10000],
  "id": 1
}
```

响应正文：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": "0x4c1e879872344349067c3b1a30781eeb4f9040d3795db7922f513f6f9660b9b2"
}
```
