# DeleteRecord 方法 (string, RecordType)

删除指定域名的类型信息。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
>
> 需要验证域名的所属者owner或管理员admin的签名。

## 语法

```c#
public static extern void DeleteRecord(string name, RecordType type);
```

参数：

- name: 域名名称；
- type: 域名类型

## 示例

```c#
using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract;

public class Demo : SmartContract
{
    public static void DeleteRecord(string name, byte type) => NameService.DeleteRecord(name, (RecordType)type);
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

            Signer[] cosigners = new[] { new Signer { Scopes = WitnessScope.CustomContracts, Account = owner, AllowedContracts = new UInt160[] { NativeContract.NameService.Hash } }};

            // The hash of the contract we deployed above
            UInt160 scriptHash = UInt160.Parse("0x7cc5d85855265ab974885d8852e7569208d3ca05");
            byte[] script = scriptHash.MakeScript("deleteRecord", "test4.com", 1);

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

运行该程序，响应正文为：`Transaction 0xf66d7382949bf1700da3b86c59e1392b2d9003425d33998f68e76ccd7dfb1bfa is broadcasted!`， 表明交易执行成功。

[返回上级](../NameService.md)