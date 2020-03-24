# Invoking CGAS

In all of CGAS's code, the code invoking CGAS is of high difficulty, even as much as that of Refund.

First, the process of invoking a smart contract is to construct an InvocationTransaction. The data structure of an InvocationTransaction is as follows:

| Byte number | Field       | Type      | Description                           |
| ------ | ---------- | --------- | ------------------------------ |
| 1      | Type       | byte      | Transaction type                       |
| 1      | Version    | byte      | Transaction version, now is 0 or 1    |
| ?      | -          | -         | Specific transaction data                 |
| ?*?    | Attributes | tx_attr[] | Additional features in the transaction         |
| 34*?   | Inputs     | tx_in[]   | Inputs                           |
| 60 * ? | Outputs    | tx_out[]  | outputs                           |
| ?*?    | Witnesses  | Witness[] | Used to verify the script list of the transaction       |
| ?*?    | Script     | byte[]    | Invocation scripts of the smart contract in the transaction |

Currently, CGAS can only construct InvocationTransaction with the SDK. The clients such as neo-gui and neo-cli cannot support CGAS completely. (Only methods in NEP-5 are supported, and the methods such as mintTokens and refund of CGAS are not supported.)

You can refer to the project [CGAS UnitTests](https://github.com/neo-ngd/CGAS-Contract/blob/master/UnitTests) for specific project creation, SDK reference and transaction construction.

Take MintTokens as an example, next let’s analysis the code to construct a transaction.

```c#
public static void MintTokens()
{
    var inputs = new List<CoinReference> {
        new CoinReference(){
            PrevHash = new UInt256("0xf5088ce508d86197c991ff0ef7651ddf01f3e555f257039c972082250e899210".Remove(0, 2).HexToBytes().Reverse().ToArray()),
            PrevIndex = 0
        }
    }.ToArray();

    var outputs = new List<TransactionOutput>{ new TransactionOutput()
    {
        AssetId = Blockchain.UtilityToken.Hash, //Asset Id, this is GAS
        ScriptHash = ScriptHash, //CGAS address
        Value = new Fixed8((long)(1 * (long)Math.Pow(10, 8)))
    }}.ToArray();

    Transaction tx = null;

    using (ScriptBuilder sb = new ScriptBuilder())
    {
        sb.EmitAppCall(ScriptHash, "mintTokens");
        sb.Emit(OpCode.THROWIFNOT);

        byte[] nonce = new byte[8];
        Random rand = new Random();
        rand.NextBytes(nonce);
        sb.Emit(OpCode.RET, nonce);
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
    var sign = new SignDelegate(SignWithWallet);
    sign.Invoke(tx, "1.json", "11111111");
    Verify(tx);
}
```

The first is to construct the transaction inputs and outputs. The transaction inputs are from own address, and the output is the address of the CGAS. The transaction inputs are not reusable, and the unspent transaction inputs are used for each test.

The transaction inputs contain the following two fields: PrevHash and PrevIndex, which respectively represent the transaction ID and index of the transaction output used.

To be clear, in the UTXO model, all transaction inputs must be the transaction outputs of the previous transaction, thus forming a completed chain. A transaction output can be represented by a "composite primary key", that is, the transaction ID and the index of the transaction output. This is the field of the transaction inputs, which refers to the "primary key" of a transaction output, rather than the complete data of the transaction output.

Then start to construct an InvocationTransaction, the most important of which is the Script field. Here it is created by the ScriptBuilder class in the SDK.

After the transaction is constructed, the transaction is signed and the signed content is written in the Witness field of the transaction.

Finally, the transaction verification is performed locally, including:

1. whether the format of the transaction is correct.

2. Whether the size of the transaction exceeds the limit.

3. Whether two identical UTXOs are used in a transaction.

4. Whether the transaction in the memory pool includes the UTXO used by the transaction.

5. Whether there is double spend (whether the transaction in the blockchain includes UTXO used in the transaction).

6. Whether the assets in the transaction are expired, whether the transfer precision meets the requirements, and whether the assets exist.

7. Whether the fees are valid.

8. Whether the transaction attributes are valid.

9. Whether the verification scripts are executed successfully (that is, executing Trigger.Verify).

It is recommended that developers should debug locally by steps when constructing a transaction to find problems.


## Previous Step
[Signature and verification](6_signature_and_verification.md)

