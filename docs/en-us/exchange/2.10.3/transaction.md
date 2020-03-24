# Dealing with Asset Transactions

## Overview

NEO has two types of digital assets. One is global assets, e.g. NEO, GAS, which are managed by UTXO. The other is contract assets, e.g. NEP-5 assets, which are managed by BALANCE. The exchanges mainly deal with user balance queries,  deposits, withdrawals, and other operations of these two types of assets.

Following flow charts show the work processes of these operations:

![](../assets/query.png)

![](../assets/deposit.png)

![](../assets/withdraw.png)

## Network fee

For the purpose of preventing malicious transactions and network attacks, network fees are charged when using the NEO blockchain. Under the current mechanism, normal transactions for ordinary users do not increase additional fees. The default charging rules are as follows:

<table class='table table-hover'>
    <thead>
        <tr>
            <th>Transaction type</th>
            <th>Transaction size (byte）</th>
            <th>Total fee (GAS)</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td rowspan="2">Non-ClaimTransaction transactions</td>
            <td>&lt;= 1024</td>
            <td>0</td>
        </tr>
        <tr>
            <td>&gt; 1024</td>
            <td>Transaction size&times;0.00001 + 0.001<br></td>
        </tr>
        <tr>
            <td rowspan="3">ClaimTransaction</td>
            <td>All</td>
            <td>0</td>
        </tr>
    </tbody>
</table>



> [!Note]
>
> - If the exchange specifies fee when using the send command/method to send the transaction to the user's address, only the higher of the two fees is charged.
> - A configuration file config.json is added in NEO-CLI 2.10.2+ RpcWallet plugin to allow you to specify the fee limit for transactions sent using RPC commands. If the transaction fee does not exceed the fee limit, it will be processed on blockchain normally; otherwise the transaction will fail.

## Dealing with Global Assets Transactions

### Querying User Balance

In general, the balance of a deposit address in the exchange is not equal to the balance the user has in the exchange. It may because：

- When transferring or withdrawing, the NEO wallet looks through one or more addresses in the wallet, finds the minimal loose change that meets the requirement and adds up to the total sum of the transaction and then serves that as the input, instead of withdrawing from the specified address (unless the exchange rewrites some functions of NEO wallet to meet their own needs).
- Other operations that may lead to balance inequality, for example, the exchange transfers part of the assets to its cold wallets.

Therefore, the way for a exchange itself to query balance of the user deposit address is different than the way it deal with the user's request of balance querying. 

#### Querying the user deposit address balance

The exchange can query global assets of a user deposit address by invoking  the getaccountstate API.

**getaccountstate** 

In a JSON file the request text of getaccountstate is in the following format： 

```
{
  "jsonrpc": "2.0",
  "method": "getaccountstate",
  "params": ["AJBENSwajTzQtwyJFkiJSv7MAaaMc7DsRz"],
  "id": 1
}
```

 Where params is the user deposit address. 

After sending the request, the following response text is returned: 

```
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "version": 0,
        "script_hash": "0x1179716da2e9523d153a35fb3ad10c561b1e5b1a",
        "frozen": false,
        "votes": [],
        "balances": [
            {
                "asset": "0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
                "value": "94"
            }
        ]
    }
}
```

 Where "asset" is the asset ID  and value is the asset balance.

#### Dealing with users' queries

The actual user balance in the exchange is recorded in the exchange database. The exchange needs to write programs to monitor each transaction of each block, record all deposits and withdrawals transactions in the database, and modify the user balance in the database accordingly.

### Dealing with User Deposits 

Regarding user deposits, the exchange needs to note the following: 

- NEO blockchain has only one main chain without side chains, will not fork, and will not have isolated blocks.

- A transaction recorded in NEO blockchain cannot be tampered with, which means a confirmation represents a deposit success.

- There are more than two assets (NEO and NEO GAS) in a NEO address. More assets issued by users (such as stock or token) can be stored. The exchange should determine the assets type when the user deposits. Neither regard other assets as NEO  or GAS nor confuse the withdrawal of NEO with GAS. 

- NEO wallet is a full node, which needs to stay online to synchronize blocks. You can view the block synchronization status through the show state in NEO-CLI, for example:

  ```
  ... 
  neo>show state
  Height: 99/99/99, Nodes: 10 
  ...
  ```

  That indicates: wallet height is 99/blockchain height is 99/blockchain header height is 99, and number of the connected nodes is 10.

  Suppose this node is fully connected to the P2P network, when the block height gets to the same as the block header height, the node synchronization is completed. Furthermore, when the wallet height, the block height and the block header height are the same, that indicates the node synchronization is completed and the wallet index establishment is completed. 

- In the exchange, the transfer between users should not be recorded through the blockchain. In general, the user's balance are modified in the database directly. Only deposits and withdrawals should be recorded on the blockchain.

#### Deposit Records

The exchange needs to write code to monitor every transaction in a block and record all the transactions related to the exchange addresses in the database. If a deposit occurs, the user's balance should be updated. 

Developers can use the  `getblock <index> [verbose]` method of NEO-CLI API to retrieve the block information. `<index>` is the block index. `[verbose]` is 0 by default. When `[verbose]` is 0, the method returns the serialized block information in Hexadecimal. You should deserialize the hex string to get the detailed information of the block. When `[verbose]` is 1, the method returns the detailed information of the corresponding block in JSON format. For more information, refer to [getblock Method](../../reference/rpc/latest-version/api/getblock2.md).

The block information includes the transactions input and output. The exchange needs to record all its related transactions. The transactions output is in fact the transaction records of the withdrawals of a user. When the exchange sees any of its addresses in the output of the transactions, it updates the NEO/GAS balance of the corresponding user who owns this deposit address. Some exchanges may also do as follows: if it finds an address within the exchange as the output of the transaction, then it records the deposit in its database and modifies the user’s balance after several confirmations (Unless it needs to comply with the operation of other blockchains, this way is not recommended) . 

> [!Note]
>
> - Method getblockcount returns the count of the blocks in the main chain. The first parameter of Method getblock is `<index>` which is the block index. Block index = Block height = The count of the blocks – 1. If getblockcount returns 1234, you should use getblock 1233 to get the information of the latest block. 
> - The exchanges deposit and withdrawal transactions (NEO/GAS) may be the type InvocationTransaction or ContractTransaction. The exchanges only need to care about if there is value assigned to vout of every transaction when they check through the transactions in a block. 
> - As the first transaction of every block must be MinerTransaction, you can neglect or jump over it when traversing the blockchain. 
> - NEO system takes the transaction as a record unit.
>

### Dealing with User Withdrawals 

To deal with the user withdrawals for global assets, the exchange needs to do the following:

1. In NEO-CLI, run `open wallet <path>` to open the wallet.

2. Record the user withdrawal transaction and modify the user balance.

3. (Optional) Customer service deals with withdrawal application.

4. Send transaction to the user's withdrawal address using the NEO-CLI API method, `sendtoaddress <asset_id> <address> <value> [fee=0] [Change_address]`. For more information, refer to  [sendtoaddress Method](../../reference/rpc/latest-version/api/sendtoaddress.md).

   - `<asset_id>` : Asset ID
   - `<address>` : Withdrawal address
   - `<value>` : Withdrawal amount
   - `[fee]`: Optional parameter. Paying the handling fee helps elevate the priority of the network to process the transfer. It defaults to 0, and can be set to a minimum of 0.00000001.
   - `Change_address`: Change address, optional parameter, default is the first standard address in the wallet

   You can also send the transaction to a batch of addresses using API [sendmany Method](../../reference/rpc/latest-version/api/sendmany.md).

5. Extract the transaction ID from the returned transaction details in the JSON format,  and then record in the database.

6. Once confirmed by the blockchain, mark the withdrawal transaction as success. 

   Similar to deposit monitoring, withdrawals also need to be monitored. If the withdrawal transaction ID  is found in the blockchain, it means this transaction has already been confirmed and is a successful withdrawal.

> [!Note]
>
> -  The <value> here refers to the actual amount, instead of the amount multiplied by 10^8.
> -  NEO transfer amount must be an integer; otherwise, the transfer will remain unconfirmed although the transaction can be constructed in NEO-CLI, and will thus affect the wallet change status and cause sending failure of other transactions.  In this situation, you need to rebuild wallet index, so as to recalculate the transactions and change of the wallet.

## Dealing with NEP-5 Assets Transactions

### Querying User Balance

Similar to global assets, the way for a exchange itself to query balance of the user deposit address is different than the way it deal with the user's request of balance querying. 

#### Querying the user deposit address balance

To query the user's balance, the exchange needs to do the following:

1. Construct JSON files to invoke three methods (`balanceOf`, `decimals`, and `symbol`) through the RPC API invokefunction. 
2. Send the JSON files to NEO RPC server.
3. Calculate the user balance according to the returned values.

##### invokefunction

In JSON, a general invokefunction request body is in the following form: 

```
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

  The script hash of the NEP-5 token you are querying. For example, you can find the script hash of RPX is : *0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9*.


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

  Optional. If the method you are invoking requires arguments, you can pass them by constructing these parameters into an array. For example, "balanceOf" in NEP-5 returns the token balance of the "account":

  `public static BigInteger balanceOf(byte[] account)`

  So you need to pass the account as an argument in the "balanceOf" method.

##### Example

##### **Invoking balanceOf**

Suppose the account address is AKibPRzkoZpHnPkF6qvuW2Q4hG9gKBwGpR, you need to convert it into Hash160 type and construct this parameter as a JSON object:

```json
{
    "type": "Hash160",
    "value": "0xa7274594ce215208c8e309e8f2fe05d4a9ae412b"
}
```

Then you can construct the JSON message as the following:

Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "balanceOf",
    [
      {
        "type": "Hash160",
        "value": "0xa7274594ce215208c8e309e8f2fe05d4a9ae412b"
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
        "script": "142b41aea9d405fef2e809e3c8085221ce944527a751c10962616c616e63654f6667f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ec",
        "state": "HALT",
        "gas_consumed": "0.338",
        "stack": [
            {
                "type": "ByteArray",
                "value": "00c2eb0b"
            }
        ]
    }
}
```

It returns "00c2eb0b" which can be converted to interger **200000000**.

##### **Invoking decimals**

Request Body：

```json
{
  "jsonrpc": "2.0",
  "method": "invokefunction",
  "params": [
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
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
    "id": 2,
    "result": {
        "script": "00c108646563696d616c7367f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ec",  
        "state": "HALT",
        "gas_consumed": "0.156",
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
    "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    "symbol", 
    []
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
        "script": "00c10673796d626f6c67f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ec",          "state": "HALT",
        "gas_consumed": "0.141",
        "stack": [
            {
                "type": "ByteArray",
                "value": "525058"
            }
        ]
    }
}
```

It returns "525058" which can be converted to string "RPX".

##### **Calculating the User Balance**

According to all the returned values,  we can calculate the user balance as follows:
The balance = 200000000/10<sup>8</sup> RPX = 2 RPX

#### Dealing with users' queries

The actual user balance is retrieved from the exchange database. 

### Dealing with User Deposits

Similar to global assets, the exchange can get the user deposits information of the NEP-5 assets by doing the following:

1. Get each block details using the `getblock` API, including details of all the transactions in the block.
2. Analyze each transaction type and filter out all transactions of the type "InvocationTransaction". Any transaction other than "InvocationTransaction" can not be a transfer transaction of NEP-5 assets.
3. Invoke the `getapplicationlog` API to get the details of each "InvocationTransaction" transaction and analyze the transaction content to complete the user deposit.

#### Invoking getapplicationlog

This API is used to get transaction information.

A folder "ApplicationLogs" is generated under the root path. The complete contract log is recorded in this directory, and each NEP-5 transaction is recorded in a leveldb file.

The following shows an example of the API invoking result. Note that the response structure since 2.9.0 has been changed.

```JSON
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xff488264c1abf9f5c3c17ed8071f6dd3cd809b25797a43af49316490ded8fb07",
        "executions": [
            {
                "trigger": "Application",
                "contract": "0x0110a8f666bcc650dc0b544e71c31491b061c79e",
                "vmstate": "HALT",
                "gas_consumed": "2.855",
                "stack": [
                    {
                        "type": "Integer",
                        "value": "1"
                    }
                ],
                "notifications": [
                    {
                        "contract": "0xb9d7ea3062e6aeeb3e8ad9548220c4ba1361d263",
                        "state": {
                            "type": "Array",
                            "value": [
                                {
                                    "type": "ByteArray",
                                    "value": "7472616e73666572"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "e3069da508f128069a0cd2544b0728ccbacdfb43"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "d142f89e93b2717426a8130c37dad93aad70cff5"
                                },
                                {
                                    "type": "ByteArray",
                                    "value": "00e1f50500000000"
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



> [!Note]
>
> - The failed NEP-5 transaction can also be recorded in blockchain, so you need to determine whether the vm status parameter "vmstate" is correct. 
> - "vmstate" indicates the vm status after it executes the contract. If it contains "FAULT", that means the execution is failed and the transaction is invalid. 

The parameters related to a transaction in the file are the following:

- **contract**: the script hash of smart contract, by which the exchange can identify assets type. For example, "0xb9d7ea3062e6aeeb3e8ad9548220c4ba1361d263" is the script hash and the unique identification of the QLC asset.

- The four objects included in the "value" array of "state" are:

  [event, from account, to account, amount]

  - The first object with the type "bytearray" and the value "7472616e73666572", as shown in the example, can be converted to the string "transfer". "transfer" is a method in NEP-5 that represents an asset transfer.

    ```json
    {
      "type": "ByteArray",
      "value": "7472616e73666572"
    }
    ```

  - The second object in the array is the account address where the asset is transferred from. Its type "bytearray" and the value "e3069da508f128069a0cd2544b0728ccbacdfb43“ can be converted to "AcUGxiaPjCiD74VWiFqPzudJHZo4QMza5Q". Note that for the hexadecimal string with "0x" prefix, it is processed as big endian; otherwise, it is processed as small endian.

    ```json
    {
      "type": "ByteArray",
      "value": "e3069da508f128069a0cd2544b0728ccbacdfb43"
    }
    ```

  - The third object in the array is the account address where the asset is transferred to.  Its type "bytearray" and the value "d142f89e93b2717426a8130c37dad93aad70cff5“ can be converted to "AarM6q48K55EBHhuRRRPVsGByrqBKoQoWf". If the address is an exchange account address, it is a deposit transaction.

    ```json
    {
      "type": "ByteArray",
      "value": "d142f89e93b2717426a8130c37dad93aad70cff5"
    }
    ```

  - The fourth object in the array is the transfer amount and its type is "bytearray". It is processed as little endian and turns to 0000000005f5e100  with the value 100000000 after reversed. Since the decimal is 8 bit the actual value is 100000000. There are two types of amount,  integer and bytearray. Note that when dealing with amount of the interger type, the value conversion method is different than that of the bytearray type.

    ```json
    {
      "type": "ByteArray",
      "value": "00e1f50500000000"
    }
    ```

> [!Note]
>
> You can write a tool to convert the values in the notification file into a more readable format. For your reference this is an example: [ApplicationLogsTools](https://github.com/chenzhitong/ApplicationLogsTools).

### Dealing with User Withdrawals

The exchange can choose one of the following way to send NEP-5 assets to users: 

- NEO-CLI command: `send`
- RPC method: `sendfrom`
- RPC method: `sendtoaddress`
- RPC method: `sendmany`

#### NEO-CLI Command: send

##### Syntax

`send <txid|script hash> <address> <value> [fee = 0] [Change_address]`

##### Parameters

- `txid|script hash`: the asset ID.
- `address`: the payment address.
- `value`: the transfer amount.
- `fee`: Optional parameter. Paying the handling fee helps elevate the priority of the network to process the transfer. It defaults to 0, and can be set to a minimum of 0.00000001.
- `Change_address`: Change address, optional parameter, default is the first standard address in the wallet.


This command verifies the wallet password. 

##### Example

To transfer 100 RPX to the address AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b with priority over other ordinary transfers, enter the following:

```
send 0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9 AeSHyuirtXbfZbFik6SiBW2BEj7GK3N62b 100 0.00000001
```

If you need to send global asset, just change the first parameter to txid. For example, 
The txid of NEO: 0xc56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b
The txid of GAS: 0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7

##### RPC Method: sendfrom

The key "params" includes an array of at least four parameters.

`"params":[script hash, address from, address to, amount, fee(optional), change address(optional)]`

For example, to send 1 RPX from AKibPRzkoZpHnPkF6qvuW2Q4hG9gKBwGpR to  AVECC4AcGXfDjm7cGmfGuxVRGTu6FxoQ7h, construct a JSON file as follows and send it to RPC server.

Request Body:

```json
{
  "jsonrpc": "2.0",
  "method": "sendfrom",
  "params": ["0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9","AKibPRzkoZpHnPkF6qvuW2Q4hG9gKBwGpR","AVECC4AcGXfDjm7cGmfGuxVRGTu6FxoQ7h",1],
  "id": 1
}
```

After sending the request, you will get the following response：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xec413354b76fc50a614419f76f131c873da0b17e0fd2dd9170c955b667de08ef",
        "size": 219,
        "type": "InvocationTransaction",
        "version": 1,
        "attributes": [
            {
                "usage": "Script",
                "data": "2b41aea9d405fef2e809e3c8085221ce944527a7"
            }
        ],
        "vin": [],
        "vout": [],
        "sys_fee": "0",
        "net_fee": "0",
        "scripts": [
            {
                "invocation": "401743a9c3fc91f131aea1c872d166e9c6fae577647884cd8511986041561c2b3e574c1708f662e570688d1a31db7cea281d43615b7fa64d7fa3babf0f6477c31e",
                "verification": "2103c532d9335f512e1198ede5c3d35524e6a3b4598f1eb335193b09c4cd52591927ac"
            }
        ],
        "script": "0400e1f505149393ee15ce6612484ab5be3bbc78c82af8dc0e07142b41aea9d405fef2e809e3c8085221ce944527a753c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166c72745294a433e52",
        "gas": "0"
    }
}
```

##### RPC Method: sendtoaddress

The key "params" includes an array of at least three parameters. 

`"params":[script hash, address, amount, fee(optional), change address(optional)]`

For example, to send 1 RPX to AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg , construct a JSON file as follows and send it to RPC server.

Request Body：

```json
{
    "jsonrpc":"2.0",
    "method":"sendtoaddress",
    "params":[
        "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
        "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg",
        "1",
        "0",
        "ARkJ8QcVdYL68WRvN3wj3TSvXX8CgmC73Z"
    ],
    "id":1
}
```

After sending the request, you will get the following response：

```json
{
    "jsonrpc":"2.0",
    "id":1,
    "result":{
        "txid":"0xc6d4bf7c62fb47e0b2a6e838c3a1ca297622a1b1df7ceb2d30fa4ef8b7870700",
        "size":219,
        "type":"InvocationTransaction",
        "version":1,
        "attributes":[
            {
                "usage":"Script",
                "data":"5305fbbd4bd5a5e3e859b452b7897157eb20144f"
            }
        ],
        "vin":[

        ],
        "vout":[

        ],
        "sys_fee":"0",
        "net_fee":"0",
        "scripts":[
            {
                "invocation":"4054fbfca678737ae164ebf0e476da0c8215782bc42b67ae08cf4d8a716eeef81fcc17641e7f63893c3e685fb7eb1fb8516161c5257af41630f4508dde3afa3a8c",
                "verification":"210331d1feacd79b53aeeeeb9de56018eadcd07948675a50258f9e64a1204b5d58d1ac"
            }
        ],
        "script":"0400e1f50514d710f6f3f0bad2996a09a56d454cfc116a881bfd145305fbbd4bd5a5e3e859b452b7897157eb20144f53c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166187b7883718089c8",
        "gas":"0"
    }
}
```

##### RPC Method: sendmany

The key "params" includes an array of at least one parameter:

`"params":[[], fee(optional), change address(optional)]`

For example, to send 15.5 RPX and 0.0001 GAS to AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg and the `change address` is also AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg, you can construct a JSON file as follows and send it to RPC server.

Request Body：

```json
{
    "jsonrpc":"2.0",
    "method":"sendmany",
    "params":[
        [
            {
                "asset":"0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
                "value":"15.5",
                "address":"AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            },
            {
                "asset":"0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value":"0.0001",
                "address":"AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            }
        ],"0.00001","AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
    ],
    "id":1
}
```

After sending the request, you will get the following response：

```json
{
    "jsonrpc": "2.0",
    "id": 1,
    "result": {
        "txid": "0xe1351c9c9f2205a801d1b04f0df2d65fb4b1692d7d3b06cf41e0712fd1b12c9c",
        "size": 373,
        "type": "InvocationTransaction",
        "version": 1,
        "attributes": [
            {
                "usage": "Script",
                "data": "6d64dc9e50af8e911247436b264c8f7d791ad58c"
            }
        ],
        "vin": [
            {
                "txid": "0x9f0a28a912527604ab4b7d5e8b8d1a9b57631fcbab460132811ae7b6ed1ccaff",
                "vout": 1
            }
        ],
        "vout": [
            {
                "n": 0,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.0001",
                "address": "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            },
            {
                "n": 1,
                "asset": "0x602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
                "value": "0.01359",
                "address": "AbP3FU3YcqBrWh72nc9deyQB99eazG9XUg"
            }
        ],
        "sys_fee": "0",
        "net_fee": "0.00001",
        "scripts": [
            {
                "invocation": "40644ab915419dbf855a52d5c75596e80b78c8e928cc0ce91ae6afc3b75a0c31ee54efe1836f9ec232f6c42dcb3ace0bfdc688e626944fa20970a76064975eade9",
                "verification": "2103d4b6fc2d116855f86a483d151182f68e88e6ddd13f3f1f3631e36300aac122bfac"
            }
        ],
        "script": "04801f635c14d710f6f3f0bad2996a09a56d454cfc116a881bfd146d64dc9e50af8e911247436b264c8f7d791ad58c53c1087472616e7366657267f91d6b7085db7c5aaf09f19eeec1ca3c0db2c6ecf166f871fb30fc859b77",
        "gas": "0"
    }
}
```

## See Also

[NEP-5 Token Standard](https://github.com/neo-project/proposals/blob/master/nep-5.mediawiki "NEP5")

[Data Transformation Examples](https://github.com/PeterLinX/NeoDataTransformation)