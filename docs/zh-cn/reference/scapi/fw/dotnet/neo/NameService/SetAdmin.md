# SetAdmin 方法 (string, UInt160)

给指定域名设置管理员账户。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 需要校验域名所有者以及管理员的签名。

## 语法

```c#
public static extern void SetAdmin(string name, UInt160 admin);
```

参数：

- name: 域名名称；
- admin: 管理员地址哈希

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static void SetAdmin(string name, UInt160 admin) => NameService.SetAdmin(name, admin);
}
```

合约部署后，可通过[SDK](../../../../../../develop/tool/sdk/transaction.md)构造交易调用该合约方法，

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
            KeyPair adminKey = Utility.GetKeyPair("Kz3aLCSTAh3xts8DhK9FyXAdTxqXETp86RR1WKDPHy7uPM8gcExD");
            UInt160 admin = Contract.CreateSignatureContract(adminKey.PublicKey).ScriptHash;

            Signer[] cosigners = new[] { new Signer { Scopes = WitnessScope.CustomContracts, Account = owner, AllowedContracts = new UInt160[] { NativeContract.NameService.Hash } },
            new Signer { Scopes = WitnessScope.CustomContracts, Account = admin, AllowedContracts = new UInt160[] { NativeContract.NameService.Hash } }};

            // The hash of the contract we deployed above
            UInt160 scriptHash = UInt160.Parse("0xdc0536fc35354158bf78367cb6a72160a96f024a");
            byte[] script = scriptHash.MakeScript("setAdmin", "test4.com", admin);

            TransactionManager txManager = await new TransactionManagerFactory(client, 5195086)
                .MakeTransactionAsync(script, cosigners).ConfigureAwait(false);
            Transaction tx = await txManager.AddSignature(ownerKey).AddSignature(adminKey).SignAsync().ConfigureAwait(false);

            await client.SendRawTransactionAsync(tx).ConfigureAwait(false);
            Console.WriteLine($"Transaction {tx.Hash.ToString()} is broadcasted!");

            WalletAPI neoAPI = new WalletAPI(client);
            await neoAPI.WaitTransactionAsync(tx)
               .ContinueWith(async (p) => Console.WriteLine($"Transaction vm state is {(await p).VMState}"));
        }
    }
}
```

运行该程序，响应正文为：`Transaction 0x10d1d01b1281078c7d714067c1123e14838bc2c0d9e70abe57581b82018b5d00 is broadcasted!`， 表明交易执行成功。

[返回上级](../NameService.md)