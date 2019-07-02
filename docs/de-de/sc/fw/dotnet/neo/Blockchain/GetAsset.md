# Blockchain.GetAsset Methode (byte[])

Gibt ein Asset auf der Blockchain anhand einer Asset ID zurück.

Namespace [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Asset GetAsset (byte[] asset_id)
```

Parameter: Asset ID als Byte Array mit einer Länge von 32.

Rückgabewert: [Asset](../Asset.md).

## Beispiel

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

Die Asset ID kann im Voraus erstellt werden und an Smart Contracts als Parameter übergeben werden. Der folgende Code benutzt die SDK um, einen Hexstring in ein Byte Array zu konvertieren.

```c#
Static void Main(string[] args)
{
    byte[] asset = Neo.Helper.HexToBytes("c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b");
}
```



[Back](../Blockchain.md)
