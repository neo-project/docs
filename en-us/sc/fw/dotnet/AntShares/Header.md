# Header class

Used to represent the data structure of the block header.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public class Header: IScriptContainer
```

## Attributes

| | Name | description |
| ---------------------------------------- | -------- -------------------------------- | ----------------- --------- |
| [ConsensusData](Header/ConsensusData.md) | Get the consensus data for the block (Consensus node generation). [ConsensusData](Header/ConsensusData.md) | Get the consensus data for this block (Consensus node generation (https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | Pseudo - random number
(Hash) (Header/ConsensusData.md) | Get the hash of the block | | [Hash](Header/ConsensusData.md) | Get the hash of the block |
(MerkleRoot) (Header/MerkleRoot.md) | Get Merkle Tree for all transactions in this block Root
[NextConsensus](Header/NextConsensus.md) | Get the hash value of the next billing contract |
[PrevHash](Header/PrevHash.md) | Get the hash of the previous block | |[][](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash]
[Timestamp](Header/Timestamp.md) | Get the timestamp of the block | |[]()
! [Version](Header/Version.md) | Get the block version number | |[](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Version]

## Construction method

The Header object is constructed by [Blockchain.GetHeader (byte[])](Blockchain/GetHeader.md).

The Header object is constructed by [Blockchain.GetHeader (uint)](Blockchain/GetHeader2.md).
