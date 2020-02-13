# getnep5balances Method

Returns the balance of all NEP-5 assets in the specified address.

> [!Note]
>
> You must install the plugin [RpcNep5Tracker](https://github.com/neo-project/neo-plugins/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

address: The address that you want to query balance.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep5balances",
  "params": ["NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1", 0],
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
                "asset_hash": "0x8d06bc235c2585c9d27ede8ed7085b3e13fc0c36",
                "amount": "9990000000000000",
                "last_updated_block": 17418
            },
            {
                "asset_hash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "amount": "1002531616708175",
                "last_updated_block": 54499
            },
            {
                "asset_hash": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "amount": "9999785",
                "last_updated_block": 54496
            },
            {
                "asset_hash": "0x433f0891e80c107b9e63d5f5b7cddf1fc35eb0b9",
                "amount": "9999200000000000",
                "last_updated_block": 19810
            },
            {
                "asset_hash": "0x9c33bbf2f5afbbc8fe271dd37508acd93573cffc",
                "amount": "9995000000000000",
                "last_updated_block": 17145
            }
        ],
        "address": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1"
    }
}
```



> [!Note]
> 
>- Only when your client synchronizes to the block that the contract was deployed, execution of this API will return the correct value, otherwise execution of the API will result in an error. 
> - When the input parameter is a script hash of a non-NEP-5 smart contract, execution of the API will result in an error. 
>- Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.

