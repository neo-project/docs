# Smart Contract Voorbeeld - Domeinen (Domain Name System)

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
Het contract implementeert een domeinnaamsysteem, waarbij de domeinnaam wijst naar data op de blockchain. Dit zijn niet domeinnamen op het internet. De code hierboven implementeert query's, registratie, het overzetten van en het verwijderen van domeinnamen.

The contract implements a domain name system, where the domain names points to data on the blockchain. It is not the real domain names on the Internet.

The code above implements querying, registration, transfer and deletion of domain names.

For details, refer to [Storage](../fw/dotnet/neo/Storage.md).
