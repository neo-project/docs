# Smart Contract Example - Domain (Domain Name System)

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

The contract implements a domain name system, where the domain names points to data on the blockchain. It is not the real domain names on the Internet.

The code above implements querying, registration, transfer and deletion of domain names.

> [!Note]
>
> Note the method switch in Main. In a smart contract the number of cases in the switch statement must not be more than 7, otherwise an error will occur when you invoke the contract, even if you can compile it without a issue. If the case number exceeds 7  it is recommended to change to an if statement.

