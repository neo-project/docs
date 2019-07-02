# Header Klasse

Repräsentiert die Datenstruktur des Block Headers.


Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Header: IScriptContainer
```

## Attribute

| | Name | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ConsensusData](Header/ConsensusData.md) | Gibt die Konsensdaten des Blockes zurück (Pseudozufalls Nummer generiert von dem Konsensknoten) |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Header/ConsensusData.md)          | Gibt den Hash des Blockes zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [MerkleRoot](Header/MerkleRoot.md)       | Gibt die Merkle Tree Root für alles Transaktionen einem Block aus. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [NextConsensus](Header/NextConsensus.md) | Gibt den Hashwert des nächsten Bookkeeper Contracts zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](Header/PrevHash.md)           | Gibt den Hash des vorhergehenden Blocks zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Timestamp](Header/Timestamp.md)         | Gibt den Zeitstempel des Blocks zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Version](Header/Version.md)             | Gibt die Versionsnummer des Blocks zurück.  |

## Ersteller

Das Headerobjekt wird erstellt von [Blockchain.GetHeader(byte[])](Blockchain/GetHeader.md).

Das Headerobjekt wird erstellt von [Blockchain.GetHeader(uint)](Blockchain/GetHeader2.md).
