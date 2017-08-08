# 스마트 계약 예제 - dos (domain name system)

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




계약(Contract)에는 도메인 네임 전송 시스템(Domain Name Transfer System)이 추가되는데, 여기서 도메인 네임은
해당 블럭체인 시스템내에서의 이름이지 인터넷상의 실제 도메인 네임은 아닙니다, 

위의 코드는 도메인 네임의 조회(Query), 등록(Registration), 전송(Transfer) 그리고 삭제를 가능하게 합니다 

상세 내용은 다음을 참조하길 바랍니다.

[Storage Class](../fw/dotnet/neo/Storage.md).
