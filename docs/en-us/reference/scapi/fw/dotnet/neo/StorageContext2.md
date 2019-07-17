# StorageContext Enumeration

Used to represent the enumeration of the private store storage context.

> [!Caution]
> Note: deprecated in version 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public enum StorageContext: byte
```

## Enumeration

| | Name | Description |
| ---------------------------------------- | ---------------------------------------- | ---------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [CallingContract](StorageContext/CallingContract.md) | Caller's Storage Context |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [Current](StorageContext/Current.md) | The storage context of the current contract |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC134134.jpeg) | [EntryContract](StorageContext/EntryContract.md) | Contract entry point (the starting point of the contract call chain) |
