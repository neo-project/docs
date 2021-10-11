# getwalletbalance Method

Returns the balance of the corresponding asset in the wallet, based on the specified asset number. This method applies to the contract assets that conform to [NEP-17](https://github.com/neo-project/proposals/blob/1937ff56a09ac7e8380637e61129e9359e01a1b6/nep-17.mediawiki) standards.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

## Parameter Description

Asset_id: Asset ID (asset identifier), which is the script hash of the contract for contract assets.

For example, NEO is 0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5

Gas is 0xd2a4cff31913016155e38e474a2c06d08be276cf

You can query asset ID using the [CLI command](../../../../node/cli/cli.md) `list asset` or using the blockchain browser.

## Example

> [!Note]
>
> Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.

Example: querying the balance of NEP-17 assets.

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getwalletbalance",
  "params": ["0xd2a4cff31913016155e38e474a2c06d08be276cf"],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": "3000014661474560"
    }
}
```

Response Description:

balance: the balance of the asset in the wallet. Since the NEP-17 assets adopt the balance system rather than the UTXO system, there is no `confirmed` in the returned result and the balance is the actual available balance.

> [!Note]
>
> * Only when your client synchronizes to the block that the contract was deployed, execution of this API will return the correct value, otherwise execution of the API will result in an error.
> * When the input parameter is a script hash of a non-NEP-17 smart contract, execution of the API will result in an error.
