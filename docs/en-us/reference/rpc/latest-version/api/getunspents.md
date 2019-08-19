# getunspents Method

Returns information of the unspent UTXO assets (e.g. NEO, GAS) at the specified address.

> [!Note]
>
> This method is provided by the plugin [RpcSystemAssetTracker](https://github.com/neo-project/neo-plugins/releases). You need to install the plugin before you can invoke the method.

## Parameter Description

`address`：Set the standard address you want to query.

## Example

Request body：

```json
{
    "jsonrpc": "2.0",
    "method": "getunspents",
    "params": [
        "AGofsxAUDwt52KjaB664GYsqVAkULYvKNt"
    ],
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
                "unspent": [
                    {
                        "txid": "4ee4af75d5aa60598fbae40ce86fb9a23ffec5a75dfa8b59d259d15f9e304319",
                        "n": 0,
                        "value": 27844.821
                    },
                    {
                        "txid": "9906bf2a9f531ac523aad5e9507bd6540acc1c65ae9144918ccc891188578253",
                        "n": 0,
                        "value": 0.987
                    },
                    {
                        "txid": "184e34eb3f9550d07d03563391d73eb6c438130c7fdca37f0700d5d52ad7deb1",
                        "n": 0,
                        "value": 243.95598
                    },
                    {
                        "txid": "448abc64412284fb21c9625ac9edd2100090367a551c18ce546c1eded61e77c3",
                        "n": 0,
                        "value": 369.84904
                    },
                    {
                        "txid": "bd454059e58da4221aaf4effa3278660b231e9af7cea97912f4ac5c4995bb7e4",
                        "n": 0,
                        "value": 600.41014479
                    }
                ],
                "asset_hash": "602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "asset": "GAS",
                "asset_symbol": "GAS",
                "amount": 29060.02316479
            },
            {
                "unspent": [
                    {
                        "txid": "c3182952855314b3f4b1ecf01a03b891d4627d19426ce841275f6d4c186e729a",
                        "n": 0,
                        "value": 800000
                    }
                ],
                "asset_hash": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "asset": "NEO",
                "asset_symbol": "NEO",
                "amount": 800000
            }
        ],
        "address": "AGofsxAUDwt52KjaB664GYsqVAkULYvKNt"
    }
}
```


