# sendmany Method

Bulk transfer order, and you can specify a change address.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [from, outputs_array],
  "id": 1
}
```

### Parameter Description

* `from`: Optional. The address from which you transfer the asset.

* `outputs_array`：Array, the data structure of each element in the array is as follows:

  ```json
  {"asset": <asset>,"value": <value>,"address": <address>, "signers": <signers>}
  ```

  * `asset`: Asset ID (asset identifier),  the NEP-17 contract scripthash
  
    e.g. NeoToken is: 0xf61eebf573ea36593fd43aa150c055ad7906ab83
  
    GasToken is: 0x70e2301955bf1e74cbb31d18c2f96972abadb328
  
  * `value`: Transfer amount
  
  * `address`: Destination address
  
  * `signers`: The signature account of transaction

## Example

Request text:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "sendmany",
    "params": [
        "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        [
            {
                "asset": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "value": 10,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            },
            {
                "asset": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "value": 50000000,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            }
        ]
    ]
}
```

Request text (without fromAddress):

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "value": 10,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            },
            {
                "asset": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "value": 50000000,
                "address": "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF"
            }
        ]
    ]
}
```

Response text:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x0f8232a7395661d3501ba600f9bf45a261d4b8c5400696be771562b223d35358",
        "size": 337,
        "version": 0,
        "nonce": 1372416014,
        "sender": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        "sysfee": "19999080",
        "netfee": "1320550",
        "validuntilblock": 5819,
        "signers": [
            {
                "account": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CxoMFOK2UyJyk+mcTykG1TVTq7Smct+GDBT6ifssFN8PWd3fBPblZRfys0qu6xTAHwwIdHJhbnNmZXIMFIOrBnmtVcBQoTrUP1k26nP16x72QWJ9W1I5CwKA8PoCDBTitlMicpPpnE8pBtU1U6u0pnLfhgwU+on7LBTfD1nd3wT25WUX8rNKrusUwB8MCHRyYW5zZmVyDBQos62rcmn5whgds8t0Hr9VGTDicEFifVtSOQ==",
        "witnesses": [
            {
                "invocation": "DECejDPVz78go5cSN1B5gwnkmMxCsbjst2oqZFNmzFR75xjfVnYqpnwfzROAImrmC40MN6fis9MqMD/zEHcf71cu",
                "verification": "DCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXg="
            }
        ]
    }
}
```

Response Description:

Returns the transaction details as above if the transaction was sent successfully; otherwise the transaction is failed.

If the JSON format is incorrect, a Parse error is returned. If the signature is incomplete, a pending transaction is returned. If the balance is insufficient, an error message is returned.
