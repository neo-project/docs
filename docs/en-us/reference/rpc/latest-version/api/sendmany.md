# sendmany Method

Bulk transfer order, and you can specify a change address.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) 
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
  {"asset": <asset>,"value": <value>,"address": <address>, "signers": <signers>}
  ```

  * `asset`: Asset ID (asset identifier),  the NEP-17 contract scripthash
  
    e.g. NeoToken is: 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5
  
    GasToken is: 0xd2a4cff31913016155e38e474a2c06d08be276cf
  
  * `value`: Transfer amount
  
  * `address`: Destination address
  
  * `signers`: The signature account of transaction

## Example

Request text:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "sendmany",
    "params": [
        "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        [
            {
                "asset": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "value": 10,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            },
            {
                "asset": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "value": 50000000,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            }
        ]
    ]
}
```

Request text (with fromAddress):

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [
     "NY9nnDv7cAJ44C2xeRScrXfzkrCJfFWYku",
	[
	    {
			    "asset": "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5", 
			    "value": 100, 
					"address": "NbtvbHpwv6nswDtVFpKEyooHhDHwZh2LHf"
			}, 
			{
			     "asset": "0xd2a4cff31913016155e38e474a2c06d08be276cf", 
					 "value": 100, 
					 "address": "NbtvbHpwv6nswDtVFpKEyooHhDHwZh2LHf"
			},
			    {
			    "asset": "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5", 
			    "value": 100, 
					"address": "NPTvd2T1zi7ioj3LmvpeBd45pPvAJU3gvr"
			}, 
			{
			     "asset": "0xd2a4cff31913016155e38e474a2c06d08be276cf", 
					 "value": 100, 
					 "address": "NPTvd2T1zi7ioj3LmvpeBd45pPvAJU3gvr"
			}
	 ]
	 ],
  "id": 1
}
```

Response text:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "hash": "0xe8742fc5a69f3180ab59f3f21695ce5459891429682a7f1df38219bc05cce39e",
    "size": 514,
    "version": 0,
    "nonce": 537723951,
    "sender": "NY9nnDv7cAJ44C2xeRScrXfzkrCJfFWYku",
    "sysfee": "39726800",
    "netfee": "1497580",
    "validuntilblock": 6357,
    "signers": [
      {
        "account": "0x9dd95824d6a1789d5bb665abd727d0c387a53e86",
        "scopes": "CalledByEntry"
      }
    ],
    "attributes": [],
    "script": "CwBkDBSvT25X7NLzUvxKKqw14LOzO554tQwUhj6lh8PQJ9erZbZbnXih1iRY2Z0UwB8MCHRyYW5zZmVyDBT1Y+pAvCg9TQ4FxI6jBbPyoHNA70FifVtSOQsAZAwUJvOMLBhLx7odYBaJkOQJlbxNJF4MFIY+pYfD0CfXq2W2W514odYkWNmdFMAfDAh0cmFuc2ZlcgwU9WPqQLwoPU0OBcSOowWz8qBzQO9BYn1bUjkLAGQMFK9Pblfs0vNS/EoqrDXgs7M7nni1DBSGPqWHw9An16tltludeKHWJFjZnRTAHwwIdHJhbnNmZXIMFM924ovQBixKR47jVWEBExnzz6TSQWJ9W1I5CwBkDBQm84wsGEvHuh1gFomQ5AmVvE0kXgwUhj6lh8PQJ9erZbZbnXih1iRY2Z0UwB8MCHRyYW5zZmVyDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtSOQ==",
    "witnesses": [
      {
        "invocation": "DEDxTxMc/IKpEzhfYV0bMv8qUEL1na7LvrnK3hisz1SBoYJr2SF7SpXY0RzA/1x5QfHEuxHUuvelul1aiDjFenYD",
        "verification": "EQwhA+CII7RDmfaiqiJIg02SChWrOuktx1Y89+Q/3dWxwBgvEUF7zmyl"
      }
    ]
  }
}
```

Response Description:

Returns the transaction details as above if the transaction was sent successfully; otherwise the transaction is failed.

If the JSON format is incorrect, a Parse error is returned. If the signature is incomplete, a pending transaction is returned. If the balance is insufficient, an error message is returned.
