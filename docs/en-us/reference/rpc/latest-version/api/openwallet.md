# openwallet Method

Opens the specified wallet file. To be on the safe side this method is disabled by default. If you do need to use this method you can manually enable this method in the RpcServer configuration file.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke this method.

## Parameter Description

- path: The wallet file path
- password: In plain text.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "openwallet",
  "params": ["11.db3", "1"],
  "id": 1
}
```

Response body：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": true
}
```

Response description：

true: The wallet is opened.

Others: The wallet cannot be opened.

If `Access denied` is returned this is because `openwallet` is disabled. To enable it, you can remove  `openwallet` in the field DisabledMethods in RpcServer config.json.

