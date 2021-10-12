# sendtoaddress Method

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

* value: Amount transferred

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
    "hash": "0xe332419b8da788c3f149959cb7667aa6a796f4c4a2c49285ee65ef21e7acbb8e",
    "size": 382,
    "version": 0,
    "nonce": 1204566489,
    "sender": "NTpqYncLsNNsMco71d9qrd5AWXdCq8YLAA",
    "sysfee": "9931700",
    "netfee": "2349040",
    "validuntilblock": 6368,
    "signers": [
      {
        "account": "0x5c28b5a260007f0ad17d03290fccd20a148dc856",
        "scopes": "None"
      },
      {
        "account": "0x90fa3f7e87adbf95f6e8e606d9c678e23097d7d7",
        "scopes": "CalledByEntry"
      }
    ],
    "attributes": [],
    "script": "CwMA5AtUAgAAAAwUYp1qsnQL/DbfcYBBG6gP2HgdKb0MFNfXlzDieMbZBubo9pW/rYd+P/qQFMAfDAh0cmFuc2ZlcgwUz3bii9AGLEpHjuNVYQETGfPPpNJBYn1bUjk=",
    "witnesses": [
      {
        "invocation": "DEB2IMlTiOX9zJYgVLe6hVLXWW3OTiv1NyqOiIMzCAPJf0G9ITh/MSRTu4pW8lHn6iF7yVFbZUuNm6iXKH3+g4dS",
        "verification": "DCEDpDw8zJ19ja9Vjl2syj9wppx0tqXaCw43Xg8Zn221XuRBdHR2qg=="
      },
      {
        "invocation": "DEDgesB10fw0goXgn2jQmtteSgCxjhX3E5IU/sclk1Aqea/OUzfm/1khO9J3sh420YxAPKoddx+4BdeTrkCtogtp",
        "verification": "DCED4IgjtEOZ9qKqIkiDTZIKFas66S3HVjz35D/d1bHAGC9BdHR2qg=="
      }
    ]
  }
}
```

Response Description:

Returning of the transaction details above indicates that the transaction was sent successfully. If not, the transaction has failed to send.

If the signature is incomplete, it returns the transaction to be signed.

If the balance is insufficient, it returns an error message.
