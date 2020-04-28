# getbalance Method

Returns the balance of the corresponding asset in the wallet, based on the specified asset number. This method applies to the contract assets that conform to NEP-5 standards.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

## Parameter Description

Asset_id: Asset ID (asset identifier), which is the script hash of the contract for contract assets.

For example, NEO is 0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789

Gas is 0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b

You can query asset ID using the [CLI command](../../../../node/cli/cli.md) `list asset` or using the blockchain browser.

## Example

> [!Note]
>
> Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.

Example: querying the balance of NEP-5 assets.

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["0x8d06bc235c2585c9d27ede8ed7085b3e13fc0c36"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": "16000000000"
    }
}
```

Response Description:

balance: the balance of the asset in the wallet. Since the NEP-5 assets adopt the balance system rather than the UTXO system, there is no `confirmed` in the returned result and the balance is the actual available balance.

> [!Note]
>
> * Only when your client synchronizes to the block that the contract was deployed, execution of this API will return the correct value, otherwise execution of the API will result in an error.
> * When the input parameter is a script hash of a non-NEP-5 smart contract, execution of the API will result in an error.
