# sendtoaddress Method

Transfers to the specified address.

> [!Note]
>
> Before you can invoke this method you must:
>
> 1. Install the plugin [RpcServer](https://github.com/neo-project/neo-plugins/releases) 
> 2. Call the RPC method `openwallet` to open the wallet first.

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": [asset_id,address,value],
  "id": 1
}
```

## Parameter Description

* asset_id： Asset ID (asset identifier),  the script hash of NEP-17 contract

  e.g. NeoToken is 0xf61eebf573ea36593fd43aa150c055ad7906ab83

  GasToken is 0x70e2301955bf1e74cbb31d18c2f96972abadb328

* address: Payment address

* value: Amount transferred

## Example

Request body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "method": "sendtoaddress",
    "params": [
        "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
        "NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF",
        1
    ]
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x5c721fb081d70ff4d6af716793130d024702fa789800c35e0f6763244a7589df",
        "size": 246,
        "version": 0,
        "nonce": 376451427,
        "sender": "NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ",
        "sysfee": "9999540",
        "netfee": "1229550",
        "validuntilblock": 5786,
        "signers": [
            {
                "account": "0xebae4ab3f21765e5f604dfdd590fdf142cfb89fa",
                "scopes": "CalledByEntry"
            }
        ],
        "attributes": [],
        "script": "CxEMFOK2UyJyk+mcTykG1TVTq7Smct+GDBT6ifssFN8PWd3fBPblZRfys0qu6xTAHwwIdHJhbnNmZXIMFIOrBnmtVcBQoTrUP1k26nP16x72QWJ9W1I5",
        "witnesses": [
            {
                "invocation": "DEB9iM26NTkdhHkiIji4Cwk+5Ng9cfThzzPiOqz71ymvFWVKBx4/GMK4LQzaSO6PQwyGe8jrlieB2JEHWCf18mXX",
                "verification": "DCECztQyOX3cRO26AxwLw7kz8o/dlnd5LXsg5sA23aqs8eILQZVEDXg="
            }
        ]
    }
}
```

Response Description:

Returning of the transaction details above indicates that the transaction was sent successfully. If not, the transaction has failed to send.

If the signature is incomplete, it returns the transaction to be signed.

If the balance is insufficient, it returns an error message.
