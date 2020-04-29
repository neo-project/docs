# Runtime.GetNotifications Method (byte[])

Gets all notifications of the given contract execution.

Namespace: [Neo.SmartContract.Framework.Services.Neo](../../neo.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public static extern Notification[] GetNotifications(byte[] hash = null)
```

Parameters:

- hash：Contract scripthash as a byte array of length 20. When the array values are all 0, all notifications that currently exists are returned. 

Return value: All notifications during the contract execution.

## Example

```c#
public class Contract1 : SmartContract.Framework.SmartContract
{
    public static void Main()
    {
        Notification[] result1 = Runtime.GetNotifications();
        byte[] hash = { 2, 123, 48, 51, 62, 13, 14, 101, 82, 174, 109, 29, 169, 249, 64, 159, 85, 30, 53, 238};
        Notification[] result2 = Runtime.GetNotifications(hash);
    }
}
```

[Back](../Runtime.md)