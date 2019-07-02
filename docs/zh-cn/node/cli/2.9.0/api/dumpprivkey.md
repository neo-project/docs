# dumpprivkey 方法

导出指定地址的私钥。

> [!Note]
> 执行此命令前需要在 Neo-CLI 节点中打开钱包。

## 参数说明

address：要导出私钥的地址，该地址需为标准地址。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "dumpprivkey",
  "params": ["ASMGHQPzZqxFB2yKmzvfv82jtKVnjhp1ES"],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "L3FdgAisCmV******************************9XM65cvjYQ1"
}
```

响应说明：

返回该标准地址的私钥。
