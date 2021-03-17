# getapplicationlog method

Returns the contract event information based on the specified txid. The contract event information is stored under the ApplicationLogs directory.

> [!Note]
>
> You must install the plugins [ApplicationLogs](https://github.com/neo-project/neo-modules/releases) and [LevelDBStore](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- txid: Transaction ID

- trigger type:  Optional. It has the following options:

  - OnPersist
  - PostPersist
  - Application
  - Verification
  - System: OnPersist | PostPersist
  - All: OnPersist | PostPersist | Verification | Application

  It defaults to All. You can specify a trigger type.

## Example

Request body：

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "method": "getapplicationlog",
  "params": [
    "0x7da6ae7ff9d0b7af3d32f3a2feb2aa96c2a27ef8b651f9a132cfaad6ef20724c"
  ]
}
```

This transaction transfers 100 GAS from NgaiKFjurmNmiRzDRQGs44yzByXuSkdGPF to NikhQp1aAD1YFCiwknhM5LQQebj4464bCJ.

Response body 1:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0x7da6ae7ff9d0b7af3d32f3a2feb2aa96c2a27ef8b651f9a132cfaad6ef20724c",
        "executions": [
            {
                "trigger": "Application",
                "vmstate": "HALT",
                "exception": null,
                "gasconsumed": "9999540",
                "stack": [],
                "notifications": [
                    {
                        "contract": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                        "eventname": "Transfer",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteString",
                                    "value": "4rZTInKT6ZxPKQbVNVOrtKZy34Y="
                                },
                                {
                                    "type": "ByteString",
                                    "value": "+on7LBTfD1nd3wT25WUX8rNKrus="
                                },
                                {
                                    "type": "Integer",
                                    "value": "10000000000"
                                }
                            ]
                        }
                    }
                ]
            }
        ]
    }
}
```

Response description:

- txid: Transaction ID.

- trigger: Triggers.

- vmstate: VM execution state. HALT represents success, and FAULT represents failure.
- gasconsumed: The transaction fee, which means the GAS consumed in the transaction execution. 
- notifications: The notification sent by the smart contract.

- contract: The contract sending the notification. Here is GasToken.

- eventname: Event name of the notification.

- state: Notification content, where ByteString is Base64-encoded wallet address and can be converted at https://neo.org/converter/index.




