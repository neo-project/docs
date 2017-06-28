# Blockchain.RegisterValidator method (byte[])

Sign up to become a consensus person, only the registration operation, can be elected to vote for other people.

The method is a replacement for RegisterTransaction in version 2.0.

Namespace: [AntShares.SmartContract.Framework.Services.AntShares](../../AntShares.md)

Assembly: AntShares.SmartContract.Framework

## syntax

```c#
public static extern object RegisterValidator(byte[] pubkey)
```

parameter:

Pubkey: public key, a byte array of length 33.

Return value: object type, which is reserved for future smart contract extensions, temporarily meaningless.

## example

```c#
public class Contract1: FunctionCode
{
     public static void Main()
     {
         byte[] pubKey = new byte[] {2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202};
         var result = Blockchain.RegisterValidator(pubKey);
     }
}
```



[Return to superior](../Blockchain.md)
