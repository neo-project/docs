# 处理资产交易

## 简介

Neo N3 中只有一种资产，即 NEP-17 类型的资产，使用 BALANCE 模型来管理资产。交易所对接时，主要处理这类资产的查询、充值、提现等操作。这三种操作的流程分别如下图所示：

   ![query.png](assets/query.png)

   ![deposit.png](assets/deposit.png)

   ![withdraw.png](assets/withdraw.png)

## 网络费

网络费是用户向 Neo 网络提交交易时支付的费用，作为共识节点的出块奖励。每笔交易的网络费存在一个基础值，计算公式如下所示。只有当用户支付的网络费大于或等于此基础费用时，才会执行交易。否则将被认为无效交易。   

```
NetworkFee = VerificationCost + tx.size * FeePerByte
```

- VerficationCost：NeoVM 验证交易签名执行的指令相对应的费用
- tx.size：交易数据的字节长度
- FeePerByte：交易每字节的费用，目前在 PolicyContract 定义为 0.00001 GAS。

## 系统费

系统费是根据 NeoVM 要执行的指令计算得出的费用，有关每个操作指令的费用，请参考[系统费用](../reference/fees.md)。Neo N3 中取消了每笔交易 10 GAS 的免费额度，系统费用总额受合约脚本的指令数量和指令类型影响，计算公式如下：

```
SystemFee = InvocationCost = The sum of all executed opcode fee   
```

### 操作码费用

NeoVM 操作码费用降低为原来的 1/1000 左右，可以显著降低智能合约开发成本。

与 Neo Legacy 的比较：

![feecomparewith2x](assets/feecomparewith2x.png)

## 处理查询交易

交易所由于自身管理钱包产生的查询地址余额需求和用户的查询账户余额请求是不同的。

### 交易所查询用户地址余额

交易所查询用户地址余额的操作如下：

1. 编写 JSON 文件，调用以下任意一个 RPC 方法：
   - getnep17balances（需安装 [TokensTracker](https://github.com/neo-project/neo-modules/releases/) 插件）
   - invokefunction（需安装 [RpcServer](https://github.com/neo-project/neo-modules/releases/) 插件）
2. 向 Neo RPC 服务器发送 getnep17balances 请求获取资产 hash 和数量。
3. 向 Neo RPC 服务器发送两次 invokefunction 请求分别获取对应资产的标识符（symbol）和精度（decimals）。
4. 根据返回值计算出用户余额。

要查询特定用户的某一种资产余额,，可以使用 `invokefunction` 来调用资产的 `balanceOf` 方法。

#### 调用 getnep17balances

在 JSON 文件中，getnep17balances 的请求正文通常为以下格式：
```json
{
  "jsonrpc": "2.0",
  "method": "getnep17balances",
  "params": ["NVfJmhP28Q9qva9Tdtpt3af4H1a3cp7Lih", 0],
  "id": 1
}
```

发送请求后，将收到如下响应：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "balance": [
            {
                "asset_hash": "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5",
                "amount": "2",
                "last_updated_block": 52675
            },
            {
                "asset_hash": "0xd2a4cff31913016155e38e474a2c06d08be276cf",
                "amount": "700000000",
                "last_updated_block": 52675
            }
        ],
        "address": "NVfJmhP28Q9qva9Tdtpt3af4H1a3cp7Lih"
    }
}
```
可以看到用户有两种资产，资产 hash 分别为 "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5" 和 "0xd2a4cff31913016155e38e474a2c06d08be276cf"。

此时需要调用 invokefunction 来获取资产的 symbol 和 decimals，下文会具体介绍。

在这里 A 资产的 symbol 是 NEO， decimals 是 0，用户 A 资产余额 = 2 NEO。B 资产的 symbol 是 GAS， decimals 是 8，用户 A 资产余额 = 700000000/10⁸ GAS = 7 GAS。

#### 调用 invokefunction

在 JSON 文件中，invokefunction 的请求正文通常为以下格式：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "script hash",
    "method name",
    [
      {
        "optional arguments"
      }
    ]
  ],
  "id": 1
}
```

查询用户余额时，你需要替换上例中的这些字符：

**script hash**

要查询的 NEP-17 资产的脚本哈希，例如：

NEO脚本哈希是：*0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5*       

GAS脚本哈希是：*0xd2a4cff31913016155e38e474a2c06d08be276cf*

**method name**

要调用的方法。要查询用户余额，需要调用以下三个方法：

balanceOf

- 语法：`public static BigInteger balanceOf(byte[] account)`
- 说明："balanceOf" 返回 "account" 的最小粒度为1单位的余额。

decimals

- 语法：`public static byte decimals()`
- 说明： "decimals" 返回代币使用的小数位数。

symbol

- 语法：`public static string symbol()`
- 说明："symbol" 返回币种符号。


- optional arguments

  可选。如果调用的方法需要参数，可以将这些参数构造成一个数组传入。例如，NEP-17 的 "balanceOf" 返回 "account" 的余额：

  `public static BigInteger balanceOf(byte[] account)`

  因此，你需要把 account 作为 "balanceOf" 方法的一个参数。

##### 调用示例

##### **调用 balanceOf**

假设用户账户地址是 NYxb4fSZVKAz8YsgaPK2WkT3KcAE9b3Vag，你需要将其转换为 Hash160 类型并将此参数构造成 JSON 对象，如下所示:

```json
{
    "type": "Hash160",
    "value": "0x762f8a2bf0e8673c64cc608ba69b9c2a946a188f"
}
```

然后构造如下 JSON 参数：

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xd2a4cff31913016155e38e474a2c06d08be276cf",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "0x762f8a2bf0e8673c64cc608ba69b9c2a946a188f"
      }
    ]
  ],
  "id": 3
}
```

发送请求后，会收到如下响应：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "DBSPGGqUKpybpotgzGQ8Z+jwK4ovdhHAHwwJYmFsYW5jZU9mDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtS",
        "state": "HALT",
        "gasconsumed": "2028330",
        "exception": null,
        "stack": [
            {
                "type": "Integer",
                "value": "1938845793634190"
            }
        ]
    }
}
```

返回值无需转换，只需除以 decimals 得到余额即可。

##### **调用 decimals**

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xd2a4cff31913016155e38e474a2c06d08be276cf",
    "decimals",
    []
    ],
  "id": 2
}
```

发送请求后，将收到如下响应：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "wh8MCGRlY2ltYWxzDBTPduKL0AYsSkeO41VhARMZ88+k0kFifVtS",
        "state": "HALT",
        "gasconsumed": "984060",
        "exception": null,
        "stack": [
            {
                "type": "Integer",
                "value": "8"
            }
        ]
    }
}
```

返回值为整数 **8**。

##### **调用 symbol**

请求正文:

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xd2a4cff31913016155e38e474a2c06d08be276cf",
    "symbol",
    []
  ],
  "id": 3
}
```

发送请求后，将收到如下响应：

```json
{
    "jsonrpc": "2.0",
    "id": 3,
    "result": {
        "script": "wh8MBnN5bWJvbAwUz3bii9AGLEpHjuNVYQETGfPPpNJBYn1bUg==",
        "state": "HALT",
        "gasconsumed": "984060",
        "exception": null,
        "stack": [
            {
                "type": "ByteString",
                "value": "R0FT"
            }
        ]
    }
}
```

返回值 "R0FT" 可以被 base64 解码为 "GAS"。

##### **计算用户余额**

根据所有返回值，可以计算出用户余额为：
用户余额 = balanceOf 返回值 / 10<sup>decimals</sup>。

### 交易所用户的账户余额

用户实际在交易所里的余额，应当记录在交易所的数据库里。 交易所需要编写程序监控每个区块的每个交易，在数据库中记录下所有充值提现交易，对应修改数据库中的用户余额，以供用户查询使用。


## 处理充值交易

交易所处理充值交易的操作如下：

1. 通过 getblock API 获取每个区块的详情，其中便包括该区块中所有交易的详情；

3. 调用 getapplicationlog API 获取每笔交易的详情，分析交易内容，完成用户充值。

### 调用 getapplicationlog

使用 [getapplicationlog](../reference/rpc/latest-version/api/getapplicationlog.md) 这个 API 来获取交易信息。

正确安装 ApplicationLogs 插件并启动 Neo-CLI 节点后，可以看到在neo-cli 根目录下生成了一个 ApplicationLogs 文件夹，完整的合约日志会记录到该目录下，每笔 NEP-17 交易会记录在 leveldb 文件中，通过 API 来读取。

以下是一个 API 调用结果：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xd9aaa1243cae91e063a140239807a9de45f82850130ec36403f44770955dd2d7",
        "trigger": "Application",
        "vmstate": "HALT",
        "gasconsumed": "11819770",
        "stack": [],
        "notifications": [
            {
                "contract": "0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec",
                "eventname": "Transfer",
                "state": {
                    "type": "Array",
                    "value": [
                        {
                            "type": "ByteString",
                            "value": "uXtKzX+CD2HS1NT5rqXrUEmN31U="
                        },
                        {
                            "type": "ByteString",
                            "value": "7ztGBn8vR7L38EQqojcghdCHCO8="
                        },
                        {
                            "type": "Integer",
                            "value": "800000000000"
                        }
                    ]
                }
            }
        ]
    }
}
```

> [!Note]
>
> 上例显示的是一个成功转账交易的日志，但如果传输失败或NeoVM执行异常，显示结果可能是以下情况:
>
> - 转账失败: 不返回 Transfer notifications。执行状态 vmstate 显示 `HALT` 且 stack 值为 `False`。
> - NeoVM 异常: 可能返回或不返回 Transfer notifications。执行状态 vmstate 显示 `FAULT` 。

其中与交易相关的参数如下：

- **contract**: 该字符串为智能合约的脚本哈希，对于交易所来说，这里是 NEP17 类型资产的脚本哈希，交易所可以以此来确定资产的唯一性。例如，"0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec" 就是该NEP17 资产的脚本哈希，是该资产在全网的唯一标识。

- **eventname**: 该字段为合约事件标识，对于交易所来说，应当只监听标识为 Transfer 类型的交易以确认是否为用户的转账交易。 

  notifications 数组中可能有多个 eventname, 只有关键字为 Transfer 的 eventname 才是 NEP17 转账数据。

- **state**: 对于转账交易，该数组包含以下三个对象：

  - 转出账户地址：数组中的的第一个对象，类型为 bytearray，值为 "uXtKzX+CD2HS1NT5rqXrUEmN31U="，经过 base64 解码为 ByteArray 后再转换为字符串 "NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o"。
  
    > [!Note]
    >
    > Neo 中 16 进制值如果前面加 0x，按大端序处理，如果没加 0x，按小端序处理。
    ```json
    {
      "type": "ByteString",
      "value": "uXtKzX+CD2HS1NT5rqXrUEmN31U="
    }
    ```
  
   - 转入账户地址：数组中的第二个对象，类型为 bytearray，值为 "7ztGBn8vR7L38EQqojcghdCHCO8="，经过 base64 解码为 ByteArray 后再转换为字符串 "Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z"。对于交易所来说，如果该地址为交易所地址，那么该交易是一笔充值交易。
    ```json
    {
      "type": "ByteString",
      "value": "7ztGBn8vR7L38EQqojcghdCHCO8="
    }
    ```
  - 转账金额：数组中的的第三个对象，值为 "800000000000"。因为 decimal 为 8 位，所以实际值是 8000.00000000。
    
    ```json
    {
      "type": "Integer",
      "value": "800000000000"
    }
    ```

> [!Note]
>
> 关于文件中 transfer 数据格式的转换，可以参考官方页面 [Neo数据转换](https://neo.org/converter/index)。

## 处理提现交易

交易所可以通过以下一种方式发送资产给用户，客户端则必须打开钱包才能使用以下 API：

- Neo-CLI 命令： `send`
- RPC 方法： `sendfrom`
- RPC 方法： `sendtoaddress`
- RPC 方法： `sendmany`

### Neo-CLI 命令：send

##### 语法

`send <id|alias> <address> <amount>|all [from=null] [signerAccounts=null]`

##### 参数

- `id|alias`：资产 ID或资产缩写，如 neo，gas
- `address`：收款地址
- `amount|all`：转账金额
- `from`：转出地址
- `signerAccounts`：需要添加签名的账户

该命令会检查钱包密码。

##### 示例

将 100 GAS 转到地址 “NYxb4fSZVKAz8YsgaPK2WkT3KcAE9b3Vag”，输入以下命令：

```
neo> send a1760976db5fcdfab2a9930e8f6ce875b2d18225 NYxb4fSZVKAz8YsgaPK2WkT3KcAE9b3Vag 100
password: ********
TXID: 0x8f831d8de723093316c05749a053a226514bc06338b2bceb50db690610e0b92f
```

第二个参数除了资产 ID，还可以填写资产缩写，所以以上命令也可以写成：

```
neo> send gas NYxb4fSZVKAz8YsgaPK2WkT3KcAE9b3Vag 100
password: ********
TXID: 0xae0675797c2d738dcadb21cec3f1809ff453ac291046a05ac679cbd95b79c856
```

要查看资产 ID ，可输入 `list asset` 命令查看钱包中的所有资产。

### RPC 方法：openwallet

> [!Note]
>
> 在任何调用钱包相关操作的 RPC 方法之前，需要先调用 `openwallet` 这个 RPC 方法打开钱包。

"params"  是一个包含 2 个参数的数组。

`"params":[path， password]`

例如，要打开密码为 `111111` 的名为 `a.json` 的钱包，可以编写如下 JSON 请求发送给 RPC 服务器。

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "openwallet",
  "params": ["a.json", "111111"],
  "id": 1
}
```

发送请求后，将收到如下响应：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": true
}

```

### RPC 方法：sendfrom

 "params"  包含一个 4 个参数的数组。

`"params":[script hash, address from, address to, amount ]`

例如，要从地址 NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o 发送 10 NEO 到地址 Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z，编写如下 JSON 文件并发送给 RPC 服务器。

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendfrom",
  "params": ["0xf61eebf573ea36593fd43aa150c055ad7906ab83","NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o","Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z", 10],
  "id": 1
}
```

发送请求后，将收到如下响应：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0x2dad82755c3b3e3233c10a49402bea9b8bb3f43b079102bbc3c5a50c3b522137",
        "size": 264,
        "version": 0,
        "nonce": 1073258915,
        "sender": "NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o",
        "sysfee": "9007990",
        "netfee": "1264390",
        "validuntilblock": 2107189,
        "attributes": [
            {
                "type": "Cosigner",
                "account": "0x55df8d4950eba5aef9d4d4d2610f827fcd4a7bb9",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "GgwU7ztGBn8vR7L38EQqojcghdCHCO8MFLl7Ss1/gg9h0tTU+a6l61BJjd9VE8AMCHRyYW5zZmVyDBQlBZ7LSHjTqHX5HFHO3tMw1Fdf3kFifVtSOA==",
        "witnesses": [
            {
                "invocation": "DEBL7Fxz2ZyIgtz+kESSs8YjbJd5dcc13gpxOwrLjU+WiIa0fuFQSgHXM75S1Z21wDMvEirUHpU1rIYylfnQH6Ul",
                "verification": "DCECTLb+CYh0tAkrQbRliAmdLaB5NLR0FqIWxgiCPlnz/B4LQZVEDXg="
            }
        ]
    }
}

```

### RPC 方法：sendtoaddress

 "params"  包含一个 3 个参数的数组。

`"params":[script hash, address, amount]`

例如，要发送 1000 GAS 到地址 Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z，编写如下 JSON 文件并发送给 RPC 服务器。

请求正文：

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["0x70e2301955bf1e74cbb31d18c2f96972abadb328", "Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z", 1000],
  "id": 1
}
```

发送请求后，将收到如下响应：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xda4de7d6fc3bcd0eba51a3dcba01eaba7d59467acf91525c5f3f0b56df06aec8",
        "size": 272,
        "version": 0,
        "nonce": 1325103139,
        "sender": "NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o",
        "sysfee": "9007990",
        "netfee": "1272390",
        "validuntilblock": 2107253,
        "attributes": [
            {
                "type": "Cosigner",
                "account": "0x55df8d4950eba5aef9d4d4d2610f827fcd4a7bb9",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "AwDodkgXAAAADBTvO0YGfy9HsvfwRCqiNyCF0IcI7wwUuXtKzX+CD2HS1NT5rqXrUEmN31UTwAwIdHJhbnNmZXIMFLyvQdaEx9StbuDZnalwe50fDI5mQWJ9W1I4",
        "witnesses": [
            {
                "invocation": "DEBd+BDi7LWMQ5zzWxmzvH9zsO9fRZpdqn9SqnyEfSzazVnFsUlDJG7ik79epcqpF+IWGQJM1lS1oDeI4Eh/Yq04",
                "verification": "DCECTLb+CYh0tAkrQbRliAmdLaB5NLR0FqIWxgiCPlnz/B4LQZVEDXg="
            }
        ]
    }
}
```

### RPC 方法：sendmany

"params"  包含至少两个参数的数组。

`"params":[address from(optional), []]`

例如，要从 NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o 发送 100 NEO 和 1000 GAS 到 Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z，编写如下 JSON 文件并发送给 RPC 服务器。

请求正文：

```json
{
    "jsonrpc": "2.0",
    "method": "sendmany",
    "params": [
    "NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o",
        [
            {
                "asset": "0xf61eebf573ea36593fd43aa150c055ad7906ab83",
                "value": 100,
                "address": "Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z"
            },
            {
                "asset": "0x70e2301955bf1e74cbb31d18c2f96972abadb328",
                "value": 1000,
                "address": "Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z"
            }
        ]
    ],
    "id": 1
}
```

发送请求后，将收到如下响应：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "hash": "0xea4564840441713481363ffc0b3e2df95e5319af4d5da4189603c2333d6702f5",
        "size": 358,
        "version": 0,
        "nonce": 93745276,
        "sender": "NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o",
        "sysfee": "18015980",
        "netfee": "1358390",
        "validuntilblock": 2107284,
        "attributes": [
            {
                "type": "Cosigner",
                "account": "0x55df8d4950eba5aef9d4d4d2610f827fcd4a7bb9",
                "scopes": "CalledByEntry"
            }
        ],
        "script": "AGQMFO87RgZ/L0ey9/BEKqI3IIXQhwjvDBS5e0rNf4IPYdLU1PmupetQSY3fVRPADAh0cmFuc2ZlcgwUJQWey0h406h1+RxRzt7TMNRXX95BYn1bUjgDAOh2SBcAAAAMFO87RgZ/L0ey9/BEKqI3IIXQhwjvDBS5e0rNf4IPYdLU1PmupetQSY3fVRPADAh0cmFuc2ZlcgwUvK9B1oTH1K1u4NmdqXB7nR8MjmZBYn1bUjg=",
        "witnesses": [
            {
                "invocation": "DEA1J31Wq9CS6s7Zyzv71jS/LXbJroKgzMhTk176KaCNDBIas5kqBgsv0hHVxetxdwnapXU7Cui/9PlHr3fZNPf3",
                "verification": "DCECTLb+CYh0tAkrQbRliAmdLaB5NLR0FqIWxgiCPlnz/B4LQZVEDXg="
            }
        ]
    }
}
```

## 相关参考

[NEP-17 Token Standard](https://github.com/neo-project/proposals/blob/nep-17/nep-17.mediawiki) 

[Neo 数据转换](https://neo.org/converter/index)