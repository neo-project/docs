# sendmany Method

Bulk transfer order, and you can specify a change address.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [from, outputs_array],
  "id": 1
}
```

### Parameter Description

* `from`: Optional. The address from which you transfer the asset.

* `outputs_array`：Array, the data structure of each element in the array is as follows:

  ```json
  {"asset": <asset>,"value": <value>,"address": <address>}
  ```

  * `asset`：Asset ID (asset identifier),  the NEP-5 contract scripthash
  
    e.g. NEO is 0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789
  
    Gas is 0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b
  
  * `value`：Transfer amount
  
  * `address`：destination address.

## Example

**Example 1 - transferring from a specified address**

Request body：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "sendmany",
  "params": [
    "NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y",
    [
      {
                "asset": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "value": 1,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            },
            {
                "asset": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "value": 2,
                "address": "NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8"
            },
            {
                "asset": "0xde5f57d430d3dece511cf975a8d37848cb9e0525",
                "value": 2,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            }
    ]    
  ]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x01ccb37af435f0e7220473ae51334e5f2c2d896968411c14044537e22b8e045e",
        "size": 424,
        "version": 0,
        "nonce": 93138602,
        "sender": "NNU67Fvdy3LEQTM374EJ9iMbCRxVExgM8Y",
        "sysfee": "27023970",
        "netfee": "1424390",
        "validuntilblock": 2105183,
        "signers": [
            {
                "account": "0xf621168b1fce3a89c33a5f6bcf7e774b4657031c",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AgDh9QUMFLC8S2S+4uI9PTLeAsqsGFP6u7QDDBQcA1dGS3d+z2tfOsOJOs4fixYh9hPADAh0cmFuc2ZlcgwUvK9B1oTH1K1u4NmdqXB7nR8MjmZBYn1bUjgCAMLrCwwUmGL6/A4hyqdG0rkGv+99E0FTUYQMFBwDV0ZLd37Pa186w4k6zh+LFiH2E8AMCHRyYW5zZmVyDBS8r0HWhMfUrW7g2Z2pcHudHwyOZkFifVtSOBIMFLC8S2S+4uI9PTLeAsqsGFP6u7QDDBQcA1dGS3d+z2tfOsOJOs4fixYh9hPADAh0cmFuc2ZlcgwUJQWey0h406h1+RxRzt7TMNRXX95BYn1bUjg=",
        "witnesses": [
            {
                "invocation": "DEB4NucKpf2vnr18txXcHI5hFDWTZNXZsamoxkkOfHPlKNfYgZloDb6v4wsdjkrMoohEXBqW2cc6fVxsgOQEYxOV",
                "verification": "DCECIthRUYTH1i/6mbgprrSTjEcE7LDdfjQOhC6d8SGCY0MLQZVEDXg="
            }
        ]
    }
}
```

**Example 2 - transferring without specifying an address**

Request body：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "sendmany",
  "params": [
    [
      {
                "asset": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "value": 1,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            },
            {
                "asset": "0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc",
                "value": 2,
                "address": "NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8"
            },
            {
                "asset": "0xde5f57d430d3dece511cf975a8d37848cb9e0525",
                "value": 2,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            }
    ]    
  ]
}
```

Response body：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x9598b1ae5c6d339c04efe6d4a7e7f2c02dec22a7f6a77890650760becbf86ed3",
        "size": 554,
        "version": 0,
        "nonce": 1571115423,
        "sender": "NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8",
        "sysfee": "27023970",
        "netfee": "2554780",
        "validuntilblock": 2105186,
        "signers": [
            {
                "account": "0x84515341137defbf06b9d246a7ca210efcfa6298",
                "scopes": "CalledByEntry"
            },
            {
                "account": "0xb120f50f804d3a203c43475212894ab1c911ce18",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AgDh9QUMFLC8S2S+4uI9PTLeAsqsGFP6u7QDDBSYYvr8DiHKp0bSuQa/730TQVNRhBPADAh0cmFuc2ZlcgwUvK9B1oTH1K1u4NmdqXB7nR8MjmZBYn1bUjgCAMLrCwwUmGL6/A4hyqdG0rkGv+99E0FTUYQMFJhi+vwOIcqnRtK5Br/vfRNBU1GEE8AMCHRyYW5zZmVyDBS8r0HWhMfUrW7g2Z2pcHudHwyOZkFifVtSOBIMFLC8S2S+4uI9PTLeAsqsGFP6u7QDDBQYzhHJsUqJElJHQzwgOk2AD/UgsRPADAh0cmFuc2ZlcgwUJQWey0h406h1+RxRzt7TMNRXX95BYn1bUjg=",
        "witnesses": [
            {
                "invocation": "DEBIGjD61/KPyUq51sfsgla6MlruIbBG3eYkmI2cWXHrcGYMm6ucO6Va2Dc7v7mzF8XnQvJtrBVjv/caRpqt08OA",
                "verification": "DCECIItAHAHzOQfla6fHzYkOv5cXTzazCk9DZ6xRAlIUXH4LQZVEDXg="
            },
            {
                "invocation": "DEC5O1ZFX46Vhdm4H8uY3IfYWHMbMnIkl5QljOYK8lVIfinYfbvyFuHsELDUM1io1RrbShjwkoFiVG1UKfC0nlqC",
                "verification": "DCECi9GQLE0UGfACuCHm3mU939U1gGMgjkJnVjmL5v+jqsgLQZVEDXg="
            }
        ]
    }
}
```

Response Description:

Returns the transaction details as above if the transaction was sent successfully; otherwise the transaction is failed.

If the JSON format is incorrect, a Parse error is returned. If the signature is incomplete, a pending transaction is returned. If the balance is insufficient, an error message is returned.
