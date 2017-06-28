# Smart contract example - dos (domain name system)

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

The contract implements a domain name transfer system, where the domain name is the data in the blockchain system and is not the real domain name on the Internet.

The above code to achieve the domain name of the query, registration, transfer, delete.

For details, refer to [Storage Class](../fw/dotnet/AntShares/Storage.md).
