# getnep17balances Method

Returns the balance of all NEP-5 assets in the specified address.

> [!Note]
>
> You must install the plugin [RpcNep17Tracker](https://github.com/neo-project/neo-plugins/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

address: The address that you want to query balance.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep17balances",
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
                "assethash": "0x8d06bc235c2585c9d27ede8ed7085b3e13fc0c36",
                "amount": "9990000000000000",
                "lastupdatedblock": 17418
            },
            {
                "assethash": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "amount": "1002531616708175",
                "lastupdatedblock": 54499
            },
            {
                "assethash": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "amount": "9999785",
                "lastupdatedblock": 54496
            },
            {
                "assethash": "0x433f0891e80c107b9e63d5f5b7cddf1fc35eb0b9",
                "amount": "9999200000000000",
                "lastupdatedblock": 19810
            },
            {
                "assethash": "0x9c33bbf2f5afbbc8fe271dd37508acd93573cffc",
                "amount": "9995000000000000",
                "lastupdatedblock": 17145
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

