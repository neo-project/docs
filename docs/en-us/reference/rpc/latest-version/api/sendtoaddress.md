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

  e.g. NEO is 0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789

  Gas is 0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b

* address: Payment address

* value: Amount transferred

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b","NPJRHLjDm4r1wd8wHBGFRWqzsneFX9tBch", 5000],
  "id": 1
}
```

Response body:

```json
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x09df034eee12224964ccc0c93fcfbfce8d922ab2b0b673388fd8951d2f25d5d9",
        "size": 272,
        "version": 0,
        "nonce": 760727272,
        "sender": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
        "sys_fee": "100000000",
        "net_fee": "1272390",
        "valid_until_block": 2136389,
        "attributes": [],
        "cosigners": [
            {
                "account": "0x39e7394d6231aa09c097d02391d5d149f873f12b",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "AwCIUmp0AAAADBQlJ1AGgA5zzGQoZ1OjpzJCJSHI5AwUK/Fz+EnR1ZEj0JfACaoxYk055zkTwAwIdHJhbnNmZXIMFDt9NxHG8Mz5sdypA9G/odiW8SOMQWJ9W1I5",
        "witnesses": [
            {
                "invocation": "DEBPVJeyFAroQcgVtVi9qmbemtAV1cIIdivDELileXwlbNFanQqRXq9UV5CxHA5qQ/U7beaJcLdQBiAPIkvGXSdZ",
                "verification": "DCEDucRsbVxnHvXCG8eqfDBGiusIGi44lSaa35R3GNZQzh4LQQqQatQ="
            }
        ]
    }
}
```

Response Description:

Returning of the transaction details above indicates that the transaction was sent successfully. If not, the transaction has failed to send.

If the signature is incomplete, it returns the transaction to be signed.

If the balance is insufficient, it returns an error message.
