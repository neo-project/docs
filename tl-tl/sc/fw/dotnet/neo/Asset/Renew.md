# Asset.Renew Method (byte[])

For asset renewal.

The method is new in version 2.0; after registration, assets will need to pay an annual fee, otherwise it will enter the frozen state.

When the asset expires, it is necessary to renew the asset. When the asset is not frozen, the renewal fee will extend the date from the expiration date of the asset. When the asset is frozen, the renewal fee will be considered from the point of payment. Therefore, there will be no arrears after paying the renewal fee.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern uint Renew (byte years)
```

Parameters: Renewal period, one year is equal to 2,000,000 blocks, byte type.

Return Value: The height of the block where the asset can be used until, after the renewal.

## Example

```c#
public class Contract1: FunctionCode
{
    public static void Main()
    {
        // Taking NEO shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset(asset);
        Uint blockIndex = ass.Renew (1);
    }
}
```



[Back](../Asset.md)
