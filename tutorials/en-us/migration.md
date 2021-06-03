# Migration from Neo Legacy to Neo N3

This document is intended to guide developers in migrating the global assets NEO and GAS on the Neo Legacy chain to the Neo N3 chain via the cross-chain technology.

## Exchange to nNEO / cGAS

Since it is not possible to transfer the UTXO asset NEO /GAS into smart contracts, we need to exchange them to nNEO / cGAS which are NEP-5 contract mapping assets, allowing the invocation of funds across chains, precision calculation of assets, as well as interaction with smart contracts. 

nNEO and cGAS are open source and can be found in GitHub: [nNEO ](https://github.com/neo-ngd/CNEO-Contract "nNEO") and [cGAS](https://github.com/neo-ngd/CGAS-Contract "cGAS").

> [!Note]
>
> Because the minimum unit of NEO is 1 and tokens cannot be subdivided, you can only migrate an integer number of NEOs, e.g. if there are 10.5 NEOs in the wallet, only 10 NEOs can be migrated to N3. 

nNEO and cGAS can be converted one to one by the global assets NEO and GAS through the `mintTokens`  function. See the example codes as below.

JS example：

```js
const { default: Neon, api, wallet, tx, u, sc, rpc, core } = require("@cityofzion/neon-js");

let outPutObj1 = {
    "assetId": "602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
    "value": "1022",
    "scriptHash": "f0e522806601209e9599d5e9b4dfc59773c4a882"
}

let outPutObj2 = {
    "assetId": "602c79718b16e442de58778e148d0b1084e3b2dffd5de6b7b16cee7969282de7",
    "value": "10",
    "scriptHash": "74f2dc36a68fdc4682034178eb2220729231db76"
}

let inputObj = {
    "prevHash": "f9452b21e6c079e06be717c9eded71a7d947e83f54a962e5277c7c8d56fff86c",
    "prevIndex": 1
}

const props2 = {
    scriptHash: "74f2dc36a68fdc4682034178eb2220729231db76",
    operation: "mintTokens",
    args: []
};
const script2 = Neon.default.create.script(props2);
let invokeTx = new Neon.tx.InvocationTransaction({ script: script2 })
invokeTx.addOutput(new Neon.tx.TransactionOutput(outPutObj1));
invokeTx.addOutput(new Neon.tx.TransactionOutput(outPutObj2));
invokeTx.inputs[0] = new Neon.tx.TransactionInput(inputObj);

invokeTx.sign("Your private key")

const rpcClient = new Neon.rpc.RPCClient("http://seed10.ngd.network:20332");

rpcClient.sendRawTransaction(invokeTx).then((response) => {
    console.log(response);
}).catch((err) => {
    console.log(err);
});

```

C# example：

```c#
//UTXO input
            var inputs = new List<CoinReference>
            {
                new CoinReference()
                {
                    PrevHash = neoList[0].txid,
                    PrevIndex = (ushort)neoList[0].n
                }
            }.ToArray();

            long amount = 100_2345_6789;
            //UTXO output
            var outputs = new List<TransactionOutput>
            {
                new TransactionOutput()
                {
                    AssetId = Blockchain.UtilityToken.Hash,
                    ScriptHash = CGAS,
                    Value = new Fixed8(amount)//Amount
                },
                new TransactionOutput()
                {
                    AssetId = Blockchain.UtilityToken.Hash,
                    ScriptHash = User.ScriptHash,
                    Value = Fixed8.FromDecimal(neoList[0].value) -  new Fixed8(amount)//Amount
                }
            }.ToArray();


            //Construct a transaction
            Transaction tx = null;
            using (ScriptBuilder sb = new ScriptBuilder())
            {
                //nNEO
                sb.EmitAppCall(UInt160.Parse("0xf46719e2d16bf50cddcef9d4bbfece901f73cbb6"), "mintTokens");     //The contract function mintTokens
                //cGAS
                //sb.EmitAppCall(UInt160.Parse("0x74f2dc36a68fdc4682034178eb2220729231db76"), "mintTokens");
                tx = new InvocationTransaction
                {
                    Version = 1,
                    Script = sb.ToArray(),
                    Outputs = outputs,
                    Inputs = inputs,
                    Attributes = new TransactionAttribute[0],
                    Witnesses = new Witness[0]
                };
            }

            //User signature
            tx.Attributes = Helper.GetAttribute(User.ScriptHash);
            var signature = tx.Sign(keyPair);
            tx.Witnesses = Helper.GetWitness(signature, keyPair.PublicKey);

            //Send the transaction
            byte[] data = tx.ToArray();
			string rawdata = data.ToHexString();
            string result = Helper.InvokeRpc(url, "sendrawtransaction", rawdata);
```

Java example：

```java
    Neow3j neow3j = Neow3j.build(new HttpService("http://seed1.ngd.network:20332")); // Neo2 test net
    Account account = Account.fromWIF("your wif string").build();
    // nNeo contract hash on Neo2 testnet
    ScriptHash nNeoHash = new ScriptHash("0x17da3881ab2d050fea414c80b3fa8324d756f60e"); 
    account.updateAssetBalances(neow3j);
    ContractInvocation invoc = new ContractInvocation.Builder(neow3j)
            .contractScriptHash(nNeoHash)
            .function("mintTokens")
            .account(account)
            .output(new RawTransactionOutput(NEOAsset.HASH_ID, lockValue, nNeoHash.toAddress()))
            .build()
            .sign()
            .invoke();
    String txHash = invoc.getTransaction().getTxId();
```

## Cross-chain architecture

In virtue of the cross-chain technology which is of the capability transferring data from one chain to another, our migration adopts the following architecture:

![](migration.png)

The components in the figure above are defined as follows:

- **Neo Legacy**: neo 2.x side chain, from which the assets are migrated out.
- **Neo N3**: neo 3.0 side chain, to which the assets are transfered.
- [**Poly cross chain**](https://github.com/polynetwork/docs/blob/master/poly/README.md): The Poly cross chain plays an important role in the overall architecture, where each node is run by different individuals or organizations with their own governance model and trust mechanism. It is responsible for connecting side chains together and transferring cross-chain information.
- **Relayer**: Each sidechain has its own Relayer, which is responsible for carrying cross-chain information such as transactions to and from Poly to the sidechain, and they gain rewards in the process.
- **Cross Chain Management Contract**: The role of Cross Chain Management Contract (CCMC for short) includes but is not limited to processing cross-chain requests, verifying cross-chain transactions, sending cross-chain events, etc.
- **Proxy contract**: Used to lock and unlock assets. The assets locked/unlocked on both sidechains must be of the same type and number.
- **User**: Generally refers to all objects involved in a migration process, including but not limited to exchanges, individuals, wallets, etc. The user must invoke a proxy contract to initiate a cross-chain transaction.

## Migration process flow

Before starting the migration, you need to register two side chains and two Relayers and bind the corresponding assets on both side chains.  As illustrated in the above architecture figure, an usual migration process flow is as follows:

**Neo Legacy side:**

1. The user invokes the proxy contract  `lock`  method on Neo Legacy.

   > [!Note]
   >
   > - For the C# invocation code example, refer to [C# demo](https://github.com/neo-ngd/CrossChainExample/blob/main/CrossChainDemo/Demo.cs).
   > - For the Java invocation code example, refer to [Java demo](https://github.com/neo-ngd/CrossChainExample/tree/main/CrossChainDemo_Java/src/main/java/crosschain/demo).

2. The proxy contract locks the assets to migrate out in its address.

3. The proxy contract invokes the `crossChain` method of CCMC.

4. CCMC generates `Request ID` and saves it.

5. CCMC sends out a cross-chain event.

6. Consensus nodes generate state root and proof of the cross-chain transaction.

7. The Relayer scans sidechain blocks one by one and captures the cross-chain event.

8. The Relayer constructs a transaction to send the state root and proof to Poly.

**Poly side：**

9. CCMC uses the handler of the Neo Legacy chain to verify the proof via the `from chain ID` in the cross-chain parameter
10. Poly constructs the new state root and proof for the transaction mentioned in step 8, and sends a cross-chain event.

**Neo N3 side：**

11. The Relayer scans Poly blocks one by one and captures the cross-chain event.
12. Relayer invokes the  `verifyAndExecuteTx` method of CCMC to construct a transaction, and sends the block header containing the state root and proof to the sidechain. 
13. CCMC verifies the proof in the Poly transaction
14. CCMC invokes the  `UnlockAsset` method of Neo N3 proxy contract.
15. The proxy contract unlocks the corresponding assets and release to the user's Neo N3 address. 

## Transfer verification

After completing the cross-chain transfer of assets, the exchange needs to check if the assets have arrived by doing the following:

1. Get details for each block using the [getblock](https://docs.neo.org/docs/zh-cn/reference/rpc/latest-version/api/getblock.html) API, including details of all transactions in the block.

3. Invoke the [getapplicationlog](https://docs.neo.org/docs/zh-cn/reference/rpc/latest-version/api/getapplicationlog.html) API to get the details of each transaction and analyze the transaction content to check the user deposit.

### Invoking getapplicationlog

After correctly installing the  [ApplicationLogs plugin](https://github.com/neo-project/neo-modules/releases/download/v3.0.0-rc2/ApplicationLogs.zip) and starting the neo-cli node, you can find a folder "ApplicationLogs" is generated under the neo-cli root path. The complete contract log is recorded in this directory, and each NEP-17 transaction is recorded in a leveldb file.

Here is an example of the API invoking result.

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
> The failed NEP-17 transaction can also be recorded in the blockchain, so you need to determine whether the vm status parameter "vmstate" is correct (HALT).  If it contains "FAULT", that means the execution is failed and the transaction is invalid. 

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

