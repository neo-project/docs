# Blockchain.GetAsset Method (byte[])

Возвращает актив в блокчейне при наличии ID актива.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset GetAsset (byte[] asset_id)
```

Параметры: ID актива в виде байтового массива, имеющего длину 32.

Возвращаемое значение: [Asset](../Asset.md).

## Пример

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        // Take the NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset(asset);
    }
}
```

ID актива можно получить заранее и передать его в качестве параметра в смарт-контракт. Следующий код использует SDK, чтобы преобразовать шестнадцатеричную строку в байтовый массив.

```c#
Static void Main(string[] args)
{
    byte[] asset = Neo.Helper.HexToBytes("c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b");
}
```



[Back](../Blockchain.md)
