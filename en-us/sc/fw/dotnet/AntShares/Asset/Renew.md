# Asset.Renew method (byte[])

For asset renewal.

The method is a new version of the 2.0 version, 2.0 version of the chain after the registration of the assets need to pay an annual fee can be used, otherwise it will enter the frozen state.

When the asset expires, it is necessary to renew the asset. When the asset is not frozen, the renewal fee is from the expiration date of the asset. When the asset is frozen, the renewal fee is from the current time. Therefore, there will be no arrears after the renewal fee.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public extern uint Renew (byte years)
```

Parameters: renewal period, one year is equal to 2,000,000 blocks, byte type.

Return Value: The height of the block where the asset can be used after the renewal.

## example

```c#
public class Contract1: FunctionCode
{
    public static void Main ()
    {
        // Take the AntShares shares as an example
        byte[] asset = {197, 111, 51, 252, 110, 207, 205, 12, 34, 92, 74, 179, 86, 254, 229, 147, 144, 175, 133, 96, 190, 147, 15, 174, 190, 116, 166, 218, 255, 124, 155};
        Asset ass = Blockchain.GetAsset (asset);
        Uint blockIndex = ass.Renew (1);
    }
}
```



[Return to superior](../Asset.md)
