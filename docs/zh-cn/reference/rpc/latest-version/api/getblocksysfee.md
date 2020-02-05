# getblocksysfee 方法

根据指定的索引，返回截止到该区块前的系统手续费。
> [!Note]
>
> 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

index：区块索引。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getblocksysfee",
  "params": [70000],
  "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "33200000000"
}
```

响应说明：

result：截止到该区块前的系统手续费，单位为 NeoGas。