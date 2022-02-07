# Dealing with Asset Transactions

## Overview

Neo N3 has only one type of digital assets, i.e. NEP-17 assets, which are managed by BALANCE. The exchanges mainly deal with user balance queries,  deposits, withdrawals, and other operations of this type assets.

Following flow charts show the work processes of these operations:

![](assets/query.png)

![](assets/deposit.png)

![](assets/withdraw.png)

## Network fee

The network fee, as a reward for the consensus nodes generating blocks, is charged when the user submits a transactions to Neo blockchain. There is a  base fee for each transaction and the calculation formula is shown below. The transaction is only executed if the fee paid by the user is greater than or equal to the base fee; otherwise, the transaction will be treated as invalid.  

```
NetworkFee = VerificationCost + tx.size * FeePerByte
```

- VerficationCost: Fees for instructions executed by NeoVM to verify transaction signatures.
- tx.size: The transaction data byte length
- FeePerByte: Transaction fee per byte, currently defined as 0.00001 GAS in PolicyContract.

## System fee

The system fee is charged for the instructions executed by NeoVM. For each instruction fee refer to [System Fee](../reference/fees.md). The total system fee you need to pay depends on the number and type of the instructions executed by your smart contract. The following figure shows the calculation formula:

```
SystemFee = InvocationCost = The sum of all executed opcode fee
```

### **Instructions fee**

In Neo N3, NeoVM instructions fee has decreased to 1/1000 of the original fee in Neo Legacy, which significantly reduces the development cost. 

In comparison with Neo Legacy: 

![netfee](../../zh-cn/exchange/assets/feecomparewith2x.png)

## Dealing with query transactions

The way for a exchange itself to query balance of the user deposit address is different than the way it deal with the user's request of balance querying. 

### Querying the user deposit address balance

The exchange needs to do the following:

1. Construct JSON files to invoke either of the following RPC methods:
   - getnep17balances (Plugin [TokensTracker](https://github.com/neo-project/neo-modules/releases/) is required)
   - invokefunction (Plugin [RpcServer](https://github.com/neo-project/neo-modules/releases/) is required)
2. Send a `getnep17balances` request to the Neo RPC server to get the asset hash and amount.
3. Send the invokefunction requests twice to the Neo RPC server to get the corresponding asset symbol and decimals, respectively.
4. Calculate the user balance according to the returned values.

To query the balance of an asset for a particular user, use `invokefunction` to call the `balanceOf` method of asset.

#### Invoking getnep17balances to query

In JSON, a general getnep17balances request body is in the following form: 

```json
{
"jsonrpc": "2.0",
"method": "getnep17balances",
"params": ["NVfJmhP28Q9qva9Tdtpt3af4H1a3cp7Lih"],
"id": 1
}
```

After sending the request you will get the following response:

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

As we can see in the request above, there are two kinds of assets which hashes are "0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5" and "0xd2a4cff31913016155e38e474a2c06d08be276cf". Now we need to call invokefunction to get symbol and decimals of the asset, which will be elaborated below.

In the example above the asset A symbol is NEO, decimals is 0, and the user A balance is 2 NEO.  For the asset B, its symbol is GAS, decimals is 8, and the balance is 700000000/10⁸ GAS (7 GAS).

#### Invoking invokefunction to query

In JSON, a general invokefunction request body is in the following form: 

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

You need to replace these strings when querying the user's balance:

- script hash

  The script hash of the NEP-17 asset you are querying. For example:
  
  - NEO is *0xef4073a0f2b305a38ec4050e4d3d28bc40ea63f5*
  - GAS is *0xd2a4cff31913016155e38e474a2c06d08be276cf*


- method name

  The name of the method you are invoking. To query the user's balance, you need to invoke these three methods:

  **balanceOf**

  - Syntax: `public static BigInteger balanceOf(byte[] account)`
  - Remarks: "balanceOf" returns the token balance of the '''account'''.

  **decimals**

  - Syntax: `public static byte decimals()`
  - Remarks: "decimals" returns the number of decimals used by the token.

  **symbol**

  - Syntax: `public static string symbol()`
  - Remarks: "symbol" returns the token symbol.


- optional arguments

  Optional. If the method you are invoking requires arguments, you can pass them by constructing these parameters into an array. For example, "balanceOf" in NEP-17 returns the token balance of the "account":

  `public static BigInteger balanceOf(byte[] account)`

  So you need to pass the account as an argument in the "balanceOf" method.

##### Example

##### **Invoking balanceOf**

Suppose the account address is NYxb4fSZVKAz8YsgaPK2WkT3KcAE9b3Vag, you need to convert it into Hash160 type and construct this parameter as a JSON object:

```json
{
    "type": "Hash160",
    "value": "0x762f8a2bf0e8673c64cc608ba69b9c2a946a188f"
}
```

Then you can construct the JSON message as the following:

Request Body：

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

After sending the request, you will get the following response：

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

To get the balance divide the returned value by decimals, without needing of data conversion.

##### **Invoking decimals**

Request Body：

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

After sending the request, you will get the following response：

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

It returns integer 8.

##### **Invoking symbol**

Request Body：

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

After sending the request, you will get the following response：

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

It returns "R0FT" which can be decoded to "GAS".

##### **Calculating the User Balance**

According to all the returned values,  we can calculate the user balance as follows:
The balance = return / 10<sup>decimals</sup>

### Dealing with users' queries

The actual user balance in the exchange is recorded in the exchange database. The exchange needs to write programs to monitor each transaction of each block, record all deposits and withdrawals transactions in the database, and modify the user balance in the database accordingly.

## Dealing with User Deposits

To get the user deposits information the exchange needs to do the following:

1. Get each block details using the `getblock` API, including details of all the transactions in the block.
2. Invoke the `getapplicationlog` API to get the details of each "InvocationTransaction" transaction and analyze the transaction content to complete the user deposit.

### Invoking getapplicationlog

This API is used to get transaction information.

After correctly installing the ApplicationLogs plug-in and starting the neo-cli node, you can find a folder "ApplicationLogs" is generated under the root path. The complete contract log is recorded in this directory, and each NEP-17 transaction is recorded in a leveldb file.

The following shows an example of the API invoking result. 

```JSON
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
> This example shows the log of a successful token transfer, however, in case of a failed transfer or NeoVM exception, the outcomes can be:
>
> - Failed transfer: no Transfer notification event is returned, execution ends in a `HALT` state with a stack value of `False`.
> - NeoVM exception: a Transfer notification event may or may not be returned, but execution ends in a `FAULT` state.

The parameters related to a transaction in the file are the following:

- **contract**: the script hash of smart contract. For exchanges, it is the script hash of NEP17 assets type and the unique identity of the asset. For example, here "0xd2c270ebfc2a1cdd3e470014a4dff7c091f699ec" is the NEP17 asset script hash.

- **eventname**: the event identifier of smart contact. Exchanges only need to listen on “transfer” transactions to find out users' transfer transactions. There may be more than one eventname in the Notifications array, and only those with the Transfer keyword are NEP17 Transfer data.

- **state**: The objects included in the array are:

  - from account: The first object in the array is the account address where the asset is transferred from. Its type "bytearray" and the value "uXtKzX+CD2HS1NT5rqXrUEmN31U=“ can be  decoded to "NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o" with base64. 

    > [!Note]
    >
    > In Neo, hexadecimal strings are processed in big-endian order if they are preceded by 0x, or little-endian order if they are not.
    
    ```json
    {
    "type": "ByteString",
      "value": "uXtKzX+CD2HS1NT5rqXrUEmN31U="
    }
    ```
    
  - to account: The second object in the array is the account address where the asset is transferred to.  Its type "bytearray" and the value "7ztGBn8vR7L38EQqojcghdCHCO8=“ can be decoded to "Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z" with base64. If the address is an exchange account address, it is a deposit transaction.
  
    ```json
    {
  "type": "ByteString",
      "value": "7ztGBn8vR7L38EQqojcghdCHCO8="
  }
    ```
  
  - amount: The last object in the array is the transfer amount, which value is 800000000000. Since the decimal is 8 bit the value is actually 8000.00000000.
  
    ```
    {
      "type": "Integer",
      "value": "800000000000"
    }
    ```
    

> [!Note]
>
> Regarding the data format conversion of the transfer in the file, you can refer to [Neo3 data conversion](https://neo.org/converter/index).

## Dealing with User Withdrawals

The exchange can choose one of the following way to send assets to users: 

- Neo-CLI command: `send`
- RPC method: `sendfrom`
- RPC method: `sendtoaddress`
- RPC method: `sendmany`

### Neo-CLI Command: send

##### Syntax

`send <id|alias> <address> <amount>|all [from=null] [signerAccounts=null]`

##### Parameters

- `id|alias`: asset ID or asset abbreviations, e.g. neo, gas
- `address`: address to transfer assets to
- `amount|all`: transfer amount
- `from`: address to transfer assets from
- `signerAccounts`: signer's address


This command verifies the wallet password. 

##### Example

Transfer 100 Neo to the address AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e: 

```
neo> send a1760976db5fcdfab2a9930e8f6ce875b2d18225 AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e 100
password: ********
TXID: 0x8f831d8de723093316c05749a053a226514bc06338b2bceb50db690610e0b92f
```

If you are not sure of the asset ID, you can enter `list asset` to view all assets in the wallet.

In above example, we can also replace the asset ID with asset abbreviation, as shown below:

```
neo> send gas AMwS5twG1LLJA4USMPFf5UugfUvEfNDz6e 100
password: ********
TXID: 0xae0675797c2d738dcadb21cec3f1809ff453ac291046a05ac679cbd95b79c856
```

### RPC Method: openwallet

> [!Note]
>
> Before you can invoke any of the wallet-related RPC methods you must invoke the method `openwallet` first.

The key "params" includes an array of two parameters.

`"params":[path， password]`

For example, to open the wallet `a.json` with a password `111111`, you can construct a JSON file as follows and send it to RPC server.

Request body：

```json
{
  "jsonrpc": "2.0",
  "method": "openwallet",
  "params": ["a.json", "111111"],
  "id": 1
}
```

After sending the request, you will get the following response:

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": true
}

```

### RPC Method: sendfrom

The key "params" includes an array of four parameters.

`"params":[script hash, address from, address to, amount]`

For example, to send 10 NEO from NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o to  Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z, construct a JSON file as follows and send it to RPC server.

Request body:

```json
{
  "jsonrpc": "2.0",
  "method": "sendfrom",
  "params": ["0xf61eebf573ea36593fd43aa150c055ad7906ab83","NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o","Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z", 10],
  "id": 1
}
```

After sending the request, you will get the following response：

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

### RPC Method: sendtoaddress

The key "params" includes an array of three parameters. 

`"params":[script hash, address, amount]`

For example, to send 1000 GAS to Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z , construct a JSON file as follows and send it to RPC server.

Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "sendtoaddress",
  "params": ["0x70e2301955bf1e74cbb31d18c2f96972abadb328", "Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z", 1000],
  "id": 1
}
```

After sending the request, you will get the following response：

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

### RPC Method: sendmany

The key "params" includes an array of at least two parameter:

`"params":[address from(optional), []]`

For example, to send 100 NEO and 1000 GAS to Nhiuh11SHF4n9FE6G5LuFHHYc7Lgws9U1z  from NcphtjgTye3c3ZL5J5nDZhsf3UJMGAjd7o, you can construct a JSON file as follows and send it to RPC server.

Request Body：

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

After sending the request, you will get the following response：

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

## See Also

[NEP17 Token Standard](https://github.com/neo-project/proposals/blob/nep-17/nep-17.mediawiki)

[Neo3 Data Conversion](https://neo.org/converter/index)
