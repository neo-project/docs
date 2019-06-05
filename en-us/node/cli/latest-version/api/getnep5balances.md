# getnep5balances Method

Returns the balance of all NEP-5 assets in the specified address.

> [!Note]
>
> This method is provided by the plugin [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Parameter Description

address：The address that you want to query balance.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep5balances",
  "params": ["1aada0032aba1ef6d1f07bbd8bec1d85f5380fb3"],
  "id": 1
}
```

Response body：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": [
            {
                "asset_hash": "a48b6e1291ba24211ad11bb90ae2a10bf1fcd5a8",
                "amount": "50000000000",
                "last_updated_block": 251604
            },
            {
                "asset_hash": "1aada0032aba1ef6d1f07bbd8bec1d85f5380fb3",
                "amount": "50000000000",
                "last_updated_block": 251600
            }
        ],
        "address": "AY6eqWjsUFCzsVELG7yG72XDukKvC34p2w"
    }
}
```



> [!Note]
> 
>- Only when your client synchronizes to the block that the contract was deployed, execution of this API will return the correct value, otherwise execution of the API will result in an error. 
> - When the input parameter is a script hash of a non-NEP-5 smart contract, execution of the API will result in an error. 
>- Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.

