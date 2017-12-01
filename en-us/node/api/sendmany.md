# sendmany Method

Bulk transfer order, and you can specify a change address.

> [!Note]
> You need to open the wallet in the NEO-CLI node before executing this command.

## Parameter Description

\<outputs_array> \[fee=0] \[change_address]

Outputs_array: Array, the data structure of each element in the array is as follows:

​	{"asset": \<asset>,"value": \<value>,"address": \<address>}

​	asset：Asset ID（asset identifier），The `RegistTransaction` ID of the asset at the time of registration.

​	For NEO：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

​	For NeoGas：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

   The remaining asset IDs can be passed through the [CLI commandline](../cli.MD), the `list Asset` command query can also be queried in the block chain browser.


​	value：Transfer amount

​	address：destination address.

Fee: Handling fee, optional parameter, default is 0.

Change_address: Change address, optional parameter, default is the first standard address in the wallet.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "sendmany",
  "params": [[{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"},{"asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4","value": 1,"address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"}]],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "27b9a82ed519eec17c5520927b3f472e4df28b835c24dba25645e1650ed8d2ac",
        "size": 322,
        "type": "ContractTransaction",
        "version": 0,
        "attributes": [],
        "vin": [
            {
                "txid": "8674c38082e59455cf35cee94a5a1f39f73b617b3093859aa199c756f7900f1f",
                "vout": 0
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 1,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "1",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            },
            {
                "n": 2,
                "asset": "025d82f7b00a9ff1cfe709abe3c4741a105d067178e645bc3ebad9bc79af47d4",
                "value": "999998",
                "address": "AbRTHXb9zqdqn5sVh4EYpQHGZ536FgwCx2"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "40844144eb6819cb094afee2db5e5da078cfc7bbe29dbc60e47b4c3b4bdf77a5fd97865ae9b5a8d8bb3fa20f1441a58a05f848b2ea49c6c0dbbfc5ed241b226665",
                "verification": "210208c5203d32f960c54c225f140c1020408b114c15d29082fc959dac6874828fccac"
            }
        ]
    }
}
```

Response Description:

Returns the transaction details as above to indicate that the transaction was sent successfully or the transaction failed.

If the JSON format is incorrect, a Parse error is returned.
If the signature is incomplete, a pending transaction is returned.
If the balance is insufficient, an error message is returned.