# Класс Asset 

Представляет структуру данных актива.

Пространство имен: [Neo.SmartContract.Framework.Services.Neo](../neo.md)

Сборка: Neo.SmartContract.Framework

## Синтаксис

```c#
public class Asset
```

## Атрибуты

| | Имя | Описание |
| ---------------------------------------- | ------------------------------- | ------------------------------------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Admin](Asset/Admin.md) | Возвращает администратора (адрес контракта) данного актива, обладающего правом модифицировать атрибуты актива (такие как total, name и т.д). |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Amount](Asset/Amount.md) | Возвращает сумму актива. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetId](Asset/AssetId.md) | Возвращает ID актива. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [AssetType](Asset/AssetType.md) | Возвращает тип актива. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Available](Asset/Available.md) | Возвращает количество выпущенных токенов этого актива. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Issuer](Asset/Issuer.md) | Возвращает эмитента (адрес контракта) данного актива, обладающего правом  выпускать данный актив. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Owner](Asset/Owner.md) | Возвращает владельца (публичный ключ) данного актива. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC74937.jpeg) | [Precision](Asset/Precision.md) | Возвращает количество  знаков после десятичной запятой (точки). |

## Методы

| | Имя | Описание |
| ---------------------------------------- | ----------------------------- | ----------- |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) | `new` Регистрирует актив в блокчейне. |
| ![](https://i-msdn.sec.s-msft.com/dynimg/IC91302.jpeg) | [Renew(byte)](Asset/Renew.md)            | `new` Возобновляет актив.       |

## Конструктор

Объект Asset строится с помощью метода [Blockchain.GetAsset (byte[])](Blockchain/GetAsset.md).

Метод [Asset.Create(byte, string, long, byte, byte[], byte[], byte[])](Asset/Create.md) используется для регистрации нового актива в блокчейне. Данный метод возвращает объект Asset.