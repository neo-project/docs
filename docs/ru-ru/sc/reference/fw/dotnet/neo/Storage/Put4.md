# Storage.Put Method (StorageContext, string, string)

Добавляет данное значение в данный ключ в постоянном хранилище..

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern void Put(Neo.SmartContract.Framework.Services.Neo.StorageContext context, string key, string value)
```

Параметры:

Context: Контекст хранилища в виде [StorageContext](../StorageContext.md).

Key: Ключ в виде строки.

Value: Значение в виде строки.

Возвращаемое значение: void.

## Пример

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         String key = "key";
         String value = "value";
         Storage.Put(Storage.CurrentContext, key, value);
     }
}
```



[Back](../Storage.md)
