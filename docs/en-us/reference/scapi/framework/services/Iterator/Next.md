# Iterator\<TKey, TValue>.Next Method ()

The cursor moves down in the collection and returns the state, where `true` means the cursor has not moved to the end, and `false` means the cursor has moved to the end.

Namespace: [Neo.SmartContract.Framework.Services](../../services.md)

Assembly: Neo.SmartContract.Framework

## Syntax

```c#
public extern bool Next();
```

Returned value: Whether the cursor moves to the end of the collection.

## Example

```c#
public class Contract1 : SmartContract
{
    public static void Main()
    {
        var iterator = Storage.Find(new byte[] { 0x01 });
		while (iterator.Next())
		{
    		var k = iterator.Key;
    		var v = iterator.Value;
    		……
		}
    }
}
```



[Back](../Iterator.md)