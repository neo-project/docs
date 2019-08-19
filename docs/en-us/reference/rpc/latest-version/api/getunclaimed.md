# getunclaimed Method

Returns unclaimed GAS amount of the specified address.

> [!Note]
>
> This method is provided by the plugin [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Parameter Description

`address`：Set the standard address you want to query.

## Example

Request body：

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

Response body：

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


