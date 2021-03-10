# Transfer 方法 (UInt160, string)

转移指定二级域名的所属权。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 需要校验域名当前所属者的签名。

## 语法

```c#
public static extern bool Transfer(UInt160 to, string name);
```

参数：

- to: 域名要转到的目标账户地址哈希；
- name: 要转移所属权的域名

## 示例

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

合约部署后，可通过[SDK](../../../../../../develop/tool/sdk/transaction.md)构造交易调用该合约方法，

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

运行该程序，响应正文为：`Transaction 0x0ca86bea2250c32b7ec755a66ee60eee0b87274b9be14089aec934e31c99f481 is broadcasted!`， 表明交易执行成功。

[返回上级](../NameService.md)