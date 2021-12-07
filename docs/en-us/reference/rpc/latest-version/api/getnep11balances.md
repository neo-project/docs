# getnep11balances Method

Returns the balance of all NEP11 assets in the specified address.

> [!Note]
>
You must install the plugin [TokensTracker](https://github.com/neo-project/neo-modules/releases), [LevelDBStore](https://github.com/neo-project/neo-modules/releases), and [RpcSever](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

address: The address that you want to query balance.

## Configuration

Before invoking the method, you need to modify the following fields in the TokensTracker config.json file:

- MaxResults: The maximum number of records. The exceeding portion will not be stored.
- Network: Set it to the same value as Network in Neo-CLI config.json.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getnep11balances",
  "params": ["NdUL5oDPD159KeFpD5A9zw5xNF1xLX6nLT"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "NdUL5oDPD159KeFpD5A9zw5xNF1xLX6nLT",
        "balance": [
            {
                "assethash": "0xb3b65e5c0d2af3f98cac6e80083f6c2b90476f40",
                "tokens": [
                    {
                        "tokenid": "426c696e6420426f782032",
                        "amount": "1",
                        "lastupdatedblock": 36653
                    },
                    {
                        "tokenid": "426c696e6420426f782033",
                        "amount": "1",
                        "lastupdatedblock": 37100
                    },
                    {
                        "tokenid": "426c696e6420426f782031323635",
                        "amount": "1",
                        "lastupdatedblock": 501483
                    }
                ]
            }
        ]
    }
}
```

> [!Note]
>
> - Only when your client synchronizes to the block that the contract was deployed, execution of this API will return the correct value, otherwise execution of the API will result in an error. 
> - When the input parameter is a script hash of a non-NEP11 smart contract, execution of the API will result in an error. 
> - Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.

