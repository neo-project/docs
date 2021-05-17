# Runtime.CheckWitness Method

Verifies that the transactions / block of the calling contract has validated the required script hashes.

Namespace: [Neo.SmartContract.Framework.Services](../../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern bool CheckWitness(UInt160 hash);
public static extern bool CheckWitness(ECPoint pubkey);
```

Parameters:

- hash: script hash
- Pubkey: public key as a byte array of length 33.


Return value: Whether if the verification has been done, boolean.

## Example

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        byte[] pubKey = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238, 151, 25, 48, 94, 148, 93, 196, 220, 186, 153, 132, 86, 202 };
        bool result1 = Runtime.CheckWitness((ECPoint)pubKey);
        byte[] scriptHash = { 36, 23, 241, 177, 228, 54, 109, 223, 27, 237, 139, 54, 207, 38, 132, 101, 172, 3, 10, 73 };
        bool result2 = Runtime.CheckWitness((UInt160)scriptHash);
    }
}
```



[Back](../Runtime.md)