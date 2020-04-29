# sendmany 方法

批量转账命令，并且可以指定找零地址。

> [!Note]
>
> - 执行此命令前需要 RPC 调用 openwallet 方法来打开钱包。
> - 此方法由插件提供，需要安装 [RpcServer](https://github.com/neo-project/neo-modules/releases) 插件才可以调用。

## 参数说明

`[fromAddress]<outputs_array>`

- fromAddress： 资产出金的地址（可选）

- outputs_array：数组，数组中的每个元素的数据结构如下：

  `{"asset": <asset>,"value": <value>,"address": <address>}`

  - asset_id：资产 ID，即 NEP-5 合约的脚本哈希

	  如 NEO 为：0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789

	  Gas 为：0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b

	- value：转账金额。

  - address：收款地址。


## 调用示例

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
    "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
        [
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 1,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            },
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 2,
                "address": "NVfJmhP28Q9qva9Tdtpt3af4H1a3cp7Lih"
            },
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 3,
                "address": "NVQ3AGXWu84Vak9kYThsmunqQ8KnQVQwYJ"
            },
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 4,
                "address": "NSyCA1Yfr1VhaTZouj89NG1GbY1LnRtTzq"
            },
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 5,
                "address": "NUNbZcfzNK1ySGbQSWnGjL975DsLNRFFaz"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 6,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 7,
                "address": "NVfJmhP28Q9qva9Tdtpt3af4H1a3cp7Lih"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 8,
                "address": "NVQ3AGXWu84Vak9kYThsmunqQ8KnQVQwYJ"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 9,
                "address": "NSyCA1Yfr1VhaTZouj89NG1GbY1LnRtTzq"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 10,
                "address": "NUNbZcfzNK1ySGbQSWnGjL975DsLNRFFaz"
            }
        ]
    ],
    "id": 1
}
```

请求正文（不包含 fromAddress）：

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 1,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            },
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 2,
                "address": "NVfJmhP28Q9qva9Tdtpt3af4H1a3cp7Lih"
            },
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 3,
                "address": "NVQ3AGXWu84Vak9kYThsmunqQ8KnQVQwYJ"
            },
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 4,
                "address": "NSyCA1Yfr1VhaTZouj89NG1GbY1LnRtTzq"
            },
            {
                "asset": "0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789",
                "value": 5,
                "address": "NUNbZcfzNK1ySGbQSWnGjL975DsLNRFFaz"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 6,
                "address": "Nc2TgT3BTnDZGh21uU14Fudaq9C8GqUKJA"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 7,
                "address": "NVfJmhP28Q9qva9Tdtpt3af4H1a3cp7Lih"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 8,
                "address": "NVQ3AGXWu84Vak9kYThsmunqQ8KnQVQwYJ"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 9,
                "address": "NSyCA1Yfr1VhaTZouj89NG1GbY1LnRtTzq"
            },
            {
                "asset": "0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b",
                "value": 10,
                "address": "NUNbZcfzNK1ySGbQSWnGjL975DsLNRFFaz"
            }
        ]
    ],
    "id": 1
}
```

响应正文：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x69865f728e01fdf4edf7ffc6eb0e941d8b37386b14d67090265481d8f5724939",
        "size": 1051,
        "version": 0,
        "nonce": 714785378,
        "sender": "NPvKVTGZapmFWABLsyvfreuqn73jCjJtN1",
        "sys_fee": "100000000",
        "net_fee": "2051390",
        "valid_until_block": 2139412,
        "attributes": [],
        "cosigners": [
            {
                "account": "0x39e7394d6231aa09c097d02391d5d149f873f12b",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "EQwUsLxLZL7i4j09Mt4CyqwYU/q7tAMMFCvxc/hJ0dWRI9CXwAmqMWJNOec5E8AMCHRyYW5zZmVyDBSJdyDYzXb08Aq/o3wO3YicII/em0FifVtSORIMFGrrXgextECiwxdOgQ0Zve+cztI4DBQr8XP4SdHVkSPQl8AJqjFiTTnnORPADAh0cmFuc2ZlcgwUiXcg2M129PAKv6N8Dt2InCCP3ptBYn1bUjkTDBRoCBi7T1Agq1vEIqg53FXHfKCH0gwUK/Fz+EnR1ZEj0JfACaoxYk055zkTwAwIdHJhbnNmZXIMFIl3INjNdvTwCr+jfA7diJwgj96bQWJ9W1I5FAwUTWT0gXNnLSRI/x1soZpHDS/ZPfYMFCvxc/hJ0dWRI9CXwAmqMWJNOec5E8AMCHRyYW5zZmVyDBSJdyDYzXb08Aq/o3wO3YicII/em0FifVtSORUMFFzKL+r9KeMwRX8nlSHSarTn6UreDBQr8XP4SdHVkSPQl8AJqjFiTTnnORPADAh0cmFuc2ZlcgwUiXcg2M129PAKv6N8Dt2InCCP3ptBYn1bUjkCAEbDIwwUsLxLZL7i4j09Mt4CyqwYU/q7tAMMFCvxc/hJ0dWRI9CXwAmqMWJNOec5E8AMCHRyYW5zZmVyDBQ7fTcRxvDM+bHcqQPRv6HYlvEjjEFifVtSOQIAJ7kpDBRq614HsbRAosMXToENGb3vnM7SOAwUK/Fz+EnR1ZEj0JfACaoxYk055zkTwAwIdHJhbnNmZXIMFDt9NxHG8Mz5sdypA9G/odiW8SOMQWJ9W1I5AgAIry8MFGgIGLtPUCCrW8QiqDncVcd8oIfSDBQr8XP4SdHVkSPQl8AJqjFiTTnnORPADAh0cmFuc2ZlcgwUO303EcbwzPmx3KkD0b+h2JbxI4xBYn1bUjkCAOmkNQwUTWT0gXNnLSRI/x1soZpHDS/ZPfYMFCvxc/hJ0dWRI9CXwAmqMWJNOec5E8AMCHRyYW5zZmVyDBQ7fTcRxvDM+bHcqQPRv6HYlvEjjEFifVtSOQIAypo7DBRcyi/q/SnjMEV/J5Uh0mq05+lK3gwUK/Fz+EnR1ZEj0JfACaoxYk055zkTwAwIdHJhbnNmZXIMFDt9NxHG8Mz5sdypA9G/odiW8SOMQWJ9W1I5",
        "witnesses": [
            {
                "invocation": "DED2sAXuluMra/+ml/nsebVdjQFyRdJJxZUnXJve6hWoFs/HSjgFYqnZzQkNrJhVgJ9cjHqMX3qkd6A7xGyXpWql",
                "verification": "DCEDucRsbVxnHvXCG8eqfDBGiusIGi44lSaa35R3GNZQzh4LQQqQatQ="
            }
        ]
    }
}
```

响应说明：

返回如上的交易详情说明交易发送成功，否则交易发送失败。

JSON 格式不正确，会返回 Parse error。                                                                                                                                         

如果签名不完整会返回待签名的交易。

如果余额不足会返回错误信息。
