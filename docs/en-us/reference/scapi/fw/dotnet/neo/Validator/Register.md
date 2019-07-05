# Validator.Register Method (byte[])

Register as a bookkeeper. This is only registration, you will require votes in order to be selected.

This method replaces RegisterTransaction in version 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Validator Register(byte[] pubkey)
```

Parameters:

pubkey：Public key as a byte array of length 33.

Return value: [Validator](../Validator.md)

## Example

```c#
public class Contract1 : FunctionCode
{
    public static void Main()
    {
        byte[] pubKey = new byte[] { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        var result = Validator.Register(pubKey);
    }
}
```



[Back](../Validator.md)