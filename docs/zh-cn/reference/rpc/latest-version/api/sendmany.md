# sendmany 方法

批量转账命令。

> [!Note]
>
> - 执行此命令前需要在 Neo-CLI 节点中打开钱包。
> - 此方法由插件提供，需要安装 [RpcWallet](https://github.com/neo-project/neo-plugins/releases) 插件才可以调用。

## 参数说明

`[from]<outputs_array>`

- from：可选参数，指定转出地址

- outputs_array：数组，数组中的每个元素的数据结构如下：

  `{"asset": <asset>,"value": <value>,"address": <address>}`

  - asset：资产 ID（资产标识符），即该资产在注册时的 RegistTransaction 的交易 ID。

    如 NEO 为：c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b

    NeoGas 为：602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

    其余资产 ID 可以通过 [CLI 命令](../../../../node/cli/cli.md) 中的 `list asset` 命令查询，也可以在区块链浏览器中查询。

  - value：转账金额。

  - address：收款地址。

## 调用示例

**示例 1 - 指定转出地址**

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
    "ARfyrX28D2H2wP6KR6xxaUbvqvkv5SbMNe",
        [
            {
                "asset": "0xa1760976db5fcdfab2a9930e8f6ce875b2d18225",
                "value": 3,
                "address": "AX8XwkL5qfpSNEFp7uprgs4yBWqE1pJh4z"
            },
            {
                "asset": "0xa1760976db5fcdfab2a9930e8f6ce875b2d18225",
                "value": 2,
                "address": "AWeQp7LpihMuAmBS1hv5rqXSGKBFct1gfh"
            },
            {
                "asset": "0xa1760976db5fcdfab2a9930e8f6ce875b2d18225",
                "value": 1,
                "address": "Abst1AtjYZWbRKPPeUWzt7PHRziLsxK7Nr"
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

**示例 2 - 不指定转出地址**

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
        [
            {
                "asset": "0xa1760976db5fcdfab2a9930e8f6ce875b2d18225",
                "value": 0.3,
                "address": "AX8XwkL5qfpSNEFp7uprgs4yBWqE1pJh4z"
            },
            {
                "asset": "0xa1760976db5fcdfab2a9930e8f6ce875b2d18225",
                "value": 0.2,
                "address": "AWeQp7LpihMuAmBS1hv5rqXSGKBFct1gfh"
            },
            {
                "asset": "0xa1760976db5fcdfab2a9930e8f6ce875b2d18225",
                "value": 0.1,
                "address": "Abst1AtjYZWbRKPPeUWzt7PHRziLsxK7Nr"
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
        "hash": "0x2f0b45bbbff0b9b5a1531d638152c1a3730feb8eb6b8a14e13730f5238a18fd0",
        "size": 539,
        "version": 0,
        "nonce": 2014194553,
        "sender": "AWeQp7LpihMuAmBS1hv5rqXSGKBFct1gfh",
        "sys_fee": "100000000",
        "net_fee": "2539480",
        "valid_until_block": 2452914,
        "attributes": [],
        "cosigners": [
            {
                "account": "0xac5bcaa53abb0c2dc5fd873847cdc158194f85dc",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "0480c3c90114a8722cd087f4cb812167b69320a069c9b65ac67c14dc854f1958c1cd473887fdc52d0cbb3aa5ca5bac53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f104002d310114a320932c66d707e03d7cba3a81a7a10e5de12f0214dc854f1958c1cd473887fdc52d0cbb3aa5ca5bac53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1048096980014dc854f1958c1cd473887fdc52d0cbb3aa5ca5bac14dc854f1958c1cd473887fdc52d0cbb3aa5ca5bac53c1087472616e73666572142582d1b275e86c8f0e93a9b2facd5fdb760976a168627d5b52f1",
        "witnesses": [
            {
                "invocation": "402ab49689a795e66ad1da5479d104f3221866cde74c1b769b14063b9ea4e67d6e900a063fd6b1be062137dc238c74e64b1576c88bbff056f2889c9c621ab32227",
                "verification": "210288a99d33b6f7f1b19d3be7a7935d2c076fec52d9591336af03e43eec8ca1b16b68747476aa"
            },
            {
                "invocation": "407dda872506e59efb1bbfb612942132a988bbc3291b7fedc9e9b45564ad2c588432f17b73d13a13948652133ce4d14c453f013d33c9e71b0f147c6b11793b8f1e",
                "verification": "2102536268a690cf09a959d2a3ec062bf52e8d17f1cca52db3aa6f497b05d7c1be4968747476aa"
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
