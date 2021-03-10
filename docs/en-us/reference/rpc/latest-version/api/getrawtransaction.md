# getrawtransaction Method

Returns the corresponding transaction information based on the specified hash value.

> [!Note]
>
> You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* txid: Transaction ID

* verbose: Optional. The default value is false. 
  * When verbose is false, serialized information of the block is returned in a Base64-encoded string. If you need the detailed information, use the SDK for deserialization. 
  * When verbose is true or 1, detailed information of the block is returned in Json format string.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getrawtransaction",
  "params": ["0x7da6ae7ff9d0b7af3d32f3a2feb2aa96c2a27ef8b651f9a132cfaad6ef20724c"]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": "AIsJtw60lJgAAAAAAAjoIwAAAAAACxcAAAL6ifssFN8PWd3fBPblZRfys0qu6wDitlMicpPpnE8pBtU1U6u0pnLfhgEAXwsDAOQLVAIAAAAMFPqJ+ywU3w9Z3d8E9uVlF/KzSq7rDBTitlMicpPpnE8pBtU1U6u0pnLfhhTAHwwIdHJhbnNmZXIMFCizratyafnCGB2zy3Qev1UZMOJwQWJ9W1I5AkIMQLfVkTWSIgU9qfupqX+H0ViwPYtOTot/SbQptuHUYTFSpMB/J7sEOPITKV9HnT8BU1CSv6D6NdcwcZzEXgxRgFApDCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXhCDED8PagPv03pnEbsxUY7XgFk/qniHcha36hDCzZsmaJkpFg5vbgxk5+QE46K0GFsNpsqDJHNToGD9jeXsPzSvD5TKxEMIQLO1DI5fdxE7boDHAvDuTPyj92Wd3kteyDmwDbdqqzx4hELQRON768="
}
```

Request body:

When verbose = true, the result in Json format is returned:

```json
{
  "jsonrpc": "2.0",
  "method": "getrawtransaction",
  "params": ["0x7da6ae7ff9d0b7af3d32f3a2feb2aa96c2a27ef8b651f9a132cfaad6ef20724c", true],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
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
        ],
        "blockhash": "0x3d87f53c51c93fc08e5ccc09dbd9e21fcfad4dbea66af454bed334824a90262c",
        "confirmations": 26,
        "blocktime": 1612687482881
    }
}
```
