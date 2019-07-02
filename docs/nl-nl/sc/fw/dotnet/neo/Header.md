# Header Class

Staat voor de datastructuur van de block header.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Header: IScriptContainer
```

## Eigenschappen

| | Naam   | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ConsensusData](Header/ConsensusData.md) | Geeft als `return` de consensusdata van een block |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Header/ConsensusData.md)          | Geeft als `return` de blockhash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [MerkleRoot](Header/MerkleRoot.md)       | Geeft als `return` de Merkle Tree root voor alle transacties in het block |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [NextConsensus](Header/NextConsensus.md) | Geeft als `return` de hash van de volgende Bookkeeper |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](Header/PrevHash.md)           | Geeft als `return` de hash van het vorige block |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Timestamp](Header/Timestamp.md)         | Geeft als `return` de tijdstempel van het block |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Version](Header/Version.md)             | Geeft als `return` de versie van het block  |

## Constructor

Het Header object wordt gemaakt door [Blockchain.GetHeader(byte[])](Blockchain/GetHeader.md) en [Blockchain.GetHeader(uint)](Blockchain/GetHeader2.md).
