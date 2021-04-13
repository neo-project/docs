# Transfer method (UInt160, string)

Transfers the ownership of the domain name.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

> [!Note]
>
> Needs to verify the signature of the current owner of the domain name.

## Syntax

```c#
public static extern bool Transfer(UInt160 to, string name);
```

parameters：

- to: the hash of the address to which the domain is transferred;
- name: the domain name to be transferred.

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static bool Transfer(UInt160 to, string name) { return NameService.Transfer(to, name); }
}
```

After deploying the contract in cli，you can make a transaction by using [SDK](../../../../../../develop/tool/sdk/transaction.md) to query this method,

```c#
using Neo;
using Neo.Network.P2P.Payloads;
using Neo.Network.RPC;
using Neo.SmartContract;
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
            // sender should be the owner of the name
            KeyPair sendKey = Utility.GetKeyPair("KxrDM5H9TWiLtV48Ckxm15rp6XkxDHNryABGp1u67jRYpw3Y8z9G");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            Signer[] cosigners = new[] { new Signer { Scopes = WitnessScope.CustomContracts, Account = sender, AllowedContracts = new UInt160[] { NativeContract.NameService.Hash } } };

            UInt160 to = Utility.GetScriptHash("NQHVnsfmPY3ZWSFmHwzggALjJLUhQrXhY3");

            // The hash of the contract we deployed above
            UInt160 scriptHash = UInt160.Parse("0x61317ad347aa5b5bc55de7ff46aca79ff94e9eaa");
            byte[] script = scriptHash.MakeScript("transfer", to, "test.com");

            TransactionManager txManager = await new TransactionManagerFactory(client, 5195086)
                .MakeTransactionAsync(script, cosigners).ConfigureAwait(false);
            Transaction tx = await txManager.AddSignature(sendKey).SignAsync().ConfigureAwait(false);

            await client.SendRawTransactionAsync(tx).ConfigureAwait(false);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            WalletAPI neoAPI = new WalletAPI(client);
            await neoAPI.WaitTransactionAsync(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));
        }
    }
}
```

After running this program, you can get the response `Transaction 0x0ca86bea2250c32b7ec755a66ee60eee0b87274b9be14089aec934e31c99f481 is broadcasted!`， which means the success of the transaction.

[Back](../NameService.md)