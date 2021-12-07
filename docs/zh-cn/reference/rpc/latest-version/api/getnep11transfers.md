# getnep11transfers 方法

返回指定地址内的所有 NEP-11 交易记录。

> [!Note]
>
> 此方法由插件提供，需要安装 [TokensTracker](https://github.com/neo-project/neo-modules/releases) 、[LevelDBStore](https://github.com/neo-project/neo-modules/releases) 和 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

- address：要查看交易记录的地址。

- startTime | endTime：可选参数，UTC 时间戳，统计资产开始或截止时间（含）。

  - 如果设置起始和结束时间戳，则返回时间戳范围内的交易信息。
  - 如果仅设置一个时间戳，则返回自该时间戳以后发生的交易信息。
  - 如果不设置此参数，则返回近七天内的交易信息。

## 调用示例

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "getnep11transfers",
  "params": ["NdUL5oDPD159KeFpD5A9zw5xNF1xLX6nLT",1635146038919],
  "id": 1
}
```

响应正文：

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

