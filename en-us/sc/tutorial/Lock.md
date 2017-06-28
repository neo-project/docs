# Smart contract example - Lock (lock)

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

The contract implements a function that specifies a timestamp that can not be fetched from the contract until the time of the blockchain system reaches the specified time, and when the blockchain system time After the specified time, the contract holder can take the funds out.

The current time is obtained in the code by the time of the latest block in the blockchain (the error is about 15 seconds). For details, refer to [Blockchain class](../fw/dotnet/AntShares/Blockchain.md), [Header class](../fw/dotnet/AntShares/Header.md).
