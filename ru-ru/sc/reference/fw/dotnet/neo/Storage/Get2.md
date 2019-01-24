# Storage.Get Method (StorageContext, string)

Возвращает значение из постоянного хранилища на основе данного ключа.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key)
```

Parameters:

Context: Контекст хранилища в виде [StorageContext](../StorageContext.md).

Key: Ключ в виде строки.

Возвращаемое значение: Значение, соответствующее ключу в виде байтового массива.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] value = Storage.Get(Storage.CurrentContext, "key");
     }
}
```



[Back](../Storage.md)
