# Asset.CreateAsset Method (byte, string, long, byte, byte[], byte[], byte[])

Данный метод регистрирует актив в блокчейне Neo.

Данный метод заменяет RegisterTransaction в версии 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset Create(byte asset_type, string name, long amount, byte precision, byte[] owner, byte[] admin, byte[] issuer)
```

Параметры:

asset_type: Тип актива в виде байта. Более подробно см. в [AssetType](../Asset/AssetType.md).

name: Имя актива в виде строки.

amount: Сумма активов в виде длинного числа. Входное значение здесь должно быть предполагаемым значением, умноженным на 100,000,000.

precision: Самое маленькое деление актива или количество  знаков после запятой (точки),  которые актив может иметь в виде байта.

owner: Открытый ключ владельца в виде байтового массива, имеющего длину 33.

admin: Адрес контракта администратора в виде байтового массива, имеющего длину 20.

issuer: Адрес контракта эмитента в виде байтового массива, имеющего длину 20.

Возвращаемое значение: Только что зарегистрированный актив в виде объекта [актива](../Asset.md).

## Пример

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte assetType = 0x60; //Token
        string name = "StarWarsMovieTicket";
        long amount = 1000;
        byte precision = 0;
        byte[] owner = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        byte[] admin = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        byte[] issuer = admin;
        Asset ass = Asset.Create(assetType, name, amount, precision, owner, admin, issuer);
        uint blockIndex = ass.Renew(1);
    }
}
```



[Back](../Asset.md)