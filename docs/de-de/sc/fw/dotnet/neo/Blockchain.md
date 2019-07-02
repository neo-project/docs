# Blockchain Klasse

Diese Klasse beschreibt mehrere Methoden um auf Blockchaindaten zuzugreifen.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Blockchain
```

## Methoden

| | Name | Description |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAccount(byte[])](Blockchain/GetAccount.md) | Gibt einen Account (Adresse) auf Basis des Hash des Contract Scripthash zurück. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAsset(byte[])](Blockchain/GetAsset.md) | Gibt ein Asset auf der Blockchain anhand einer Asset ID zurück.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(byte[])](Blockchain/GetBlock.md) | Gibt einen Block auf der Blockchain anhand eines Block Hash zurück.      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(uint)](Blockchain/GetBlock2.md) | Gibt ein Block auf der Blockchain anhand der Block Height zurück.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetContract(byte[])](Blockchain/GetContract.md) | Gibt die Contract Contents auf Basis des Contract Scripthash zurück.   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(byte[])](Blockchain/GetHeader.md) | Gibt den Block Header auf Basis des Block Hash zurück.     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(uint)](Blockchain/GetHeader2.md) | Gibt einen Block Header anhand der Block Height zurück.         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeight()](Blockchain/GetHeight.md)   | Gibt die derzeitige Block Height auf der Blockchain zurück.             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(byte[])](Blockchain/GetTransaction.md) | Gibt eine Transaktion auf Basis der Transaction ID zurück.       |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetValidators()](Blockchain/GetValidators.md) | Gibt die Public Keys auf Basis des Validators zurück.       |

## Ersteller

Die Blockchainklasse ist eine statische Klasse und benötigt keinen Ersteller.
