# getmetricblocktimestamp Method

Returns timestamps of the specified block and its previous n blocks.

> [!Note]
>
> This method is provided by the plugin [CoreMetrics](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Parameter Description

`blocks numbers`：Set the number of blocks you want to query forward.

`endHeight`：Set the the block height your query ends.

## Example

Request body：

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

Response body：

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


