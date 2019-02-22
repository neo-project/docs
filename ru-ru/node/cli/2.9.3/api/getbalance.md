# getbalance Method

Returns the balance of the corresponding asset in the wallet, based on the specified asset number. This method applies to global assets and the contract assets that conform to NEP-5 standards. 

> [!Note]
> You need to open the wallet in the NEO-CLI node before you execute this command.

## Parameter Description

Asset_id: Asset ID (asset identifier), which is the transaction ID of Register Transaction or  Publish Transaction for global assets, or the script hash of the contract for contract assets.

For NEO: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

For GAS: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

For RPX Sale: ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9

The remaining asset IDs can be queried through the `list asset` command in [CLI Command](../../cli.md) or in the Block Chain Browser.

## Examples 

##### Example 1: Inquiring the balance of global assets

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "id": 1
}
```

Response body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
  "balance": "1.01",
  "confirmed": "1.01"
  }
}
```

Response Description:

- balance: The actual balance of the asset in the wallet.

- confirmed: The exact amount of the asset in the wallet, where only confirmed amounts can be used for transfer.

`balance` and `confirmed` values may not be equal. This happens when there is an output transaction from the wallet, and the change has not been confirmed yet, so the confirmed value will be less than the balance. Once the deal is confirmed, the two will become equal.

> [!Note] 
>
> Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.

##### Example 2：Inquiring the balance of NEP-5 assets

 Request body： 

```json
{
  "jsonrpc": "2.0",
  "method": "getbalance",
  "params": ["ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9"],
  "id": 1
}
```

 Response body： 

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": "10"
    }
}
```

Response Description:

balance: the balance of the asset in the wallet. Since the NEP-5 assets adopt the balance system rather than the UTXO system, there is no `confirmed`  in the returned result and the balance is the actual available balance.  

> [!Note]
>
> - Only when your client synchronizes to the block that the contract was deployed, execution of this API will return the correct value, otherwise execution of the API will result in an error. 
> - When the input parameter is a script hash of a non-NEP-5 smart contract, execution of the API will result in an error. 
> - Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.
