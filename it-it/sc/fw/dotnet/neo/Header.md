# Classe Header

Rappresenta la struttura dati dell'intestazione di un blocco.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class Header: IScriptContainer
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | -------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [ConsensusData](Header/ConsensusData.md) | Restituisce i dati di consenso per il blocco (generati dal nodo di consenso) |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Hash](Header/ConsensusData.md)          | Restituisce l'hash del blocco |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [MerkleRoot](Header/MerkleRoot.md)       | Restituisce la radice Merkle Tree per tutte la transazioni nel blocco |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [NextConsensus](Header/NextConsensus.md) | Restituisce l'hash del prossimo bookeeper |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [PrevHash](Header/PrevHash.md)           | Restituisce l'hash del blocco precedente |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Timestamp](Header/Timestamp.md)         | Restituisce il timestamp del blocco |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Version](Header/Version.md)             | Restituisce la versione del blocco |

## Costruttore

L'oggetto Header é costruito tramite [Blockchain.GetHeader(byte[])](Blockchain/GetHeader.md).

L'oggetto Header é costruito tramite [Blockchain.GetHeader(uint)](Blockchain/GetHeader2.md).
