# Класс StorageContext 

Класс, представляющий контекст хранения постоянного хранилища.  

Смарт-контракт может получить контекст собственного хранилища с помощью Storage.CurrentContext и передать его в качестве аргумента другим контрактам (как способ авторизации) для вызова методов чтения/записи для своего постоянного хранилища.

Примечание: отличается от версии 1.6.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class StorageContext
```

## Конструктор

Объект StorageContext строится с помощью [Storage.CurrentContext](Storage/CurrentContext.md).
