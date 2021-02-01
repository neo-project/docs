# Register 方法 (string, UInt160)

注册新域名。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
> 只能注册二级域名；
> 需要先注册相应的根域名；
> 需要校验域名所属者的签名。

## 语法

```c#
public static extern bool Register(string name, UInt160 owner);
```

参数：

- name: 域名名称；
- owner: 域名所属者账户地址；

## 示例

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

运行该程序，响应正文为：`Transaction 0xf3cfdda662afe98696171893b9f03855bf66e6e85a67cc93936f51f099a4ace0 is broadcasted!`， 表明交易执行成功。

[返回上级](../NameService.md)