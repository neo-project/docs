# getnep11transfers Method

Returns all the NEP11 transaction information occurred in the specified address.

> [!Note]
>
> You must install the plugin [TokensTracker](https://github.com/neo-project/neo-modules/releases), [LevelDBStore](https://github.com/neo-project/neo-modules/releases), and [RpcSever](https://github.com/neo-project/neo-modules/releases) before you can invoke the method.

## Parameter Description

- address: The address to query the transaction information.

- startTime | endTime: Optional. The UTC timestamp which records the asset start or end  time (included).
  - If start and end timestamps are specified, transactions occurred in the time range are returned.
  - If only one timestamp is specified, transactions occurred since that time are returned.
  - If not specified, transactions in recent seven days are returned.

## Configuration

Before invoking the method, you need to modify the following fields in the TokensTracker config.json file:

- MaxResults: The maximum number of records. The exceeding portion will not be stored.
- Network: Set it to the same value as Network in Neo-CLI config.json.

## Example

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "getnep11transfers",
  "params": ["NdUL5oDPD159KeFpD5A9zw5xNF1xLX6nLT",1635146038919],
  "id": 1
}
```

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "address": "NdUL5oDPD159KeFpD5A9zw5xNF1xLX6nLT",
        "sent": [
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": null,
                "amount": "1",
                "blockindex": 540423,
                "transfernotifyindex": 0,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e7420412023343838"
            },
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": "NNNPy5qxVD9yW2BavkwLdDybbR88NdvaGi",
                "amount": "1000",
                "blockindex": 540423,
                "transfernotifyindex": 1,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e7420422023313734"
            },
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": "NNNPy5qxVD9yW2BavkwLdDybbR88NdvaGi",
                "amount": "10000",
                "blockindex": 540423,
                "transfernotifyindex": 2,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e7420432023313238"
            },
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": null,
                "amount": "1",
                "blockindex": 540423,
                "transfernotifyindex": 3,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e7420442023363731"
            },
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": null,
                "amount": "1",
                "blockindex": 540423,
                "transfernotifyindex": 4,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e7420452023353832"
            },
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": null,
                "amount": "1",
                "blockindex": 540423,
                "transfernotifyindex": 5,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e74204620233736"
            },
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": null,
                "amount": "1",
                "blockindex": 540423,
                "transfernotifyindex": 6,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e7420472023333534"
            },
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": null,
                "amount": "1",
                "blockindex": 540423,
                "transfernotifyindex": 7,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e7420482023363432"
            },
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": null,
                "amount": "1",
                "blockindex": 540423,
                "transfernotifyindex": 8,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "467261676d656e742049202331323539"
            }
        ],
        "received": [
            {
                "timestamp": 1635146038919,
                "assethash": "0xd9e2093de3dc2ef7cf5704ceec46ab7fadd48e7f",
                "transferaddress": null,
                "amount": "1",
                "blockindex": 540423,
                "transfernotifyindex": 9,
                "txhash": "0x683998f3a06b44be7b80be517bffda130de1fe75feae7b6e58d8372266fd87f6",
                "tokenid": "4e20233134204e65726f"
            }
        ]
    }
}
```

