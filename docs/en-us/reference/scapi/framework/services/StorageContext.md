# StorageContext Class

The class representing the storage context of the persistent store.

The smart contract can obtain its own storage context through Storage.CurrentContext and pass the context as an argument to other contracts(as a way of authorization), allowing other contracts to call the read/write methods for its persistent storage.

Namespace：[Neo.SmartContract.Framework.Services](../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public class StorageContext
```

## Attribute

| Name       | Description                                                  |
| ---------- | ------------------------------------------------------------ |
| AsReadOnly | Converts the specified storage context to a new readonly storage context |

## Constructor

The StorageContext object is constructed through [Storage.CurrentContext](Storage/CurrentContext.md).