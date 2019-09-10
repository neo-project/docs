# getmetricblocktimestamp 方法

返回指定区块高度及之前 n 个区块的 timestamp。

> [!Note]
>
> 此方法由插件提供，需要安装 [CoreMetrics](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

`blocks numbers`：设置返回时间戳的区块数量

`endHeight`：设置截止区块高度

## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "getmetricblocktimestamp",
    "params": [
        10,
        460000
    ],
    "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": [
        {
            "timestamp": 1556138776,
            "height": 459990
        },
        {
            "timestamp": 1556138791,
            "height": 459991
        },
        {
            "timestamp": 1556138822,
            "height": 459992
        },
        {
            "timestamp": 1556138839,
            "height": 459993
        },
        {
            "timestamp": 1556138854,
            "height": 459994
        },
        {
            "timestamp": 1556138869,
            "height": 459995
        },
        {
            "timestamp": 1556138902,
            "height": 459996
        },
        {
            "timestamp": 1556138917,
            "height": 459997
        },
        {
            "timestamp": 1556138932,
            "height": 459998
        },
        {
            "timestamp": 1556138947,
            "height": 459999
        },
        {
            "timestamp": 1556138981,
            "height": 460000
        }
    ]
}
```


