# 智能合约示例——Domain（域名系统）

```c#
public class Domain : FunctionCode
{
    public static object Main(string operation, params object[] args)
    {
        switch (operation)
        {
            case "query":
                return Query((string)args[0]);
            case "register":
                return Register((string)args[0], (byte[])args[1], (byte[])args[2]);
            case "transfer":
                return Transfer((string)args[0], (byte[])args[1], (byte[])args[2], (byte[])args[2]);
            case "delete":
                return Delete((string)args[0], (byte[])args[1]);
            default:
                return false;
        }
    }

    private static byte[] Query(string domain)
    {
        return Storage.Get(Storage.CurrentContext, domain);
    }

    private static bool Register(string domain, byte[] owner, byte[] signature)
    {
        if (!VerifySignature(owner, signature)) return false;
        byte[] value = Storage.Get(Storage.CurrentContext, domain);
        if (value != null) return false;
        Storage.Put(Storage.CurrentContext, domain, owner);
        return true;
    }

    private static bool Transfer(string domain, byte[] signature_from, byte[] to, byte[] signature_to)
    {
        if (!VerifySignature(to, signature_to)) return false;
        byte[] from = Storage.Get(Storage.CurrentContext, domain);
        if (from == null) return false;
        if (!VerifySignature(from, signature_from)) return false;
        Storage.Put(Storage.CurrentContext, domain, to);
        return true;
    }

    private static bool Delete(string domain, byte[] signature)
    {
        byte[] owner = Storage.Get(Storage.CurrentContext, domain);
        if (owner == null) return false;
        if (!VerifySignature(owner, signature)) return false;
        Storage.Delete(Storage.CurrentContext, domain);
        return true;
    }
}
```

该合约实现了一个域名转让系统，这里的域名是区块链系统中的数据，并非 Internet 上的真实域名。

上面的代码实现了对域名的查询、注册、转让、删除。

详情可参考 [Storage类](../fw/dotnet/AntShares/Storage.md)。