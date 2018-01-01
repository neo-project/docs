# Validator.Register Methode (byte[])

Registrieren als ein Bookkeeper. Dies ist nur die Registrierung, Sie benötigen Stimmen um ausgewählt zu werden.

Diese Methode ersetzt RegisterTransaction in der Version 2.0.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Neo.SmartContract.Framework.Services.Neo.Validator Register(byte[] pubkey)
```

Parameter:

pubkey：Öffentlicher Schlüssel als ein Byte Array mit einer Länge von 33.

Rückgabewert: [Validator](../Validator.md)

## Beispiel

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
