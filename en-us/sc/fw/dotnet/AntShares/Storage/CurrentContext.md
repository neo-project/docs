# Storage.CurrentContext property

Gets the current store context. After obtaining the store context, the object can be passed as an argument to other contracts (that is, the authorization), and the read and write operations to the storage area of the contract context are performed by other contracts.

Note: This is different from the 1.6 version.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern AntShares.SmartContract.Framework.Services.AntShares.StorageContext CurrentContext {get;}
```

Attribute value: current storage context, [StorageContext](../StorageContex.md) type.



[Return to superior](../Storage.md)
