# StorageContext Enumeration

Wird benutzt um die Enumeration des Private Store Storage Context darzustellen.

> [!Achtung]
> Anmerkung: Veraltet in der Version 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum StorageContext: byte
```

## Enumeration

| | Name | Beschreibung |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [CallingContract](StorageContext/CallingContract.md) | Caller's Storage Context. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [Current](StorageContext/Current.md) | Der Storage Kontext des aktuellen Contract. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [EntryContract](StorageContext/EntryContract.md) | Der Storage Kontext des Contract Entry Points (Der Startpunkt der Contract Invocation Chain). |
