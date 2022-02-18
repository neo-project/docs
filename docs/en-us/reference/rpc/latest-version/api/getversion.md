﻿# getversion Method

Returns the version information of the node.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getversion",
  "params": [],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "tcpport": 10333,
        "wsport": 10334,
        "nonce": 1930156121,
        "useragent": "/Neo:3.0.3/",
        "protocol": {
            "addressversion": 53,
            "network": 860833102,
            "validatorscount": 7,
            "msperblock": 15000,
            "maxtraceableblocks": 2102400,
            "maxvaliduntilblockincrement": 5760,
            "maxtransactionsperblock": 512,
            "memorypoolmaxtransactions": 50000,
            "initialgasdistribution": 5200000000000000
        }
    }
}
```
