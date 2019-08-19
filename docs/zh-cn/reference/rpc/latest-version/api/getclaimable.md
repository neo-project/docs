# getclaimable 方法

返回指定地址内可以 claim 的 GAS 信息。

> [!Note]
>
> 此方法由插件提供，需要安装 [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

`address`：指定要查询的账户地址。

## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "getclaimable",
    "params": ["AGofsxAUDwt52KjaB664GYsqVAkULYvKNt"],
    "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "claimable": [
            {
                "txid": "52ba70ef18e879785572c917795cd81422c3820b8cf44c24846a30ee7376fd77",
                "n": 1,
                "value": 800000,
                "start_height": 476496,
                "end_height": 488154,
                "generated": 746.112,
                "sys_fee": 3.92,
                "unclaimed": 750.032
            }
        ],
        "address": "AGofsxAUDwt52KjaB664GYsqVAkULYvKNt",
        "unclaimed": 750.032
    }
}
```


