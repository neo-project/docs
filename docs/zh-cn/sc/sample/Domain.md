# 智能合约示例——Domain（域名系统）

```c#
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System.ComponentModel;

namespace Domain
{
    [Features(ContractFeatures.HasStorage)]
    public class Contract1 : SmartContract
    {
        public static object Main(string method, params object[] args)
        {
            return method switch
            {
                "query" => Query((string)args[0]),
                "register" => Register((string)args[0], (byte[])args[1]),
                "transfer" => Transfer((string)args[0], (byte[])args[1]),
                "delete" => Delete((string)args[0]),
                _ => false,
            };
        }

        [DisplayName("query")]
        private static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }

        [DisplayName("register")]
        private static bool Register(string domain, byte[] owner)
        {
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            return true;
        }

        [DisplayName("transfer")]
        private static bool Transfer(string domain, byte[] to)
        {
            if (!Runtime.CheckWitness(to)) return false;
            byte[] from = Storage.Get(Storage.CurrentContext, domain);
            if (from == null) return false;
            if (!Runtime.CheckWitness(from)) return false;
            Storage.Put(Storage.CurrentContext, domain, to);
            return true;
        }

        [DisplayName("delete")]
        private static bool Delete(string domain)
        {
            byte[] owner = Storage.Get(Storage.CurrentContext, domain);
            if (owner == null) return false;
            if (!Runtime.CheckWitness(owner)) return false;
            Storage.Delete(Storage.CurrentContext, domain);
            return true;
        }
    }
}
```

该合约实现了一个域名转让系统，这里的域名是区块链系统中的数据，并非 Internet 上的真实域名。

上面的代码实现了对域名的查询、注册、转让、删除。

> [!Note]
>
> 请注意 Main 方法中的 switch。在智能合约中，switch 语句中 case 的数量不能超过 7 个，否则调用时会报错（可编译通过）。如果 case 数量超过 7 个，建议改为 if 语句。