# Класс Storage 

Предоставляет набор методов для добавления, запроса и удаления данных в постоянном хранилище.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public static class Storage
```

## Атрибуты

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | ---------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [CurrentContext](Storage/CurrentContext.md) | Возвращает текущий контекст хранилища   |

## Методы

| | Имя | Описание |
| ---------------------------------------- | ---------------------------------------- | -------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, byte[])](Storage/Delete.md) | Удаляет значение из постоянного хранилища на основе данного ключа |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Delete(StorageContext, string)](Storage/Delete2.md) | Удаляет значение из постоянного хранилища на основе данного ключа |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, byte[])](Storage/Get.md) | Возвращает значение из постоянного хранилища на основе данного ключа |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Get(StorageContext, string)](Storage/Get2.md) | Возвращает значение из постоянного хранилища на основе данного ключа |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], byte[])](Storage/Put.md) | Добавляет данное значение в данный ключ в постоянном хранилище   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, byte[], string)](Storage/Put2.md) | Добавляет данное значение в данный ключ в постоянном хранилище   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, byte[])](Storage/Put3.md) | Добавляет данное значение в данный ключ в постоянном хранилище   |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Put(StorageContext, string, string)](Storage/Put4.md) | Добавляет данное значение в данный ключ в постоянном хранилище   |

## Конструктор

Класс Storage статическим классом и не нуждается в конструкторе.

