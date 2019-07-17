# Contractklasse

Die Klasse repräsentiert einen Contract.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class Contract
```

## Attribute

| | Name | Beschreibung|
| ---------------------------------------- | ---------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Script](Contract/Script.md) | Gibt den Scripthash eines Contracts zurück |

## Methoden

| | Name | Beschreibung |
| ---------------------------------------- | -------------------------------- | ------ |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) | Das Ausführen dieser Methode veröffentlicht einen neuen Contract.    |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Migrate(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Migrate.md) | Migriert/erneuert einen Smart Contracts |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Destroy()](Contract/Destroy.md)         | Löscht den Contract.    |

## Ersteller

Dass Contractobjekt kann erstellt werden durch [Blockchain.GetContract(byte[])](Blockchain/GetContract.md).

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) veröffentlicht den Contract auf der Blockchain und gibt Contractobjekt zurück.

[Contract.Create(byte[], byte[], byte, bool, string, string, string, string, string)](Contract/Create.md) erneuert den Contract und gibt das Contractobjekt zurück.
