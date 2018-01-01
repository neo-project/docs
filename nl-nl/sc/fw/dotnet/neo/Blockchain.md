# Blockchain Class

Deze class geeft een set methods voor toegang tot blockchaindata.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static class Blockchain
```

## Methods

| | Naam | Omschrijving |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAccount(byte[])](Blockchain/GetAccount.md) | Geeft als `return` een account(-adres) a.d.h.v. een gegeven scripthash |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAsset(byte[])](Blockchain/GetAsset.md) | Geeft als `return` een asset a.d.h.v. een gegeven asset-ID         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(byte[])](Blockchain/GetBlock.md) | Geeft als `return` een block a.d.h.v. een blockhash      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(uint)](Blockchain/GetBlock2.md) | Geeft als `return` een block a.d.h.v. de gegeven blockhoogte          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetContract(byte[])](Blockchain/GetContract.md) | `Nieuw` Geeft als `return`  de inhoud van een contract a.d.h.v. de gegeven contract hash   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(byte[])](Blockchain/GetHeader.md) | Geeft als `return` een block header a.d.h.v. een gegeven blockhash     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(uint)](Blockchain/GetHeader2.md) | Geeft als `return` een block header a.d.h.v. de gegeven blockhoogte         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeight()](Blockchain/GetHeight.md)   | Geeft als `return` de huidige blockhoogte             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(byte[])](Blockchain/GetTransaction.md) | Geeft als `return` een transactie a.d.h.v. een gegeven transactie-ID         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetValidators()](Blockchain/GetValidators.md) | `Nieuw` Geeft als `return` de public keys van de validator nodes       |

## Constructor

De BlockChain class is statisch en heeft geen constructor nodig.
