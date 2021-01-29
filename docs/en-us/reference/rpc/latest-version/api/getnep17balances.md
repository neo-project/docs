# getnep17balances Method

Returns the balance of all NEP17 assets in the specified address.

> [!Note]
>
> You must install the plugin [RpcNep17Tracker](https://github.com/neo-project/neo-plugins/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- address: The address that you want to query balance.
- startTime | endTime: Optional. The UTC timestamp which records the asset start or end  time (included).

  - If start and end timestamps are specified, asset balance occurred in the time range are returned.
  - If only one timestamp is specified, asset balance occurred since that time are returned.
  - If not specified, asset balance in recent seven days are returned.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep17balances",
  "params": ["NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF", 0],
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
                "assethash": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "amount": "30000046.99999955",
                "lastupdatedblock": 94
            },
            {
                "assethash": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "amount": "99999999",
                "lastupdatedblock": 94
            }
        ],
        "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
    }
}
```



> [!Note]
> 
>- Only when your client synchronizes to the block that the contract was deployed, execution of this API will return the correct value, otherwise execution of the API will result in an error. 
> - When the input parameter is a script hash of a non-NEP17 smart contract, execution of the API will result in an error. 
>- Make sure your client has been fully synchronized to the latest block height before using this API, otherwise the balance returned may not be up-to-date.

