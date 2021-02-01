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
    "0x6ea186fe714b8168ede3b78461db8945c06d867da649852352dbe7cbf1ba3724"
  ]
}
```

Response body 1:

```json
{
  "jsonrpc": "2.0",
  "id": 1,
  "result": {
    "blockhash": "0x6ea186fe714b8168ede3b78461db8945c06d867da649852352dbe7cbf1ba3724",
    "executions": [
      {
        "trigger": "OnPersist",
        "vmstate": "HALT",
        "gasconsumed": "0.0203126",
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
                  "value": "CqOHtT6Wt5iaYxQxoFbdH0CgQvY="
                },
                {
                  "type": "Any"
                },
                {
                  "type": "Integer",
                  "value": "18083410"
                }
              ]
            }
          },
          {
            "contract": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
            "eventname": "Transfer",
            "state": {
              "type": "Array",
              "value": [
                {
                  "type": "Any"
                },
                {
                  "type": "ByteString",
                  "value": "z6LDQN4w1uEMToIZiPSxToNRPog="
                },
                {
                  "type": "Integer",
                  "value": "1252390"
                }
              ]
            }
          }
        ]
      },
      {
        "trigger": "PostPersist",
        "vmstate": "HALT",
        "gasconsumed": "0.0203126",
        "stack": [],
        "notifications": [
          {
            "contract": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
            "eventname": "Transfer",
            "state": {
              "type": "Array",
              "value": [
                {
                  "type": "Any"
                },
                {
                  "type": "ByteString",
                  "value": "z6LDQN4w1uEMToIZiPSxToNRPog="
                },
                {
                  "type": "Integer",
                  "value": "50000000"
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

Response description：

gasconsumed: The transaction fee, which means the GAS consumed in the transaction execution. 

