﻿# sendtoaddress Method

Transfers to the specified address.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) 
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

* asset_id： Asset ID (asset identifier),  the script hash of NEP-17 contract

  e.g. NeoToken is 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5

  GasToken is 0xd2a4cff31913016155e38e474a2c06d08be276cf

* address: Payment address

* value: The amount transferred. It is a large integer without precision. For example, to transfer 0.000001 GAS (precision is 8), enter 100 here; To transfer 100 GAS, enter 10000000000.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["0xd2a4cff31913016155e38e474a2c06d08be276cf", "NUuPz4k387bHuySx2e2RWhZj5SpF8V4Csy", 100],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x4c072646cf9515dd2a5df9fc4df0563a4f2e468910d24a9b2196743bcea8b8f0",
        "size": 246,
        "version": 0,
        "nonce": 573855568,
        "sender": "NSXYk7V6bgrwCJJbh5m8ZGCy1fbREY4gk5",
        "sysfee": "9977780",
        "netfee": "1229520",
        "validuntilblock": 17307,
        "signers": [
            {
                "account": "0x580d152d36db6f34c9aaf676facbbe2779538b48",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CwBkDBRinWqydAv8Nt9xgEEbqA/YeB0pvQwUSItTeSe+y/p29qrJNG/bNi0VDVgUwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtSOQ==",
        "witnesses": [
            {
                "invocation": "DEDROjmUBKzywJa+WCD9MttL6V+3i+HvjnfW8hMjT5y8zMcXzqt4HI2/72YM/aS2nfWPXOfJVXZmK/89mSJqPVX6",
                "verification": "DCECUDQqDEv7ud85rbYDDT8/i+vdyxW46/e8TMrafzqJui5BVuezJw=="
            }
        ]
    }
}
```

Response Description:

Returning of the transaction details above indicates that the transaction was sent successfully. If not, the transaction has failed to send.

If the signature is incomplete, it returns the transaction to be signed.

If the balance is insufficient, it returns an error message.
