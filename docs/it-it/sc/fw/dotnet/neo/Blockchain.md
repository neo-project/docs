# Classe Blockchain 

Questa classe fornisce un set di metodi per accedere ai dati della blockchain.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public static class Blockchain
```

## Metodi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------------------- | -------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAccount(byte[])](Blockchain/GetAccount.md) | Restituisce un account (indirizzo) dallo scripthash fornito|
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetAsset(byte[])](Blockchain/GetAsset.md) | Restituisce un asset dall'asset ID fornito         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(byte[])](Blockchain/GetBlock.md) | Restituisce un blocco dall'hash del blocco fornito      |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetBlock(uint)](Blockchain/GetBlock2.md) | Restituisce un blocco dall'altezza del blocco fornita          |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetContract(byte[])](Blockchain/GetContract.md) | `New` Restituisce il contenuto del contratto dall'hash del contratto fornito   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(byte[])](Blockchain/GetHeader.md) | Restituisce l'intestazione di un blocco dall'hash del blocco fornito     |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeader(uint)](Blockchain/GetHeader2.md) | Restituisce l'intestazione di un blocco dall'altezza del blocco fornita         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetHeight()](Blockchain/GetHeight.md)   | Restituisce l'altezza del blocco corrente             |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetTransaction(byte[])](Blockchain/GetTransaction.md) | Restituisce una transazione dall'ID della transazione fornita         |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [GetValidators()](Blockchain/GetValidators.md) | `New` Restituisce la chiave pubblica dei validatori       |

## Costruttore

La classe BlockChain é una classe statica che non richiede un costruttore.
