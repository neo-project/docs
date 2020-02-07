# invokefunction Method

Invokes a smart contract with its scripthash based on the specified operation and parameters and returns the result.

> [!Note]
>
> - This method is used to test your VM script as if they ran on the blockchain at that point in time. This RPC call does not affect the blockchain in any way.
> - You must install the plugin [RpcServer](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

* scripthash: Smart contract scripthash. You need to use the proper byte order of the address passed according to its data type. If the data type is Hash160, use the big endian scripthash; if the data type is ByteArray, use the little endian scripthash.
* operation: The operation name (string)
* params: The parameters to be passed into the smart contract operation

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "39e7394d6231aa09c097d02391d5d149f873f12b"
      }
    ]
  ],
  "id": 3
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b52",
        "state": "HALT",
        "gas_consumed": "2007570",
        "stack": [
            {
                "type": "Integer",
                "value": "9999885"
            }
        ],
        "tx": "0075fa234c2bf173f849d1d59123d097c009aa31624d39e73900e1f50500000000269f120000000000dbe1200000003e0c142bf173f849d1d59123d097c009aa31624d39e73911c00c0962616c616e63654f660c14897720d8cd76f4f00abfa37c0edd889c208fde9b41627d5b5201420c40b9539b4affc196cc2dccf49df0d8ba962ed7cca1f2c5a708a5da4405a79263694464a9140d686445b5d3857abdd1322b3aeed6486490ef4c8b298460138de237290c2103b9c46c6d5c671ef5c21bc7aa7c30468aeb081a2e3895269adf947718d650ce1e0b410a906ad4"
    }
}
```

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0x9c33bbf2f5afbbc8fe271dd37508acd93573cffc",
    "symbol",
    [ ]
  ],
  "id": 3
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "10c00c0673796d626f6c0c14fccf7335d9ac0875d31d27fec8bbaff5f2bb339c41627d5b52",
        "state": "HALT",
        "gas_consumed": "1036870",
        "stack": [
            {
                "type": "ByteArray",
                "value": "RERB"
            }
        ],
        "tx": "00e7fc08682bf173f849d1d59123d097c009aa31624d39e73900e1f505000000007e3d120000000000c1e1200000002510c00c0673796d626f6c0c14fccf7335d9ac0875d31d27fec8bbaff5f2bb339c41627d5b5201420c4099b21d5356e17dcca7eea7940815f528c1bf9e5faddb5717a57b050e4afb71a82db068bd087888b780eebfcb8d8bca359d8f360d5a0876a8548afb36150f50cb290c2103b9c46c6d5c671ef5c21bc7aa7c30468aeb081a2e3895269adf947718d650ce1e0b410a906ad4"
    }
}
```