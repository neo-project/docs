# getclaimable Method

Returns claimable GAS information of the specified address.

> [!Note]
>
> This method is provided by the plugin [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Parameters Description

`address`：Specifiies the address you want to query.

## Example

Request body:

```json
{
    "jsonrpc": "2.0",
    "method": "getclaimable",
    "params": ["AGofsxAUDwt52KjaB664GYsqVAkULYvKNt"],
    "id": 1
}
```

Response body:

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


