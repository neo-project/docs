# SetRecord method (string, RecordType, string)

Sets the type of the specified domain name and the corresponding type data.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> Currently only `RecordType.A`、`RecordType.CNAME`、`RecordType.TXT` and `RecordType.AAAA` are suported；
>
> Needs to verify the signature of the admin or the owner of the domain.

## Syntax

```c#
public static extern void SetRecord(string name, RecordType type, string data);
```

parameters：

- name: domain name；
- type: record type；
- data: the corresponding data.

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static void SetRecord(string name, byte type, string data) => NameService.SetRecord(name, (RecordType)type, data);
}
```

After deploying the contract in cli，you can make a transaction by using [SDK](../../../../../../develop/tool/sdk/transaction.md) to query this method,

```c#
using Neo;
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.SmartContract;
using Neo.SmartContract.Native;
using Neo.VM;
using Neo.Wallets;
using System;
using System.Threading.Tasks;
using Utility = Neo.Network.RPC.Utility;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestNep17Transfer().GetAwaiter().GetResult();
            Console.Read();
        }

        private static async Task TestNep17Transfer()
        {
            RpcClient client = new RpcClient("http://127.0.0.1:10332");
            KeyPair ownerKey = Utility.GetKeyPair("KxrDM5H9TWiLtV48Ckxm15rp6XkxDHNryABGp1u67jRYpw3Y8z9G");
            UInt160 owner = Contract.CreateSignatureContract(ownerKey.PublicKey).ScriptHash;

            Signer[] cosigners = new[] { new Signer { Scopes = WitnessScope.CustomContracts, Account = owner, AllowedContracts = new UInt160[] { NativeContract.NameService.Hash } }};

            // The hash of the contract we deployed above
            UInt160 scriptHash = UInt160.Parse("0x79c8d00c2b340f10ae1f3843bf59755c4b4284c2");
            byte[] script = scriptHash.MakeScript("setRecord", "test4.com", 1, "127.0.0.1");

            TransactionManager txManager = await new TransactionManagerFactory(client, 5195086)
                .MakeTransactionAsync(script, cosigners).ConfigureAwait(false);
            Transaction tx = await txManager.AddSignature(ownerKey).SignAsync().ConfigureAwait(false);

            await client.SendRawTransactionAsync(tx).ConfigureAwait(false);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            WalletAPI neoAPI = new WalletAPI(client);
            await neoAPI.WaitTransactionAsync(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));
        }
    }
}
```
After running this program, you can get the response `Transaction 0x313019d1c7207a41d9be9fd7c9cd78e427b999c8dbe57036a090ee50c0c919ff is broadcasted!`， which means the success of the transaction.

[Back](../NameService.md)