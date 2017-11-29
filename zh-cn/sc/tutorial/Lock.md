# 智能合约示例——Lock（锁仓合约）

```c#
public class Lock : SmartContract
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (header.Timestamp < timestamp)
            return false;
        return VerifySignature(signature, pubkey);
    }
}
```

该合约实现了一个这样的功能：指定一个时间戳（timestamp），当区块链系统的时间到达该指定的时间之前，任何人也不能从该合约中将资金取出，当区块链系统的时间过了指定的时间后，合约持有者可以将资金取出。

代码中通过区块链中最新区块的时间来获得当前时间（误差大约在 15 秒以内）。详情可参考 [Blockchain 类](../fw/dotnet/neo/Blockchain.md)，   [Header 类](../fw/dotnet/neo/Header.md)。

该合约用于部署到区块链上供其它人调用，如果想在本地部署锁仓合约，请参考 [锁仓合约的部署](Lock2.md)。