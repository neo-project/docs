# 智能合约示例——Lock（锁仓合约）

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

该合约实现了一个这样的功能：指定一个时间戳（timestamp），当区块链系统的时间到达该指定的时间之前，任何人也不能从该合约中将资金取出，当区块链系统的时间过了指定的时间后，合约持有者可以将资金取出。

代码中通过区块链中最新区块的时间来获得当前时间（误差大约在15秒以内）。详情可参考 [Blockchain类](../fw/dotnet/AntShares/Blockchain.md)，   [Header类](../fw/dotnet/AntShares/Header.md)。