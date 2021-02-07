# Register method (string, UInt160)

Registers a new domain.

Namespace：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly：Neo.SmartContract.Framework

> [!Note]
> Only supports to register a second domain name；
> Needs to register the corresponding top-level domain first；
> Needs to verify the signature of the domain owner.

## Syntax

```c#
public static extern bool Register(string name, UInt160 owner);
```

parameter：

- name: domain name；
- owner: the address of the domain owner.

## Example

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static bool Register(string name, UInt160 owner) => NameService.Register(name, owner);
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
            KeyPair sendKey = Utility.GetKeyPair("KxrDM5H9TWiLtV48Ckxm15rp6XkxDHNryABGp1u67jRYpw3Y8z9G");
            UInt160 sender = Contract.CreateSignatureContract(sendKey.PublicKey).ScriptHash;

            Signer[] cosigners = new[] { new Signer { Scopes = WitnessScope.CustomContracts, Account = sender, AllowedContracts = new UInt160[] { NativeContract.NameService.Hash } } };

            // The hash of the contract we deployed above
            UInt160 scriptHash = UInt160.Parse("0x2cf0f28aff41ddcb61c940397e097db3310881a5");
            byte[] script = scriptHash.MakeScript("register", "test3.com", sender);

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
After running this program, you can get the response `Transaction 0xf3cfdda662afe98696171893b9f03855bf66e6e85a67cc93936f51f099a4ace0 is broadcasted!`， which means the success of the transaction.

[Back](../NameService.md)