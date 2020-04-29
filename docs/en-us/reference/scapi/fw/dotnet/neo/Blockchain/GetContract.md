# Blockchain.GetContract Method (byte[])

Returns the contract contents from a given contract script hash.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Contract GetContract(byte[] script_hash)
```

Parameters: Scripthash as a byte array of length 20. It should be little endian.

Return Value: [Contract](../Contract.md).

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        byte[] data = new byte[] { 0x01, 0x01, 0x01 ,0x01, 0x01,
                                    0x01, 0x01, 0x01, 0x01, 0x01,
                                    0x01, 0x01, 0x01, 0x01, 0x01,
                                    0x01, 0x01, 0x01, 0x01, 0x01 };
        Contract contract = Blockchain.GetContract(data);
    }
}
```



[Back](../Blockchain.md)
