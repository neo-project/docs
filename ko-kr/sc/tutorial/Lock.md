#  스마트 계약 예제 - Lock (lock)

```c#
public class Lock : FunctionCode
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (timestamp > header.Timestamp) return false;
        return VerifySignature(pubkey, signature);
    }
}
```

계약(Contract)에는 해당 계약으로부터 블록체인 시스템이 특정시간에 이를 때가지 타임스템프를 불러낼 수 없게 하는 함수가 포함되는데, 
블록체인 시스템이 지정된 시간이 지난 다음에 계약 소유자는 자금을 인출할 수 있습니다. 

현재 시간은 블럭체인 시스템 내(오차는 대략 15초)에서 가장 최근 블럭에 의한 코드에서 가져옵니다. 
상세내용은 다음을 참고하세요. 
[Blockchain class](../fw/dotnet/neo/Blockchain.md), [Header class](../fw/dotnet/neo/Header.md)
