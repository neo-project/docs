# Getbalance method

Returns the balance of the corresponding asset in the wallet based on the specified asset number.

> [!Note]
> You need to open the wallet in the AntSharesCore-CLI node before executing this command.

## Parameter Description

Asset_id: Asset ID (asset identifier), which is the transaction ID of the RegistTransaction when the asset is registered.

For AntShares this is: c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

For AntCoins this is: 602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

The remaining asset IDs can be queried through the `list asset` command in [CLI Command](../cli.md) or in the Block Chain Browser.

## Call the example

Request text:

```json
{
  "Jsonrpc": "2.0",
  "Method": "getbalance",
  "Params": ["025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4"],
  "Id": 1
}
```

Response text:

```json
{
  "Jsonrpc": "2.0",
  "Id": 1,
  "Result": {
    "Balance": "1.01",
    "Confirmed": "1.01"
  }
}
```

Response Description:

Balance: The true balance of the asset in the wallet.

The exact amount of the asset in the purse, only the amount that has been confirmed, can be used for transfer.

Balance and definite may not be equal, only in the wallet out of a sum of money, and there is no time to change the confirmation, the value will be less than balance. When the deal is determined, the two will become equal.
