# Storage.Delete Method (StorageContext, string)

Удаляет значение из постоянного хранилища на основе данного ключа.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern void Delete(Neo.SmartContract.Framework.Services.Neo.StorageContext context, byte[] key)
```

Параметры:

Context: Контекст хранилища в виде [StorageContext](../StorageContext.md).

Key: Ключ в виде строки.

Возвращаемое значение: void.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         Storage.Delete(Storage.CurrentContext, "Key");
     }
}
```



[Back](../Storage.md)
