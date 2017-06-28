# StorageContex class

The class used to represent the private store storage context.

In the smart contract can be obtained through the Storage.CurrentContext own storage context, and then the object can be passed as an argument to other contracts (that is, to complete the authorization), by other contracts to the implementation of the contract context of the read and write operations The

Note: This is different from the 1.6 version.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public class StorageContext
```

## Construction method

Constructs a StorageContext object with the [Storage.CurrentContext](Storage/CurrentContext.md) property.
