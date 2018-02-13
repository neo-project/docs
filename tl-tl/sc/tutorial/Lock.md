# Smart Contract Example - Lock (Lock Contract)

```c#
public class Lock : SmartContract
{
    public static bool Main(uint timestamp, byte[] pubkey, byte[] signature)
    {
        Header header = Blockchain.GetHeader(Blockchain.GetHeight());
        if (header.Timestamp < timestamp)
            return false;
        return VerifySignature(signature，pubkey);
    }
}
```

The contract implements a function that specifies a certain timestamp. Before the specified time stated, no one is allowed to withdraw any assets from the contract. Once the time stated is reached, the contract owners can then withdraw the assets.

The current time obtained by the contract is the time of the latest block in the blockchain (the error is about 15 seconds). For details, refer to [Blockchain class](../fw/dotnet/neo/Blockchain.md), [Header class](../fw/dotnet/neo/Header.md).

This contract can be deployed to the chain for others to call. If you wish to deploy a timelock contract locally, please refer to [Lock Contract](Lock2.md)
