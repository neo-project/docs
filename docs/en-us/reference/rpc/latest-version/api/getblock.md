# getblock Method

Returns the corresponding block information according to the specified hash or index.

The usage of this method is as same as `getblockheader`. The only difference is that `getblockeader` gets the block header and `getblock` gets the complete block.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* hash | index: Block hash string or block index (i.e. block height = number of blocks - 1).

* verbose: Optional. The default value is false. 
  * When verbose is false, serialized information of the block is returned in a Base64-encoded string. If you need the detailed information, use SDK for deserialization. 
  * When verbose is true or 1, detailed information of the block is returned in Json format.

## Example

**Example 1 - Get serialized information of the block**

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [140],
  "id": 1
}
```

or

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getblock",
  "params": ["0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c"]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AAAAAFrf0tgylRv20FkZygEC2UDiMHJTukXJPQ/DFP5sezdzm3A7VffHxK0b4rwXh/xR/zV24Mj6+Vhq25qoN1WlxRIBIKp7dwEAAIwAAADitlMicpPpnE8pBtU1U6u0pnLfhgFCDEDGZIUihuWK6RLqloq6UiKxkoW0QFhqGhoQU3cK5IQRATFUY807W/hGmYqP80N8qjKQ/e4o8URTzgRUXJKXf1/sKxEMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4hELQRON768CAPKRpz5nJf56AIsJtw60lJgAAAAAAAjoIwAAAAAACxcAAAL6ifssFN8PWd3fBPblZRfys0qu6wDitlMicpPpnE8pBtU1U6u0pnLfhgEAXwsDAOQLVAIAAAAMFPqJ+ywU3w9Z3d8E9uVlF/KzSq7rDBTitlMicpPpnE8pBtU1U6u0pnLfhhTAHwwIdHJhbnNmZXIMFCizratyafnCGB2zy3Qev1UZMOJwQWJ9W1I5AkIMQLfVkTWSIgU9qfupqX+H0ViwPYtOTot/SbQptuHUYTFSpMB/J7sEOPITKV9HnT8BU1CSv6D6NdcwcZzEXgxRgFApDCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXhCDED8PagPv03pnEbsxUY7XgFk/qniHcha36hDCzZsmaJkpFg5vbgxk5+QE46K0GFsNpsqDJHNToGD9jeXsPzSvD5TKxEMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4hELQRON768="
}
```

**Example 2 - Get block information in Json**

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getblock",
  "params": [140, true],
  "id": 1
}
```

or

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getblock",
  "params": ["0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c", true]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c",
        "size": 608,
        "version": 0,
        "previousblockhash": "0x73377b6cfe14c30f3dc945ba537230e240d90201ca1959d0f61b9532d8d2df5a",
        "merkleroot": "0x12c5a55537a89adb6a58f9fac8e07635ff51fc8717bce21badc4c7f7553b709b",
        "time": 1612687482881,
        "index": 140,
        "nextconsensus": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        "witnesses": [
            {
                "invocation": "DEDGZIUihuWK6RLqloq6UiKxkoW0QFhqGhoQU3cK5IQRATFUY807W/hGmYqP80N8qjKQ/e4o8URTzgRUXJKXf1/s",
                "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
            }
        ],
        "consensusdata": {
            "primary": 0,
            "nonce": "7afe25673ea791f2"
        },
        "tx": [
            {
                "hash": "0x7da6ae7ff9d0b7af3d32f3a2feb2aa96c2a27ef8b651f9a132cfaad6ef20724c",
                "size": 386,
                "version": 0,
                "nonce": 246876555,
                "sender": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
                "sysfee": "0.0999954",
                "netfee": "0.0235316",
                "validuntilblock": 5899,
                "signers": [
                    {
                        "account": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa",
                        "scopes": "None"
                    },
                    {
                        "account": "0x86df72a6b4ab5335d506294f9ce993722253b6e2",
                        "scopes": "CalledByEntry"
                    }
                ],
                "attributes": [],
                "script": "CwMA5AtUAgAAAAwU+on7LBTfD1nd3wT25WUX8rNKrusMFOK2UyJyk+mcTykG1TVTq7Smct+GFMAfDAh0cmFuc2ZlcgwUKLOtq3Jp+cIYHbPLdB6/VRkw4nBBYn1bUjk=",
                "witnesses": [
                    {
                        "invocation": "DEC31ZE1kiIFPan7qal/h9FYsD2LTk6Lf0m0Kbbh1GExUqTAfye7BDjyEylfR50/AVNQkr+g+jXXMHGcxF4MUYBQ",
                        "verification": "DCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXg="
                    },
                    {
                        "invocation": "DED8PagPv03pnEbsxUY7XgFk/qniHcha36hDCzZsmaJkpFg5vbgxk5+QE46K0GFsNpsqDJHNToGD9jeXsPzSvD5T",
                        "verification": "EQwhAs7UMjl93ETtugMcC8O5M/KP3ZZ3eS17IObANt2qrPHiEQtBE43vrw=="
                    }
                ]
            }
        ],
        "confirmations": 34,
        "nextblockhash": "0xd087785fc3cf5b59c6a4631bdbdd63ed3e44947c22eb69ba866ea9291473b2b5"
    }
}
```

