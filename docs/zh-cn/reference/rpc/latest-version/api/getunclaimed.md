# getunclaimed 方法

返回指定地址中未提取的 GAS 数量。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

address：要查询的账户地址，该地址需为标准地址。

## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "getunclaimed",
    "params": [
        "AGofsxAUDwt52KjaB664GYsqVAkULYvKNt"
    ],
    "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "available": 750.032,
        "unavailable": 2815.408,
        "unclaimed": 3565.44
    }
}
```


