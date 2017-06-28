# Blockchain class

This class provides a set of methods for accessing blockchain data.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static class Blockchain
```

## method

| | Name | description |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
[CreateAsset (byte, string, long, byte, byte[], byte[], byte[], [byte] )](Blockchain/CreateAsset.md) | `new` Register an asset
|[][](Https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [CreateContract (byte[], byte[], byte, bool, string, string, string , String)](Blockchain/CreateContract.md) | `new` | publish smart contract
[GetAccount (byte[])](Blockchain/GetAccount.md) | According to the hash of the contract script To get an account (address)
[GetAsset (byte[])](Blockchain/GetAsset.md) | Find assets based on asset ID | |[][][](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg)
[GetBlock (byte[])](Blockchain/GetBlock.md) | through the block hash, find Block
[!GetBlock (uint)](Blockchain/GetBlock2.md) | Find the block by block height |
(Gethract (byte[])](Blockchain/GetContract.md) | `new` through contract To obtain the contents of the contract
(Getheader (byte[])](Blockchain/GetHeader.md) | through the block hash, find Block head
(Getheader (uint)](Blockchain/GetHeader2.md) | Find the block header by the block height. |[][](Https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | |
(Getheight ()](Blockchain/GetHeight.md) | Get the current block height |
[GetTransaction (byte[])](Blockchain/GetTransaction.md) | Find Transactions by Transaction ID | |[][][](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg)
|[][](Https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetValidators ()](Blockchain/GetValidators.md) | `new` Get the public key of the Consensus person |
[RegisterValidator (byte[])](Blockchain/RegisterValidator.md) | `new` Sign up for a consensus [RegisterValidator (byte[])] People

# Construction method

The BlockChain class is a static class and does not require a constructor.
