# Storage.CurrentContext Property

Возвращает текущий контекст хранилища. После получения контекста хранения объект можно передать в качестве аргумента другим контрактам (как способ авторизации), что позволит им выполнять операции чтения/ записи для постоянного хранилища текущего контракта.

Примечание: Отличается от версии 1.6.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.StorageContext CurrentContext {get;}
```

Значение атрибута: текущий контекст хранилища в виде [StorageContext](../StorageContext.md).



[Back](../Storage.md)
