# getstateheight Method

Gets the latest block height and the the verified state height.

#### Example

Request text:

```json
{
  "jsonrpc": "2.0",
  "method": "getstateheight",
  "params": [],
  "id": 1
}
```

Response text:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "blockheight": 6143917,
    "stateheight": 6143916
  }
}
```

Response description:

`blockheight`: Block height that has been synchronized.

`stateheight`: Height of the verified StateRoot