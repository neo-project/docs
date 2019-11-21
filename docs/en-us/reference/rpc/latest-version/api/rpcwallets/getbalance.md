# getbalance Method

Returns the balance of the corresponding asset in the wallet, based on the specified asset number. This method applies to the contract assets that conform to NEP-5 standards.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Open the wallet in NEO-CLI
> 2. Install the plugin [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": [asset_id],
  "id": 1
}
```

### Parameter Description

* Asset_id: Asset ID (asset identifier), which is the script hash of the contract for contract assets.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": "1000000000"
    }
}
```

Response Description:

balance: the balance of the asset in the wallet. Since the NEP-5 assets adopt the balance system rather than the UTXO system, there is no `confirmed` in the returned result and the balance is the actual available balance.

> [!Note]
>
> * Only when your client synchronizes to the block that the contract was deployed, execution of this API will return the correct value, otherwise execution of the API will result in an error.
> * When the input parameter is a script hash of a non-NEP-5 smart contract, execution of the API will result in an error.
> * Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.
