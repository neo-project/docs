# SetRecord 方法 (string, RecordType, string)

设置指定域名的类型以及相应的类型数据。

命名空间：[Neo.SmartContract.Framework.Services.Neo](../../neo.md)

程序集：Neo.SmartContract.Framework

> [!Note]
> 域名类型只能是`RecordType.A`、`RecordType.CNAME`、`RecordType.TXT`和`RecordType.AAAA`四种；
> 需要验证域名的所属者owner或管理员admin的签名。

## 语法

```c#
public static extern void SetRecord(string name, RecordType type, string data);
```

参数：

- name: 域名名称；
- type: 域名类型；
- data: 指定类型下对应的数据内容

## 示例

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

运行该程序，响应正文为：`Transaction 0x313019d1c7207a41d9be9fd7c9cd78e427b999c8dbe57036a090ee50c0c919ff is broadcasted!`， 表明交易执行成功。

[返回上级](../NameService.md)