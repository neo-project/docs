# Storage.Get Method (StorageContext, byte[])

Возвращает значение из постоянного хранилища на основе данного ключа.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern byte[] Get(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

Параметры:

Context: Контекст хранилища в виде [StorageContext](../StorageContext.md).

Key: Ключ в виде байтового массива.

Возвращаемое значение: Значение, соответствующее ключу в виде байтового массива.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] value = Storage.Get(Storage.CurrentContext, new byte[] {0});
     }
}
```



[Back](../Storage.md)
