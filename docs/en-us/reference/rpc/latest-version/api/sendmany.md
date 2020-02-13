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
  {"asset": <asset>,"value": <value>,"address": <address>}
  ```

  * `asset`：Asset ID (asset identifier),  the NEP-5 contract scripthash
  
    e.g. NEO is 0x9bde8f209c88dd0e7ca3bf0af0f476cdd8207789
  
    Gas is 0x8c23f196d8a1bfd103a9dcb1f9ccf0c611377d3b
  
  * `value`：Transfer amount
  
  * `address`：destination address.

## Example

**Example 1 - transferring from a specified address**

Request body：

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

Response body:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x4703ce86388e5299ae70333ce799ad6d705b4dd046951d40745b10eb0871acf0",
        "size": 433,
        "version": 0,
        "nonce": 1247163501,
        "sender": "ARfyrX28D2H2wP6KR6xxaUbvqvkv5SbMNe",
        "sys_fee": "100000000",
        "net_fee": "1433240",
        "valid_until_block": 2403778,
        "attributes": [],
        "cosigners": [
            {
                "account": "0x861ef24e0b5390eeb2ae3cfe8dea9d9090f1936c",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "0400a3e11114a8722cd087f4cb812167b69320a069c9b65ac67c146c93f190909dea8dfe3caeb2ee90530b4ef21e8653c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f10400c2eb0b14a320932c66d707e03d7cba3a81a7a10e5de12f02146c93f190909dea8dfe3caeb2ee90530b4ef21e8653c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f10400e1f50514dc854f1958c1cd473887fdc52d0cbb3aa5ca5bac146c93f190909dea8dfe3caeb2ee90530b4ef21e8653c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1",
        "witnesses": [
            {
                "invocation": "402b28c4b9619255f6eb33f561d623b9d57f0a06efc0a3da5979e316574dfadfee0c8f8d174e7c3eee00e51e26a0b407d464308a385c1250a74b9aeb19b92394be",
                "verification": "21036e386a68bc20bb839a0495bffe84977ede8542dd35de91c487efe108b7bc767b68747476aa"
            }
        ]
    }
}
```

**Example 2 - transferring without specifying an address**

Request body：

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

Response body：

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

Response Description:

Returns the transaction details as above if the transaction was sent successfully; otherwise the transaction is failed.

If the JSON format is incorrect, a Parse error is returned. If the signature is incomplete, a pending transaction is returned. If the balance is insufficient, an error message is returned.
