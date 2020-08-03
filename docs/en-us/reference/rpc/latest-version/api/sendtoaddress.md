# sendtoaddress Method

Transfers to the specified address.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": [asset_id,address,value],
  "id": 1
}
```

## Parameter Description

* asset_id： Asset ID (asset identifier),  the script hash of NEP-5 contract

  e.g. NEO is 0xde5f57d430d3dece511cf975a8d37848cb9e0525

  Gas is 0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc

* address: Payment address

* value: Amount transferred

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "sendtoaddress",
  "params": ["0x668e0c1f9d7b70a99dd9e06eadd4c784d641afbc","NPJRHLjDm4r1wd8wHBGFRWqzsneFX9tBch",21]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xfa17173184bce48315f72e11e42362f94019b345e72ca07fd630f186ae29f79f",
        "size": 378,
        "version": 0,
        "nonce": 1657481343,
        "sender": "NZoiUCBHBZ4DquVE5mbdpTQGozvJkWHtE8",
        "sysfee": "9007990",
        "netfee": "2378780",
        "validuntilblock": 2105205,
        "signers": [
            {
                "account": "0x84515341137defbf06b9d246a7ca210efcfa6298",
                "scopes": "FeeOnly"
            },
            {
                "account": "0xb120f50f804d3a203c43475212894ab1c911ce18",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "AgB1K30MFCUnUAaADnPMZChnU6OnMkIlIcjkDBQYzhHJsUqJElJHQzwgOk2AD/UgsRPADAh0cmFuc2ZlcgwUvK9B1oTH1K1u4NmdqXB7nR8MjmZBYn1bUjg=",
        "witnesses": [
            {
                "invocation": "DEBvKiq5NHkE3PsjbXe0YvNmSDq9c6PzoK1fsDljhEAvvoPSqhhoSj+gVyAuQqUKFuBM0O/+HM5xorM8vdm60hNb",
                "verification": "DCECIItAHAHzOQfla6fHzYkOv5cXTzazCk9DZ6xRAlIUXH4LQZVEDXg="
            },
            {
                "invocation": "DEAbhpq036r6sZaRSPXjv+cC6G85rhIDcnpvcFvNmsNFlFoUVUIoyBDUqa/1wxajj5yjH0VPgsvhlBwoK7hGOMZU",
                "verification": "DCECi9GQLE0UGfACuCHm3mU939U1gGMgjkJnVjmL5v+jqsgLQZVEDXg="
            }
        ]
    }
}
```

Response Description:

Returning of the transaction details above indicates that the transaction was sent successfully. If not, the transaction has failed to send.

If the signature is incomplete, it returns the transaction to be signed.

If the balance is insufficient, it returns an error message.
