# Contract Class

La classe rappresentante un contratto.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Sintassi

```c#
public class Contract
```

## Attributi

| | Nome | Descrizione |
| ---------------------------------------- | ---------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Script](Contract/Script.md) | Restituisce lo scripthash del contratto |

## Metodi

| | Nome | Descrizione |
| ---------------------------------------- | -------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) | `New` Pubblica il contratto    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) | `New` Migra / rinnova il contratto |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Destroy()](Contract/Destroy.md)         | `New` Distrugge il contratto   |

## Costruttore

L'oggetto del contratto può essere costruito mediante [Blockchain.GetContract(byte[])](Blockchain/GetContract.md).


[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) pubblica il contratto nella blockchain e restituisce un oggetto del contratto. 

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) rinnova il contratto e restituisce un oggetto del contratto. 
