# openwallet Method

Opens the specified wallet file.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke this method.

## Parameter Description

path: The wallet file path
password: In plain text.

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

