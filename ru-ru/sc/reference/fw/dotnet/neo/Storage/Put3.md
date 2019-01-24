# Storage.Put Method (StorageContext, string, byte[])

Добавляет данное значение в данный ключ в постоянном хранилище..

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, byte[] value)
```

Параметры:

Context: Контекст хранилища в виде [StorageContext](../StorageContext.md).

Key: Ключ в виде строки.

Value: Значение в виде байтового массива.

Возвращаемое значение: void.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         String key = "key";
         byte[] value = new byte[] {1};
         Storage.Put(Storage.CurrentContext, key, value);
     }
}
```



[Back](../Storage.md)
